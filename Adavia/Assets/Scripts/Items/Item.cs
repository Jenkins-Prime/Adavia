using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public ItemType Type { get; set; }
    public string NormalSprite { get; set; }
    public string HighlightSprite { get; set; }
    public string ItemName { get; set; }
    public string ItemDescription { get; set; }
    public int StackAmount { get; set; }

    public Item(ItemType type, string normalSprite, string highlightSprite, string itemName, string itemDescription, int stackAmount)
    {
        Type = type;
        NormalSprite = normalSprite;
        HighlightSprite = highlightSprite;
        ItemName = itemName;
        ItemDescription = itemDescription;
        StackAmount = stackAmount;
        
    }

    public Item()
    {

    }

    protected virtual string DisplayToolTip()
    {
        return "";
    }

    protected abstract void Use();

}
