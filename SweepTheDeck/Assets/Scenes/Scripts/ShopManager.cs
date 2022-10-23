using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

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
    public GameObject playerModel;

    bool[] acquiredItems;

    void Start()
    {
        if (PlayerItems.instance.GetAcquiredItems().Length == 0)
            acquiredItems = new bool[shopItems.Length];
        else 
            acquiredItems = PlayerItems.instance.GetAcquiredItems();
        coinUI.text = coins.ToString();

        SetPlayerModel();
        LoadPanels();
        LoadNewCategory();
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

    public void SetPlayerModel()
    {
        playerModel = GameObject.Find("MainPirate");
        Sprite sprite;
        string fileName = "ShantyPirateModel\\";
        //objectType: sword = 0; gun = 1; skill = 2
        int objectType; 
        //rank: default = 0; gold = 1; platinum = 2; diamond = 3;
        int objectRank; 
        int armorRank;
        if (cs.getCategory() == "SWORD" || cs.getCategory() == "ARMOR")
        {
            objectType = 0;
            objectRank = PlayerPrefs.GetInt(PlayerItems.PLAYER_SWORD, -1);
        } else if(cs.getCategory() == "GUN")
        {
            objectType = 0; //1
            objectRank = PlayerPrefs.GetInt(PlayerItems.PLAYER_GUN, -1);
        } else
        {
            objectType = 0; //2
            objectRank = PlayerPrefs.GetInt(PlayerItems.PLAYER_SKILL, -1);
        }

        if (objectRank != -1) { objectRank %= 3; } objectRank++;
        armorRank = PlayerPrefs.GetInt(PlayerItems.PLAYER_ARMOR, -1);
        if (armorRank != -1) { armorRank %= 3; } armorRank++;

        fileName += objectType.ToString() + objectRank.ToString() + armorRank.ToString();
        Debug.Log(fileName);

        sprite = Resources.Load<Sprite>(fileName);
        playerModel.GetComponent<Image>().sprite = sprite;
    }

    private void OnDisable()
    {
        PlayerItems.instance.SetAcquiredItems(acquiredItems);
    }
}
