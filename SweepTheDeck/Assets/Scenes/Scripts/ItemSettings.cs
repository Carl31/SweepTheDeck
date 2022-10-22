using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSettings : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ToggleGroup swordGroup;
    [SerializeField] ToggleGroup gunGroup;
    [SerializeField] ToggleGroup armorGroup;
    [SerializeField] ToggleGroup skillGroup;
    public ShopManager shopManager;
    public Toggle[] toggles;
   
    private ShopItem[] itemList;
    private string[] items;

    private void Awake()
    {
        itemList = shopManager.shopItems;
        items = new string[itemList.Length];
        SortToggleCategories();
    }

    void OnDisable()
    {
        PlayerPrefs.Save();
    }

    void SortToggleCategories()
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            switch (itemList[i].category)
            {
                case "SWORD":
                    swordGroup.RegisterToggle(toggles[i]);
                    items[i] = "SWORD";
                    break;
                case "GUN":
                    gunGroup.RegisterToggle(toggles[i]);
                    items[i] = "GUN";
                    break;
                case "ARMOR":
                    armorGroup.RegisterToggle(toggles[i]);
                    items[i] = "ARMOR";
                    break;
                case "SKILL":
                    skillGroup.RegisterToggle(toggles[i]);
                    items[i] = "SKILL";
                    break;
            }
        }
    }
    
    public void EquipToggle(int btnNo)
    {
        int itemID = itemList[btnNo].ID;
        string index = items[btnNo];
        switch (index)
        {
            case "SWORD":
                swordGroup.NotifyToggleOn(toggles[btnNo]);
                PlayerPrefs.SetInt(ShopManager.PLAYER_SWORD, itemID);
                Debug.Log("Sword " + itemID + " toggled: " + toggles[btnNo].isOn);
                break;
            case "GUN":
                gunGroup.NotifyToggleOn(toggles[btnNo]);
                PlayerPrefs.SetInt(ShopManager.PLAYER_GUN, itemID);
                Debug.Log("Gun " + itemID + " toggled: " + toggles[btnNo].isOn);
                break;
            case "ARMOR":
                armorGroup.NotifyToggleOn(toggles[btnNo]);
                PlayerPrefs.SetInt(ShopManager.PLAYER_ARMOR, itemID);
                Debug.Log("Armor " + itemID + " toggled: " + toggles[btnNo].isOn);
                break;
            case "SKILL":
                skillGroup.NotifyToggleOn(toggles[btnNo]);
                PlayerPrefs.SetInt(ShopManager.PLAYER_SKILL, itemID);
                Debug.Log("Skill " + itemID + " toggled: " + toggles[btnNo].isOn);
                break;
        }
        for(int i = 0; i < toggles.Length; i++)
        {
            toggles[i].GetComponentInChildren<TMP_Text>().SetText(toggles[i].isOn ? "UNEQUIP" : "EQUIP");
        }
    }
}
