using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemType item;

    public Sprite normalSprite;

    public Sprite hoversprite;

    public int stackAmount;

    public void Use()
    {
        switch (item)
        {
            case ItemType.SWORD:
                Debug.Log("Using Sword");
                break;
            case ItemType.POTION:
                Debug.Log("Using Potion");
                break;
            default:
                break;
        }
    }
}

public enum ItemType
{
    SWORD,
    POTION
}
