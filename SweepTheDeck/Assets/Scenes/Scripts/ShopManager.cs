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
    public Toggle[] equipButtons;
    public CategorySelector cs;

    public const string SWORD_ITEM = "SwordItem";
    public const string GUN_ITEM = "GunItem";
    public const string ARMOR_ITEM = "ArmorItem";
    public const string SKILL_ITEM = "SkillItem";

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

    public void EquipItem(int btnNo)
    {
        //equip means button is off; it is suggesting for user to equip
        if (!equipButtons[btnNo].isOn) //item isn't equipped yet
        {
            equipButtons[btnNo].GetComponentInChildren<TMP_Text>().SetText("UNEQUIP");
            equipButtons[btnNo].isOn = true;
            Debug.Log("unequip btn number " + btnNo);
            for (int i = 0; i < equipButtons.Length; i++)
            {
                if (i != btnNo)
                {
                    equipButtons[i].GetComponentInChildren<TMP_Text>().SetText("EQUIP");
                    equipButtons[i].isOn = false;
                }
            }
        }
        else //item is equipped; we have to unequip it
        {
            equipButtons[btnNo].GetComponentInChildren<TMP_Text>().SetText("EQUIP");
            equipButtons[btnNo].isOn = false;
        }
    }
}
