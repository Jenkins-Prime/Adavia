using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armour : Item
{
    public int AmourAmount { get; set; }
    public string ArmourPiece { get; set; }

    public Armour(ItemType type, string normalSprite, string highlightSprite, string itemName, string itemDescription, int stackAmount, int amourAmount, string armourPiece)
        : base(type, normalSprite, highlightSprite, itemName, itemDescription, stackAmount)
    {
        AmourAmount = amourAmount;
        ArmourPiece = armourPiece;
    }

    public Armour()
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
