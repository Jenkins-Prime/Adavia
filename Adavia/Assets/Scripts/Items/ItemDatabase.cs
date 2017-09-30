using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

    public ItemContainer ItemContainer
    {
        get { return itemContainer; }
        set { itemContainer = value; }
    }

    private ItemContainer itemContainer;

    
    public GameObject item;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start ()
    {
        LoadItems();
    }
	

    private void LoadItems()
    {
        itemContainer = new ItemContainer();
        Type[] itemTypes = { typeof(Weapon), typeof(Armour), typeof(Consumable) };
        XmlSerializer serialiser = new XmlSerializer(typeof(ItemContainer), itemTypes);
        TextReader reader = new StreamReader(Application.streamingAssetsPath + "/Items.xml");
        itemContainer = (ItemContainer)serialiser.Deserialize(reader);
        reader.Close();
        reader.Dispose();
    }
}
