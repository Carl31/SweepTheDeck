using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Scriptable Objects/New gun")]
public class Gun : ShopItem
{
    private int damage { get; set; }

    public Gun()
    {
        title = "DEFAULT";
        damage = 150;
        category = "GUN";
    }

    public Gun(int damage)
    {
        damage = stats;
        category = "GUN";
    }
}
