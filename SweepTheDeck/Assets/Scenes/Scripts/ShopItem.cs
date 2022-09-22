using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/New shop item", order = 1)]
public class ShopItem : ScriptableObject
{
    public string title;
    public int stats;
    public int cost;
    
}
