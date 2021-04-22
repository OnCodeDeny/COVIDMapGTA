using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.Maps.Unity;
using System;
using UnityEngine.Events;

public class LatestDataSelection : MonoBehaviour
{
    DataVisualizer[] _dataVisualizers;

    public GameObject latestDataListTogglePrefab;
    public Transform populatingSpace;
    public MapPinLayer mapPinLayer;
    public UnityEvent OnLatestDataVisualize;
    List<Toggle> _latestDataSelectionToggles = new List<Toggle>();
    ToggleGroup _latestDataSelectionToggleGroup;

    // Start is called before the first frame update
    void Start()
    {
        _dataVisualizers = new DataVisualizer[mapPinLayer.MapPins.Count];
        for (int i = 0; i < mapPinLayer.MapPins.Count; i++)
        {
            _dataVisualizers[i] = mapPinLayer.MapPins[i].GetComponent<DataVisualizer>();
        }

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

    public void VisualizeData(Neighbourhood.LatestCaseDataType caseDataTypeToBeVisualized)
    {
        StopAllCoroutines();
        foreach (DataVisualizer dataVisualizer in _dataVisualizers)
        {
            StartCoroutine(dataVisualizer.VisualizeDatumByHeight(caseDataTypeToBeVisualized));
            StartCoroutine(dataVisualizer.VisualizeDatumByColour(caseDataTypeToBeVisualized));
        }
    }

    public void DevisualizeData(bool resetVisualization = true)
    {
        StopAllCoroutines();
        if (resetVisualization)
        {
            foreach (DataVisualizer dataVisualizer in _dataVisualizers)
            {
                dataVisualizer.DevisualizeDatum();
            }
        }
    }
}
