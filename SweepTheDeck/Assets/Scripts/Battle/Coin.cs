using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
                Debug.Log("Coin collected!");
                CoinCounter.instance.UpdateCount(value);
        }
        else
        {
            //Debug.Log("coin error");
        }
    } 
}
