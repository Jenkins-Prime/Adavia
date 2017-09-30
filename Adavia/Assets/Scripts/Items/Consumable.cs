using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    public int HealthAmount { get; set; }
    public int ManaAmount { get; set; }

    public Consumable(ItemType type, string normalSprite, string highlightSprite, string itemName, string itemDescription, int stackAmount, int healthAmount, int manaAmount) 
        : base(type, normalSprite, highlightSprite, itemName, itemDescription, stackAmount)
    {
        HealthAmount = healthAmount;
        ManaAmount = manaAmount;
    }

    public Consumable()
    {

    }

    protected override string DisplayToolTip()
    {
        return base.DisplayToolTip();
    }

    protected override void Use()
    {
        
    }
}
