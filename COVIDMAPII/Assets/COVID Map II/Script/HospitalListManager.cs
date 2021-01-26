﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Microsoft.Maps.Unity;

public class HospitalListManager : MonoBehaviour
{
    public GameObject hospitalListButtonPrefab;
    public Transform populatingSpace;
    public LocalDataLoader localDatabase;
    public MapRenderer controllingMap;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var hospital in localDatabase.hospitals)
        {
            GameObject button = Instantiate(hospitalListButtonPrefab, populatingSpace.transform);
            button.transform.GetComponentInChildren<TextMeshProUGUI>().text = hospital.displayName;
            button.transform.GetComponent<MapMover>().defaultTarget = new MapSceneOfLocationAndZoomLevel(hospital.locationLatLon, 17.5f);
            button.transform.GetComponent<MapMover>().map = controllingMap;
        }
    }
}
