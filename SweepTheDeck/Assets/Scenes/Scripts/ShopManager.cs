using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public TMP_Text coinUI;
    public ShopItem[] shopItems;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] myBuyButtons;
    public GameObject[] buyButtonGO;
    public CategorySelector cs;
    public GameObject playerModel;

    int coins;
    bool[] acquiredItems;

    void Awake()
    {
        if (PlayerItems.instance.GetAcquiredItems().Length == 0)
            acquiredItems = new bool[shopItems.Length];
        else 
            acquiredItems = PlayerItems.instance.GetAcquiredItems();
        coins = PlayerPrefs.GetInt(PlayerItems.PLAYER_COINS, 5000); //change this later
        coinUI.text = PlayerPrefs.GetInt(PlayerItems.PLAYER_COINS).ToString();
        SetPlayerModel();
        CheckPurchaseable();
        CheckPurchased();
        LoadPanels();
        LoadNewCategory();
    }

    public void addCoins()
    {
        coins += 100;
        coinUI.text = coins.ToString();
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
            shopPanels[i].iconImage.sprite = shopItems[i].icon;
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
            Debug.Log(acquiredItems[i]);
        }
    }
    public void SetPlayerModel()
    {
        playerModel = GameObject.Find("MainPirate");
        Sprite sprite;
        string fileName = "ShantyPirateModel\\0";
        //rank: default = 0; gold = 1; platinum = 2; diamond = 3;
        int objectRank = PlayerPrefs.GetInt(PlayerItems.PLAYER_SWORD, -1);
        if (objectRank != -1) { objectRank %= 3; } objectRank++;
        int armorRank = PlayerPrefs.GetInt(PlayerItems.PLAYER_ARMOR, -1);
        if (armorRank != -1) { armorRank %= 3; } armorRank++;
        fileName += objectRank.ToString() + armorRank.ToString();
        PlayerPrefs.SetString(PlayerItems.PLAYER_RESOURCE, fileName);
        Debug.Log(fileName);

        sprite = Resources.Load<Sprite>(fileName);
        playerModel.GetComponent<Image>().sprite = sprite;
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt(PlayerItems.PLAYER_COINS, coins);
        PlayerItems.instance.SetAcquiredItems(acquiredItems);
    }
}
