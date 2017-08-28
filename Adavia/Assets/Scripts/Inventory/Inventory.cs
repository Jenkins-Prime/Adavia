using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private RectTransform inventoryRect;
    private float inventoryWidth;
    private float inventoryHeight;
    private int emptySlot;
    private List<GameObject> slots;
    private int inventoryColumns;

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




    void Start ()
    {
        InitialiseInventory();
	}

	void Update ()
    {
		
	}

    private void InitialiseInventory()
    {
        slots = new List<GameObject>();
        emptySlot = maxSlots;
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

        return false;
    }

    private bool PlaceEmptyItem(Item item)
    {
        if (emptySlot > 0)
        {
            foreach (GameObject slot in slots)
            {
                InventorySlot inventorySlot = slot.GetComponent<InventorySlot>();

                if (inventorySlot.IsSlotEmpty())
                {
                    inventorySlot.AddItem(item);
                    emptySlot--;
                    return true;
                }
            }

        }

        return false;
    }
}
