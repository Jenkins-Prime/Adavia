using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private ItemType itemType;
    [SerializeField]
    private string normalSprite;
    [SerializeField]
    private string highlightSprite;
    [SerializeField]
    private string itemName;
    [SerializeField]
    private string itemDescription;
    [SerializeField]
    private int stackAmount;
    [SerializeField]
    private int damage;
    [SerializeField]
    private int armour;
    [SerializeField]
    private int healthAmount;
    [SerializeField]
    private int manaAmount;

    public void CreateItem()
    {
        ItemContainer itemContainer = new ItemContainer();
        Type[] itemTypes = { typeof(Weapon), typeof(Armour), typeof(Consumable)};

        XmlSerializer serialiser = new XmlSerializer(typeof(ItemContainer), itemTypes);

        FileStream fileStream = new FileStream(Path.Combine(Application.streamingAssetsPath, "Items.xml"), FileMode.Open);

        itemContainer = (ItemContainer)serialiser.Deserialize(fileStream);

        serialiser.Serialize(fileStream, itemContainer);
        fileStream.Close();
        fileStream.Dispose();

        switch (itemType)
        {
            case ItemType.WEAPON:
                itemContainer.Weapons.Add(new Weapon(itemType, normalSprite, highlightSprite, itemName, itemDescription, stackAmount, damage));
                break;
            case ItemType.ARMOUR:
                itemContainer.Armour.Add(new Armour(itemType, normalSprite, highlightSprite, itemName, itemDescription, stackAmount, armour, ""));
                break;
            case ItemType.CONSUMABLE:
                itemContainer.Consumables.Add(new Consumable(itemType, normalSprite, highlightSprite, itemName, itemDescription, stackAmount, healthAmount, manaAmount));
                break;
        }

        fileStream = new FileStream(Path.Combine(Application.streamingAssetsPath, "Items.xml"), FileMode.Create);
        serialiser.Serialize(fileStream, itemContainer);
        fileStream.Close();
        fileStream.Dispose();

        Debug.Log("Item has been  created");
    }


}

