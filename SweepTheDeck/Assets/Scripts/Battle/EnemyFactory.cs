using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyFactory
{

    public static Enemy CreateEnemy(string type, int difficulty) // difficulty determines health and damage, type determines the type of sprite -- need to implement this
    {
        if (difficulty <= 10 && difficulty >= 1) // need to also check for type -- only "skeletons" and "zombies"?
        {
            return new Enemy(2, difficulty * 10, difficulty * 10, type, difficulty * 5);
        }
        return null;
    }

    /*public static Enemy AssignEnemyStats(GameObject enemy, string type, int difficulty)
    {
        if (difficulty <= 10 && difficulty >= 1) // need to also check for type -- only "skeletons" and "zombies"?
        {
            Enemy temp = enemy.Find("Enemy").GetComponent(Enemy);
            temp.speed = 2;
            *//*enemy.GetComponent(Enemy).speed = 2;
            enemy.maxHealth = difficulty * 10;
            enemy.damage = difficulty * 10;
            enemy.enemyName = type;
            enemy.gold = difficulty;
            return enemy;*//*
        }
        return null;
    }*/

    /*   // Start is called before the first frame update
       void Start()
       {

       }

       // Update is called once per frame
       void Update()
       {

       }*/
}
