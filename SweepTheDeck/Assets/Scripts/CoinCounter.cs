using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    public TextMeshProUGUI text;
    int coinCount;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void UpdateCount(int coins)
    {
        Debug.Log("test");
        coinCount += coins;
        text.SetText("x" + coinCount.ToString());
    }
}
