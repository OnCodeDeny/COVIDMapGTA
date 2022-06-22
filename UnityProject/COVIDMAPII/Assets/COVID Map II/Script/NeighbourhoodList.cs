using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Maps.Unity;

public class NeighbourhoodList : MonoBehaviour
{
    public GameObject neighbourhoodListButtonPrefab;
    public Transform populatingSpace;
    public MapRenderer controllingMap;
    public LatestCaseDatumList controllingLatestCaseDatumList;
    public TimelinePlayer controllingTimelinePlayer;

    // Start is called before the first frame update
    void Start()
    {
        PopulateAlphabetically();
    }

    public void PopulateAlphabetically()
    {
        foreach (NeighbourhoodListButton button in GetComponentsInChildren<NeighbourhoodListButton>())
        {
            Destroy(button.gameObject);
        }

        foreach (Neighbourhood neighbourhood in Neighbourhood.allNeighbourhoodsInAlphabeticalOrder)
        {
            GameObject button = Instantiate(neighbourhoodListButtonPrefab, populatingSpace);
            NeighbourhoodListButton neighbourhoodListButton = button.transform.GetComponent<NeighbourhoodListButton>();
            neighbourhoodListButton.neighbourhoodRepresenting = neighbourhood;
            neighbourhoodListButton.mapToBeAnimated = controllingMap;
            neighbourhoodListButton.datumListToBePopulated = controllingLatestCaseDatumList;
            neighbourhoodListButton.timelinePlayer = controllingTimelinePlayer;
        }
    }
    public void PopulateNumerically()
    {
        foreach (NeighbourhoodListButton button in GetComponentsInChildren<NeighbourhoodListButton>())
        {
            Destroy(button.gameObject);
        }

        foreach (Neighbourhood neighbourhood in Neighbourhood.allNeighbourhoodsInNumericalOrder)
        {
            GameObject button = Instantiate(neighbourhoodListButtonPrefab, populatingSpace);
            NeighbourhoodListButton neighbourhoodListButton = button.transform.GetComponent<NeighbourhoodListButton>();
            neighbourhoodListButton.neighbourhoodRepresenting = neighbourhood;
            neighbourhoodListButton.mapToBeAnimated = controllingMap;
            neighbourhoodListButton.datumListToBePopulated = controllingLatestCaseDatumList;
            neighbourhoodListButton.timelinePlayer = controllingTimelinePlayer;
        }
    }
}
