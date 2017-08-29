using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    private RectTransform inventoryRect;
    private float inventoryWidth;
    private float inventoryHeight;
    private static int emptySlots;
    private List<GameObject> slots;
    private int inventoryColumns;

    private InventorySlot moveFrom;
    private InventorySlot moveTo;

    [SerializeField]
    private int inventoryRows;

    [SerializeField]
    private Vector2 slotPadding;

    [SerializeField]
    private float slotSize;

    [SerializeField]
    private GameObject slotPrefab;

    [SerializeField]
    private int maxSlots;

    [SerializeField]
    private Transform slotParent;

    [SerializeField]
    private GameObject hoverItemPrefab;

    private static GameObject hoverItem;

    private float hoverItemOffSetY;

    private Canvas canvas;

    public static int EmptySlots
    {
        get { return emptySlots; }
        set { emptySlots = value; }
    }


    void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }

    void Start ()
    {
        InitialiseInventory();
	}

	void Update ()
    {
        if (hoverItem != null)
        {
            Vector2 hoverPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out hoverPosition);
            hoverPosition.Set(hoverPosition.x, hoverPosition.y - hoverItemOffSetY);
            hoverItem.transform.position = canvas.transform.TransformPoint(hoverPosition);
        }
	}

    private void InitialiseInventory()
    {
        slots = new List<GameObject>();
        hoverItemOffSetY = slotSize * 0.01f;
        emptySlots = maxSlots;
        inventoryWidth = (maxSlots / inventoryRows) * (slotSize + slotPadding.x) + slotPadding.x;
        inventoryHeight = inventoryRows * (slotSize + slotPadding.y) + slotPadding.y;

        inventoryRect = GetComponent<RectTransform>();
        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, inventoryWidth);
        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inventoryHeight);

        inventoryColumns = maxSlots / inventoryRows;

        for (int index = 0; index < inventoryRows; index++)
        {
            for (int indexY = 0; indexY < inventoryColumns; indexY++)
            {
                GameObject slot = Instantiate(slotPrefab);
                RectTransform slotRect = slot.GetComponent<RectTransform>();
                slot.name = "Slot";
                slot.transform.SetParent(this.transform.parent, false);
                slotRect.transform.localPosition = inventoryRect.transform.localPosition + new Vector3(slotPadding.x * (indexY + 1) + (slotSize * indexY), -slotPadding.y * (index + 1) - (slotSize * index));
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);

                slots.Add(slot);
            }
        }
    }

    public bool AddItem(Item item)
    {
        if (item.stackAmount == 1)
        {
            PlaceEmptyItem(item);
            Debug.Log(item.name + " added to inventory");
            return true;
        }
        else
        {
            foreach (GameObject slot in slots)
            {
                InventorySlot inventorySlot = slot.GetComponent<InventorySlot>();

                if (!inventorySlot.IsSlotEmpty())
                {
                    if (inventorySlot.GetCurrentItem().item == item.item && inventorySlot.IsStackable())
                    {
                        inventorySlot.AddItem(item);
                        return true;
                    }
                }
            }

            if (emptySlots > 0)
            {
                PlaceEmptyItem(item);
            }
        }

        return false;
    }

    private bool PlaceEmptyItem(Item item)
    {
        if (emptySlots > 0)
        {
            foreach (GameObject slot in slots)
            {
                InventorySlot inventorySlot = slot.GetComponent<InventorySlot>();

                if (inventorySlot.IsSlotEmpty())
                {
                    inventorySlot.AddItem(item);
                    emptySlots--;
                    return true;
                }
            }

        }

        return false;
    }

    public void MoveItem(GameObject selected)
    {
        if (moveFrom == null)
        {
            if (!selected.GetComponent<InventorySlot>().IsSlotEmpty())
            {
                moveFrom = selected.GetComponent<InventorySlot>();
                moveFrom.GetComponent<Image>().color = Color.grey;

                hoverItem = Instantiate(hoverItemPrefab);
                hoverItem.GetComponent<Image>().sprite = selected.GetComponent<Image>().sprite;
                hoverItem.name = "Hover";

                RectTransform hoverPosition = hoverItem.GetComponent<RectTransform>();
                RectTransform selectedPosition = selected.GetComponent<RectTransform>();

                hoverPosition.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, selectedPosition.sizeDelta.x);
                hoverPosition.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, selectedPosition.sizeDelta.y);

                hoverItem.transform.SetParent(GameObject.Find("Canvas").transform, true);
                hoverItem.transform.localScale = moveFrom.gameObject.transform.localScale;



            }
        }
        else if (moveTo == null)
        {
            moveTo = selected.GetComponent<InventorySlot>();
            Destroy(GameObject.Find("Hover"));
        }

        if (moveTo != null && moveFrom != null)
        {

            Stack<Item> itemsToMove = new Stack<Item>(moveTo.Items);
            moveTo.AddItems(moveFrom.Items);

            if (itemsToMove.Count == 0)
            {
                moveFrom.ClearSlot();
            }
            else
            {
                moveFrom.AddItems(itemsToMove);
            }

            moveFrom.GetComponent<Image>().color = Color.white;
            moveTo = null;
            moveFrom = null;
            hoverItem = null;

        }
    }

}
