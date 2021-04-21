using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.Maps.Unity;
using System;
using UnityEngine.Events;

public class LatestDataSelection : MonoBehaviour
{
    public GameObject latestDataListTogglePrefab;
    public Transform populatingSpace;
    public MapPinLayer mapPinLayer;
    public UnityEvent OnLatestDataVisualize;
    List<Toggle> _latestDataSelectionToggles = new List<Toggle>();
    ToggleGroup _latestDataSelectionToggleGroup;

    // Start is called before the first frame update
    void Start()
    {
        _latestDataSelectionToggleGroup = GetComponent<ToggleGroup>();
        Populate();
    }

    void Populate()
    {
        foreach (Neighbourhood.LatestCaseDataType dataType in Enum.GetValues(typeof(Neighbourhood.LatestCaseDataType)))
        {
            GameObject toggleGameObject = Instantiate(latestDataListTogglePrefab, populatingSpace);
            Toggle toggle = toggleGameObject.GetComponent<Toggle>();
            toggle.group = _latestDataSelectionToggleGroup;
            _latestDataSelectionToggles.Add(toggle);
            LatestDataSelectionToggle latestDataSelectionToggle = toggleGameObject.transform.GetComponent<LatestDataSelectionToggle>();
            latestDataSelectionToggle.caseDataTypeRepresenting = dataType;
            latestDataSelectionToggle.mapPinLayer = mapPinLayer;
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
