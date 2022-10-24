using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : ScriptableObject
{
    public string title;
    public int cost;
    public int stats;
    public string category;
    public bool purchased;
    public Sprite icon;
}
