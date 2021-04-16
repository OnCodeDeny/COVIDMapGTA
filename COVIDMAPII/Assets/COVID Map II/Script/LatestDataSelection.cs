using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Microsoft.Maps.Unity;
using System;

public class LatestDataSelection : MonoBehaviour
{
    public GameObject latestDataListTogglePrefab;
    public Transform populatingSpace;
    public MapPinLayer mapPinLayer;
    List<Toggle> _latestDataSelectionToggles = new List<Toggle>();

    // Start is called before the first frame update
    void Start()
    {
        Populate();
    }

    void Populate()
    {
        foreach (Neighbourhood.LatestCaseDataType dataType in Enum.GetValues(typeof(Neighbourhood.LatestCaseDataType)))
        {
            GameObject toggleGameObject = Instantiate(latestDataListTogglePrefab, populatingSpace);
            _latestDataSelectionToggles.Add(toggleGameObject.GetComponent<Toggle>());
            LatestDataSelectionToggle latestDataSelectionToggle = toggleGameObject.transform.GetComponent<LatestDataSelectionToggle>();
            latestDataSelectionToggle.caseDataTypeRepresenting = dataType;
            latestDataSelectionToggle.mapPinLayer = mapPinLayer;
        }
    }

    public void DeselectOtherToggles(Toggle toggleKeptOn)
    {
        foreach (Toggle toggle in _latestDataSelectionToggles)
        {
            if (toggle != toggleKeptOn)
            {
                toggle.isOn = false;
            }
        }
    }

    public bool VisualizingData()
    {
        foreach (Toggle toggle in _latestDataSelectionToggles)
        {
            if (toggle.isOn)
            {
                return true;
            }
        }
        return false;
    }
}
