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
    public GameObject[] buyButtonGO;
    public CategorySelector cs;

    bool[] acquiredItems;

    void Start()
    {
        if (PlayerItems.instance.GetAcquiredItems().Length == 0)
            acquiredItems = new bool[shopItems.Length];
        else 
            acquiredItems = PlayerItems.instance.GetAcquiredItems();

        for (int i = 0; i < shopItems.Length; i++)
        {
            if (shopItems[i].category == cs.getCategory())
            {
                shopPanelsGO[i].SetActive(true);
            }
        }
        coinUI.text = coins.ToString();
        LoadPanels();
        CheckPurchased();
        CheckPurchaseable();
    }

    public void LoadPanels()
    {
        string stats = "DAMAGE: ";
        if (cs.getCategory() == "ARMOR")
            stats = "DEFENSE: ";
        if (cs.getCategory() == "SKILL")
            stats = "SKILL STATS: ";
        for (int i = 0; i < shopItems.Length; i++)
        {
            shopPanels[i].titleText.text = shopItems[i].title;
            shopPanels[i].statsText.text = stats + shopItems[i].stats.ToString();
            shopPanels[i].costText.text = shopItems[i].cost.ToString();
        }
    }

    public void LoadNewCategory()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            if (shopItems[i].category == cs.getCategory())
            {
                shopPanelsGO[i].SetActive(true);
            }
            else
            {
                shopPanelsGO[i].SetActive(false);
            }
        }
        LoadPanels();
        CheckPurchased();
        CheckPurchaseable();
    }

    void CheckPurchaseable()
    {
        for (int i = 0; i < shopItems.Length; i++)
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
            coinUI.text = coins.ToString();
            //after unlocking item
            CheckPurchaseable(); //dont remove this
            buyButtonGO[btnNo].SetActive(false);
            acquiredItems[btnNo] = true;
        }
    }
    
    void CheckPurchased()
    {
        for(int i = 0; i < acquiredItems.Length; i++)
        {
            if (acquiredItems[i])
                buyButtonGO[i].SetActive(false);
            else
                buyButtonGO[i].SetActive(true);
        }
    }

    private void OnDisable()
    {
        PlayerItems.instance.SetAcquiredItems(acquiredItems);
    }
}
