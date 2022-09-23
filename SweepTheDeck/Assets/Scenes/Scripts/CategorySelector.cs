using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CategorySelector : MonoBehaviour
{
    ToggleGroup toggleGroup;
    
    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
    }

    public string getCategory()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        return toggle.name;
    }
}
