using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipItem : MonoBehaviour
{
    public bool isEquipped;

    public void toggleEquip(TMP_Text equipText)
    {
        if(!isEquipped)
        {
            equipText.text = "UNEQUIP";
            isEquipped = true;
        } else
        {
            equipText.text = "EQUIP";
            isEquipped = false;
        }
    }
}
