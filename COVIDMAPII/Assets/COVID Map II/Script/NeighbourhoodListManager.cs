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
    public LocalDataLoader localDatabase;
    public MapRenderer controllingMap;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var neighbourhood in localDatabase.neighbourhoods)
        {
            GameObject button = Instantiate(neighbourhoodListButtonPrefab, populatingSpace.transform);
            button.transform.GetComponentInChildren<TextMeshProUGUI>().text = neighbourhood.displayName;
            button.transform.GetComponent<MapMover>().defaultTarget = new MapSceneOfLocationAndZoomLevel(neighbourhood.locationLatLon, 14f);
            button.transform.GetComponent<MapMover>().map = controllingMap;
        }
    }
}
