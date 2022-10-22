using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerItems : MonoBehaviour
{
    public static PlayerItems instance;
    bool[] acquiredItems = new bool[12];

    Sword sword;
    Gun gun;
    Armor armor;
    Skill skill;

    public const string PLAYER_SWORD = "PlayerSword";
    public const string PLAYER_GUN = "PlayerGun";
    public const string PLAYER_ARMOR = "PlayerArmor";
    public const string PLAYER_SKILL = "PlayerSkill";

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else
        {
            Destroy(instance);
        }
        DontDestroyOnLoad(instance);
    }
    public bool[] GetAcquiredItems()
    {
        return acquiredItems;
    }

    public void SetAcquiredItems(bool[] b)
    {
        acquiredItems = b;
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

}
