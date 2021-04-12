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
        PopulateAlphabetically();
    }

    public void PopulateAlphabetically()
    {
        foreach (var item in GetComponentsInChildren<NeighbourhoodListButton>())
        {
            Destroy(item.gameObject);
        }

        foreach (Neighbourhood neighbourhood in Neighbourhood.allNeighbourhoodsInAlphabeticalOrder)
        {
            GameObject button = Instantiate(neighbourhoodListButtonPrefab, populatingSpace);
            NeighbourhoodListButton neighbourhoodListButton = button.transform.GetComponent<NeighbourhoodListButton>();
            neighbourhoodListButton.neighbourhoodRepresenting = neighbourhood;
            neighbourhoodListButton.mapToBeAnimated = controllingMap;
            neighbourhoodListButton.datumListToBePopulated = caseDatumList;
        }
    }
    public void PopulateNumerically()
    {
        foreach (var item in GetComponentsInChildren<NeighbourhoodListButton>())
        {
            Destroy(item.gameObject);
        }

        foreach (Neighbourhood neighbourhood in Neighbourhood.allNeighbourhoodsInNumericalOrder)
        {
            GameObject button = Instantiate(neighbourhoodListButtonPrefab, populatingSpace);
            NeighbourhoodListButton neighbourhoodListButton = button.transform.GetComponent<NeighbourhoodListButton>();
            neighbourhoodListButton.neighbourhoodRepresenting = neighbourhood;
            neighbourhoodListButton.mapToBeAnimated = controllingMap;
            neighbourhoodListButton.datumListToBePopulated = caseDatumList;
        }
    }
}
