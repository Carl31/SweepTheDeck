using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinUI;
    public ShopItem[] shopItems;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] myBuyButtons;
   
    void Start()
    {
        coins = PlayerPrefs.GetInt("COINS");
        for(int i = 0; i < shopItems.Length; i++)
            shopPanelsGO[i].SetActive(true);
        coinUI.text = "Coins: " + coins.ToString();
        LoadPanels();
        CheckPurchaseable();
    }

    public void LoadPanels()
    {
        for(int i = 0; i < shopItems.Length; i++)
        {
            shopPanels[i].titleText.text = shopItems[i].title;
            shopPanels[i].statsText.text = "Stats: " + shopItems[i].stats.ToString();
            shopPanels[i].costText.text = "Price: " + shopItems[i].cost.ToString();
        }
    }

    public void CheckPurchaseable()
    {
        for(int i = 0; i < shopItems.Length; i++)
        {
            if (coins >= shopItems[i].cost)
                myBuyButtons[i].interactable = true;
            else
                myBuyButtons[i].interactable = false;
        }
    }

    public void PurchaseItem(int btnNo)
    {
        if (coins >= shopItems[btnNo].cost)
        {
            coins = coins - shopItems[btnNo].cost;
            coinUI.text = "Coins: " + coins.ToString();
            //after unlocking item
            CheckPurchaseable(); //dont remove this
            myBuyButtons[btnNo].interactable = false;
            Debug.Log(shopItems[btnNo] + "purchased");
        }
    }
}
