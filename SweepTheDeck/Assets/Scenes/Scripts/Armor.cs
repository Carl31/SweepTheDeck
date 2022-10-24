using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Armor", menuName = "Scriptable Objects/New armor")]
public class Armor : ShopItem
{
    private int defense { get; set; }

    public Armor()
    {
        title = "DEFAULT";
        defense = 50;
        category = "ARMOR";
    }

    public Armor(int defense)
    {
        defense = stats;
        category = "ARMOR";
    }
}
