using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CategorySelector : MonoBehaviour
{
    ToggleGroup toggleGroup;
    string categoryName;
    void Awake()
    {
        toggleGroup = GetComponent<ToggleGroup>();
        categoryName = toggleGroup.ActiveToggles().FirstOrDefault().name;
    }

    public string getCategory()
    {
        categoryName = toggleGroup.ActiveToggles().FirstOrDefault().name;
        //Debug.Log(toggle.name);
        return categoryName;
    }
}
