using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Scriptable Objects/New gun")]
public class Gun : ShopItem
{
    public int ID;
    private int damage;

    public Gun()
    {
        ID = 0;
        damage = stats;
        category = "GUN";
    }
}
