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
    public ShopManager instance;
    public Toggle[] toggles;
    private ShopItem[] itemList;
    private string[] items;

    private void Awake()
    {
        itemList = instance.shopItems;
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
                    if (i == PlayerPrefs.GetInt(PlayerItems.PLAYER_SWORD, 0))
                        toggles[i].isOn = true;
                    toggles[i].GetComponentInChildren<TMP_Text>().SetText(toggles[i].isOn ? "UNEQUIP" : "EQUIP");
                    swordGroup.RegisterToggle(toggles[i]);
                    items[i] = "SWORD";
                    break;
                case "GUN":
                    if (i == PlayerPrefs.GetInt(PlayerItems.PLAYER_GUN, 0))
                        toggles[i].isOn = true;
                    toggles[i].GetComponentInChildren<TMP_Text>().SetText(toggles[i].isOn ? "UNEQUIP" : "EQUIP");
                    gunGroup.RegisterToggle(toggles[i]);
                    items[i] = "GUN";
                    break;
                case "ARMOR":
                    if (i == PlayerPrefs.GetInt(PlayerItems.PLAYER_ARMOR, 0))
                        toggles[i].isOn = true;
                    toggles[i].GetComponentInChildren<TMP_Text>().SetText(toggles[i].isOn ? "UNEQUIP" : "EQUIP");
                    armorGroup.RegisterToggle(toggles[i]);
                    items[i] = "ARMOR";
                    break;
                case "SKILL":
                    if (i == PlayerPrefs.GetInt(PlayerItems.PLAYER_SKILL, 0))
                        toggles[i].isOn = true;
                    toggles[i].GetComponentInChildren<TMP_Text>().SetText(toggles[i].isOn ? "UNEQUIP" : "EQUIP");
                    skillGroup.RegisterToggle(toggles[i]);
                    items[i] = "SKILL";
                    break;
            }
        }
    }
    
    public void EquipToggle(int btnNo)
    {
        string index = items[btnNo];
        switch (index)
        {
            case "SWORD":
                swordGroup.NotifyToggleOn(toggles[btnNo]);
                PlayerItems.instance.SetSword((Sword)itemList[btnNo]);
                PlayerPrefs.SetInt(PlayerItems.PLAYER_SWORD, btnNo);
                break;
            case "GUN":
                gunGroup.NotifyToggleOn(toggles[btnNo]);
                PlayerItems.instance.SetGun((Gun)itemList[btnNo]);
                PlayerPrefs.SetInt(PlayerItems.PLAYER_GUN, btnNo);
                break;
            case "ARMOR":
                armorGroup.NotifyToggleOn(toggles[btnNo]);
                PlayerItems.instance.SetArmor((Armor)itemList[btnNo]);
                PlayerPrefs.SetInt(PlayerItems.PLAYER_ARMOR, btnNo);
                break;
            case "SKILL":
                skillGroup.NotifyToggleOn(toggles[btnNo]);
                PlayerItems.instance.SetSkill((Skill)itemList[btnNo]);
                PlayerPrefs.SetInt(PlayerItems.PLAYER_SKILL, btnNo);
                break;
        }
        for(int i = 0; i < toggles.Length; i++)
        {
            toggles[i].GetComponentInChildren<TMP_Text>().SetText(toggles[i].isOn ? "UNEQUIP" : "EQUIP");
        }
        PlayerPrefs.Save();
    }
}
