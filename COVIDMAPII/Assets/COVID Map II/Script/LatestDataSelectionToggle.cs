using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.Maps.Unity;
using System;

public class LatestDataSelectionToggle : MonoBehaviour
{
    public MapPinLayer mapPinLayer;
    public Neighbourhood.LatestCaseDataType caseDataTypeRepresenting;
    Toggle _toggle;
    LatestDataSelection _latestDataSelectionManager;
    DataVisualizer[] _dataVisualizers;

    // Start is called before the first frame update
    void Start()
    {
        _toggle = GetComponent<Toggle>();
        _latestDataSelectionManager = GetComponentInParent<LatestDataSelection>();

        GetComponentInChildren<Text>().text = Neighbourhood.LatestCaseDataTypeDisplayNames[(int)caseDataTypeRepresenting] + " Case";

        _dataVisualizers = new DataVisualizer[mapPinLayer.MapPins.Count];
        for (int i = 0; i < mapPinLayer.MapPins.Count; i++)
        {
            _dataVisualizers[i] = mapPinLayer.MapPins[i].GetComponent<DataVisualizer>();
        }
    }

    public void SwitchDataVisualizationState()
    {
        if (_toggle.isOn)
        {
            _latestDataSelectionManager.DeselectOtherToggles(_toggle);
            foreach (DataVisualizer dataVisualizer in _dataVisualizers)
            {
                StartCoroutine(dataVisualizer.VisualizeDatumByHeight(caseDataTypeRepresenting));
                StartCoroutine(dataVisualizer.VisualizeDatumByColour(caseDataTypeRepresenting));
            }
        }
        else
        {
            if (!_latestDataSelectionManager.VisualizingData())
            {
                foreach (DataVisualizer dataVisualizer in _dataVisualizers)
                {
                    dataVisualizer.DevisualizeDatum();
                }
            }
        }
    }
}
