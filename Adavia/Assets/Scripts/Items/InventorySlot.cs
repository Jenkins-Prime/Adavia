using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public int SlotID;
    private Inventory inventory;

    void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Item Database").GetComponent<Inventory>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemInformation item = eventData.pointerDrag.GetComponent<ItemInformation>();

        if (inventory.Items[SlotID].ItemID == -1)
        {
            inventory.Items[item.SlotID] = new Item();
            inventory.Items[SlotID] = item.Item;
            item.SlotID = SlotID;
        }
        else
        {
            Transform itemPosition = transform.GetChild(0);
            itemPosition.GetComponent<ItemInformation>().SlotID = item.SlotID;
            itemPosition.transform.SetParent(inventory.Slots[item.SlotID].transform);
            itemPosition.position = inventory.Slots[item.SlotID].transform.position;

            item.SlotID = SlotID;
            item.transform.SetParent(transform);
            item.transform.position = transform.position;

            inventory.Items[item.SlotID] = item.GetComponent<ItemInformation>().Item;
            inventory.Items[SlotID] = item.Item;

        }
    }

}


