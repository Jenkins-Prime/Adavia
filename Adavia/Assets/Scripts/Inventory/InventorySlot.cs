using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Stack<Item> items;
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
        RectTransform stackRect = GetComponent<RectTransform>();

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

    public void RemoveItem()
    {
        items.Pop();
    }

    private void UpdateSprite(Sprite normal, Sprite hover)
    {
        GetComponent<Image>().sprite = normal;

        SpriteState state = new SpriteState();

        state.highlightedSprite = hover;
        state.pressedSprite = normal;
        GetComponent<Button>().spriteState = state;
    }

    public bool IsSlotEmpty()
    {
        return items.Count == 0;
    }
}
