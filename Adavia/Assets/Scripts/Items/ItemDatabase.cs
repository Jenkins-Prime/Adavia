using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ItemDatabase : MonoBehaviour
{
    private List<Item> items = new List<Item>();
    private JsonData itemInfo;

	void Start ()
    {
        itemInfo = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/ItemDatabase.json"));

        Initialise();

        Debug.Log(GetItem(0).ItemString);
    }


    public Item GetItem(int id)
    {
        for (int index = 0; index < items.Count; index++)
        {
            if (items[index].ItemID == id)
            {
                return items[index];
            }
        }

        return null;
    }

    private void Initialise()
    {
        for (int index = 0; index < itemInfo.Count; index++)
        {
            items.Add(new Item((int)itemInfo[index]["id"], itemInfo[index]["name"].ToString(), itemInfo[index]["description"].ToString(), (bool)itemInfo[index]["quest"], (bool)itemInfo[index]["stackable"], (int)itemInfo[index]["price"], (int)itemInfo[index]["durability"], (int)itemInfo[index]["damage"], itemInfo[index]["string"].ToString()));
        }
    }
}

public class Item
{
    public int ItemID { get; set; }
    public string ItemName { get; set; }
    public string ItemDescription { get; set; }
    public bool IsQuestItem { get; set; }
    public bool IsStackable { get; set; }
    public int ItemPrice { get; set; }
    public int ItemDurability { get; set; }
    public int ItemDamage { get; set; }
    public string ItemString { get; set;}
    public Sprite ItemIcon { get; set; }
    



    public Item(int itemID, string itemName, string itemDescription, bool isQuestItem, bool isStackable, int itemPrice, int itemDurability, int itemDamage, string itemString)
    {
        ItemID = itemID;
        ItemName = itemName;
        ItemDescription = itemDescription;
        IsQuestItem = isQuestItem;
        IsStackable = isStackable;
        ItemPrice = itemPrice;
        ItemDurability = itemDurability;
        ItemDamage = itemDamage;
        ItemString = itemString;
        ItemIcon = Resources.Load<Sprite>("Items/Sprites/" + itemString);
    }

    public Item()
    {
        ItemID = -1;
    }
}