using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private GameObject go;
    private SoundVolume sVolume;
    private MusicVolume mVolume;
    private void Awake()
    {
        sVolume = gameObject.GetComponent<SoundVolume>();
        mVolume = gameObject.GetComponent<MusicVolume>();
    }

    // Update is called once per frame
    private void Update()
    {
       
    }
}
