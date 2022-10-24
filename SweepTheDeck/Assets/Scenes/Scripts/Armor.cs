using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Armor", menuName = "Scriptable Objects/New armor")]
public class Armor : ShopItem
{
    private int defense;

    public Armor()
    {
        ID = 0;
        defense = stats;
        category = "ARMOR";
    }
}
