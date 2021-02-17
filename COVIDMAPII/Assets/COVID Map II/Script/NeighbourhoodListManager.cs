using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Microsoft.Maps.Unity;

public class NeighbourhoodListManager : MonoBehaviour
{
    public GameObject neighbourhoodListButtonPrefab;
    public Transform populatingSpace;
    public MapRenderer controllingMap;
    public CaseDatumListManager caseDatumList;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Neighbourhood neighbourhood in Neighbourhood.allNeighbourhoods)
        {
            GameObject button = Instantiate(neighbourhoodListButtonPrefab, populatingSpace);
            NeighbourhoodListButton neighbourhoodListButton = button.transform.GetComponent<NeighbourhoodListButton>();
            neighbourhoodListButton.neighbourhoodRepresenting = neighbourhood;
            neighbourhoodListButton.mapToBeAnimated = controllingMap;
            neighbourhoodListButton.datumListToBePopulated = caseDatumList;
        }
    }
}
