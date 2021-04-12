using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SortOptionDropdown : MonoBehaviour
{
    NeighbourhoodListManager _neighbourhoodListManager;
    TMP_Dropdown _dropdown;

    // Start is called before the first frame update
    void Start()
    {
        _neighbourhoodListManager = transform.parent.GetComponent<NeighbourhoodListManager>();
        _dropdown = GetComponent<TMP_Dropdown>();
    }

    public void SortNeighbourhoodList()
    {
        if (_dropdown.value == 0)
        {
            _neighbourhoodListManager.PopulateAlphabetically();
        }
        else if (_dropdown.value == 1)
        {
            _neighbourhoodListManager.PopulateNumerically();
        }
    }
}
