using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSystem : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite hoversprite;

    private Item item;

    public Item Item
    {
        get { return item; }
        set
        {
            item = value;
            normalSprite = Resources.Load<Sprite>(value.NormalSprite);
            hoversprite = Resources.Load<Sprite>(value.HighlightSprite);
        }
    }


   

    public void Use()
    {

    }
}

public enum ItemType
{
    WEAPON,
    ARMOUR,
    CONSUMABLE  
}
