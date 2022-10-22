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

    public const string PLAYER_SWORD = "PlayerSword";
    public const string PLAYER_GUN = "PlayerGun";
    public const string PLAYER_ARMOR = "PlayerArmor";
    public const string PLAYER_SKILL = "PlayerSkill";

    void Start()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            if (shopItems[i].category == cs.getCategory())
            {
                shopPanelsGO[i].SetActive(true);
            }
        }
        coinUI.text = coins.ToString();
        LoadPanels();
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
        CheckPurchaseable();
    }

    public void CheckPurchaseable()
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
            Debug.Log(shopItems[btnNo] + "purchased");
            buyButtonGO[btnNo].SetActive(false);
        }
    }
    //this should be in playerSettings
    public void CheckEquipped()
    {
        int swordIndex = PlayerPrefs.GetInt(PLAYER_SWORD, 0);
        int gunIndex = PlayerPrefs.GetInt(PLAYER_GUN, 0);
        int armorIndex = PlayerPrefs.GetInt(PLAYER_ARMOR, 0);
        int skillIndex = PlayerPrefs.GetInt(PLAYER_SKILL, 0);

    }
}
