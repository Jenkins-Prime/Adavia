using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public int Damage { get; set; }

    public Weapon(ItemType type, string normalSprite, string highlightSprite, string itemName, string itemDescription, int stackAmount, int damage)
        : base(type, normalSprite, highlightSprite, itemName, itemDescription, stackAmount)
    {
        Damage = damage;
    }

    public Weapon()
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
