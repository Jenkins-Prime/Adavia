using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    private Stack<Item> items;

    public Stack<Item> Items
    {
        get { return items; }
        set { items = value; }
    }

    [SerializeField]
    private Text stackAmountText;

    [SerializeField]
    private Sprite slotEmpty;

    [SerializeField]
    private Sprite slotHover;

    // Use this for initialization
    void Start ()
    {
        items = new Stack<Item>();
        stackAmountText.text = "";
        RectTransform slotRect = GetComponent<RectTransform>();
        RectTransform stackRect = stackAmountText.GetComponent<RectTransform>();

        int scaleFactor = (int)(slotRect.sizeDelta.x * 0.60f);
        stackAmountText.resizeTextMinSize = scaleFactor;
        stackAmountText.resizeTextMaxSize = scaleFactor;

        stackRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotRect.sizeDelta.x);
        stackRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotRect.sizeDelta.y);
    }

    public void AddItem(Item item)
    {
        items.Push(item);

        if (items.Count > 1)
        {
            stackAmountText.text = items.Count.ToString();

        }

        UpdateSprite(item.normalSprite, item.hoversprite);
    }

    public void AddItems(Stack<Item> items)
    {
        this.items = new Stack<Item>(items);
        stackAmountText.text = items.Count > 1 ? items.Count.ToString() : "";
        UpdateSprite(GetCurrentItem().normalSprite, GetCurrentItem().hoversprite);

    }

    private void UpdateSprite(Sprite normal, Sprite hover)
    {
        GetComponent<Image>().sprite = normal;

        SpriteState state = new SpriteState();

        state.highlightedSprite = hover;
        state.pressedSprite = normal;
        GetComponent<Button>().spriteState = state;
    }

    private void UseItem()
    {
        if (!IsSlotEmpty())
        {
            items.Pop().Use();

            stackAmountText.text = items.Count > 1 ? items.Count.ToString() : "";

            if (IsSlotEmpty())
            {
                UpdateSprite(slotEmpty, slotHover);
                Inventory.EmptySlots++;
            }

        }
    }

    public void ClearSlot()
    {
        items.Clear();
        UpdateSprite(slotEmpty, slotHover);
        stackAmountText.text = "";
    }

    public bool IsSlotEmpty()
    {
        return items.Count == 0;
    }

    public Item GetCurrentItem()
    {
        return items.Peek();
    }

    public bool IsStackable()
    {
        return GetCurrentItem().stackAmount > items.Count;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            UseItem();
        }
    }
}
