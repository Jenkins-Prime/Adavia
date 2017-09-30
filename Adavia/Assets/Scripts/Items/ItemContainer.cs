using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer
{
    private List<Item> weapons = new List<Item>();
    private List<Item> armour = new List<Item>();
    private List<Item> consumables = new List<Item>();

    public ItemContainer()
    {

    }

    public List<Item> Weapons
    {
        get { return weapons; }
        set { weapons = value; }
    }

    public List<Item> Armour
    {
        get { return armour; }
        set { armour = value; }
    }

    public List<Item> Consumables
    {
        get { return consumables; }
        set { consumables = value; }
    }

}
