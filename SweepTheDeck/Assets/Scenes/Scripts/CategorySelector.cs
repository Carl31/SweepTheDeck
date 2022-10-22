using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CategorySelector : MonoBehaviour
{
    [SerializeField] ToggleGroup toggleGroup;
    string categoryName;
    public string getCategory()
    {
        categoryName = toggleGroup.ActiveToggles().FirstOrDefault().name;
        //Debug.Log(toggle.name);
        return categoryName;
    }
}
