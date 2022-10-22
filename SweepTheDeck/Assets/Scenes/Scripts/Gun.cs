using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Scriptable Objects/New gun")]
public class Gun : ShopItem
{
    private int damage;

    public Gun()
    {
        ID = 0;
        damage = stats;
        category = "GUN";
    }
}
