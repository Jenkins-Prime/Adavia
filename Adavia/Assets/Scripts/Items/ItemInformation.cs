using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemInformation : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    public Item Item { get; set; }
    public int StackAmount { get; set; }
    public int SlotID { get; set; }

    private Inventory inventory;

    void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Item Database").GetComponent<Inventory>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Item != null)
        {
            this.transform.SetParent(this.transform.parent.parent);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            this.transform.position = eventData.position;
        }
    }

        public void OnDrag(PointerEventData eventData)
    {
        if (Item != null)
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(inventory.Slots[SlotID].transform);
        this.transform.position = inventory.Slots[SlotID].transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

}
