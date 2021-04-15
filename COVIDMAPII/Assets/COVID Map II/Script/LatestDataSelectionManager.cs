using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Microsoft.Maps.Unity;
using System;

public class LatestDataSelectionManager : MonoBehaviour
{
    public GameObject latestDataListTogglePrefab;
    public Transform populatingSpace;
    public MapPinLayer mapPinLayer;

    // Start is called before the first frame update
    void Start()
    {
        Populate();
    }

    void Populate()
    {
        foreach (Neighbourhood.LatestCaseDataType dataType in Enum.GetValues(typeof(Neighbourhood.LatestCaseDataType)))
        {
            GameObject toggle = Instantiate(latestDataListTogglePrefab, populatingSpace);
            LatestDataSelectionToggle latestDataSelectionToggle = toggle.transform.GetComponent<LatestDataSelectionToggle>();
            latestDataSelectionToggle.caseDataTypeRepresenting = dataType;
            latestDataSelectionToggle.mapPinLayer = mapPinLayer;
        }
    }
}
