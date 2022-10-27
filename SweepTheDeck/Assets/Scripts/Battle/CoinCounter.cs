using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    public TextMeshProUGUI text;
    int coinCount = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(instance);
        }
        DontDestroyOnLoad(instance);
    }

    public void UpdateCount(int coins)
    {
        Debug.Log("test");
        coinCount += coins;
        text.SetText(coinCount.ToString());
    }

    public int GetCoinCount()
    {
        return coinCount;
    }
}
