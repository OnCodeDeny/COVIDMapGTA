using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.Maps.Unity;

public class DataSelectionToggle : MonoBehaviour
{
    public MapPinLayer mapPinLayer;
    Toggle _toggle;
    public NeighbourhoodCaseDataType caseDataTypeRepresenting;
    DataVisualizer[] _dataVisualizers;

    // Start is called before the first frame update
    void Start()
    {
        _toggle = GetComponent<Toggle>();

        _dataVisualizers = new DataVisualizer[mapPinLayer.MapPins.Count];
        for (int i = 0; i < mapPinLayer.MapPins.Count; i++)
        {
            _dataVisualizers[i] = mapPinLayer.MapPins[i].GetComponent<DataVisualizer>();
        }
    }

    public void VisualizeData()
    {
        if (_toggle.isOn)
        {
            foreach (DataVisualizer dataVisualizer in _dataVisualizers)
            {
                StartCoroutine(dataVisualizer.VisualizeDatumByHeight(caseDataTypeRepresenting));
                StartCoroutine(dataVisualizer.VisualizeDatumByColour(caseDataTypeRepresenting));
            }
        }
        else
        {
            foreach (DataVisualizer dataVisualizer in _dataVisualizers)
            {
                dataVisualizer.DevisualizeDatum();
            }
        }
    }
}
