using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerItems : MonoBehaviour
{
    public static PlayerItems instance;
    public Sword defaultSword; public Gun defaultGun; public Armor defaultArmor; public Skill defaultSkill;

    int coins;
    int score;
    string acquiredItems;
    Sword sword;
    Gun gun;
    Armor armor;
    Skill skill;

    public const string PLAYER_COINS = "PlayerCoins";
    public const string PLAYER_SCORE = "PlayerScore";
    public const string PLAYER_ITEMS = "PlayerItems";
    public const string PLAYER_SWORD = "PlayerSword";
    public const string PLAYER_GUN = "PlayerGun";
    public const string PLAYER_ARMOR = "PlayerArmor";
    public const string PLAYER_SKILL = "PlayerSkill";
    public const string PLAYER_RESOURCE = "PlayerResource";

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            instance.coins = 0;
            instance.acquiredItems = "000000000000";
            instance.sword = defaultSword;
            instance.gun = defaultGun;
            instance.armor = defaultArmor;
            instance.skill = defaultSkill;
            PlayerPrefs.SetString(PLAYER_ITEMS, acquiredItems);
            PlayerPrefs.SetInt(PLAYER_SWORD, -1);
            PlayerPrefs.SetInt(PLAYER_GUN, -1);
            PlayerPrefs.SetInt(PLAYER_ARMOR, -1);
            PlayerPrefs.SetInt(PLAYER_SKILL, -1);
            PlayerPrefs.SetString(PLAYER_RESOURCE, "PirateModel\\000");
        }
        else
        {
            Destroy(instance);
        }
        DontDestroyOnLoad(instance); 
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.buildIndex == 0)
        {
            Sprite sprite;
            GameObject playerModel = GameObject.Find("MainPirate");
            string fileName = SetPlayerModel();

            sprite = Resources.Load<Sprite>(fileName);
            playerModel.GetComponent<Image>().sprite = sprite;
        }
    }
    public string GetAcquiredItems()
    {
        return acquiredItems;
    }
    public void SetAcquiredItems(string k)
    {
        acquiredItems = k;
    }
    public int GetCoins()
    {
        return coins;
    }
    public void SetCoins(int c)
    {
        coins = c;
    }
    public Sword GetSword()
    {
        return sword;
    }
    public Gun GetGun()
    {
        return gun;
    }
    public Armor GetArmor()
    {
        return armor;
    }
    public Skill GetSkill()
    {
        return skill;
    }
    public void SetSword(Sword s)
    {
        sword = s;
    }
    public void SetGun(Gun g)
    {
        gun = g;
    }
    public void SetArmor(Armor a)
    {
        armor = a;
    }
    public void SetSkill(Skill s)
    {
        skill = s;
    }

    string SetPlayerModel()
    {
        string fileName = "PirateModel\\0";
        //rank: default = 0; gold = 1; platinum = 2; diamond = 3;
        int objectRank = PlayerPrefs.GetInt(PlayerItems.PLAYER_SWORD, -1);
        if (objectRank != -1) { objectRank %= 3; }
        objectRank++;
        int armorRank = PlayerPrefs.GetInt(PlayerItems.PLAYER_ARMOR, -1);
        if (armorRank != -1) { armorRank %= 3; }
        armorRank++;
        fileName += objectRank.ToString() + armorRank.ToString();
        PlayerPrefs.SetString(PlayerItems.PLAYER_RESOURCE, fileName);
        Debug.Log(fileName);
        return fileName;
    }
}
