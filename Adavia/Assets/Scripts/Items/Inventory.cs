using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<GameObject> Slots { get; private set; }
    public List<Item> Items { get; private set; }

    private ItemDatabase database;


    [SerializeField]
    private GameObject slotPrefab;
    [SerializeField]
    private GameObject itemPrefab;
    private Image itemSprite;
    [SerializeField]

    private Transform slotPanel;


    private int amountOfSlots;


    void Start()
    {
        database = GetComponent<ItemDatabase>();
        amountOfSlots = 16;
        Items = new List<Item>();
        Slots = new List<GameObject>();

        InitialiseInventory();

        AddItem(0);
        AddItem(1);
        AddItem(2);
        AddItem(2);
        AddItem(2);
        AddItem(2);
        AddItem(2);
        AddItem(2);
    }

    public void AddItem(int id)
    {
        Item item = database.GetItem(id);

        if (item.IsStackable && DoesItemExist(item))
        {
            for (int index = 0; index < Items.Count; index++)
            {
                if (Items[index].ItemID == id)
                {
                    ItemInformation itemInformation = Slots[index].transform.GetChild(0).GetComponent<ItemInformation>();
                    itemInformation.StackAmount++;
                    itemInformation.transform.GetChild(0).GetComponent<Text>().text = itemInformation.StackAmount.ToString();
                    return;
                }
            }
        }
        else
        {
            for (int index = 0; index < Items.Count; index++)
            {
                if (Items[index].ItemID == -1)
                {
                    Items[index] = item;
                    GameObject itemInfo = Instantiate(itemPrefab);
                    itemInfo.GetComponent<ItemInformation>().Item = item;
                    itemInfo.GetComponent<ItemInformation>().SlotID = index;
                    itemInfo.GetComponent<ItemInformation>().StackAmount = 1;
                    itemInfo.GetComponent<Image>().sprite = item.ItemIcon;
                    itemInfo.transform.SetParent(Slots[index].transform, false);
                    return;
                }
            }
        }

    }

    private void InitialiseInventory()
    {
        for (int index = 0; index < amountOfSlots; index++)
        {
            Items.Add(new Item());
            Slots.Add(Instantiate(slotPrefab));
            Slots[index].GetComponent<InventorySlot>().SlotID = index;
            Slots[index].transform.SetParent(slotPanel, false);
            Slots[index].name = "Slot";
        }
    }

    private bool DoesItemExist(Item item)
    {
        for (int index = 0; index < Items.Count; index++)
        {
            if (Items[index].ItemID == item.ItemID)
            {
                return true;
            }
        }

        return false;
    }
}

