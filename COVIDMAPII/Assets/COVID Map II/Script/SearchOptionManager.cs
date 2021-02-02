using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SearchOptionManager : MonoBehaviour
{
    public GameObject[] placeLists;
    public TMP_Dropdown searchOptionDropdown;
    public void OnSelectionChanged()
    {
        if (searchOptionDropdown.value == 0)
        {
            ReplacePlaceListWith("Neighbourhood List");
        }
        else if (searchOptionDropdown.value == 1)
        {
            ReplacePlaceListWith("Hospital List");
        }
    }
    void ReplacePlaceListWith(string placeListName)
    {
        foreach (var placeList in placeLists)
        {
            if (placeList.name == placeListName)
                placeList.SetActive(true);
            else
                placeList.SetActive(false);
        }
    }
}
