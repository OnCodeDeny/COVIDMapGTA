using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.Maps.Unity;

public class DataSelectionToggle : MonoBehaviour
{
    public MapPinLayer mapPinLayer;
    Toggle toggle;
    public CaseDataTypeForNeighbourhood caseDataTypeRepresenting;
    DataVisualizer[] dataVisualizers;

    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();

        dataVisualizers = new DataVisualizer[mapPinLayer.MapPins.Count];
        for (int i = 0; i < mapPinLayer.MapPins.Count; i++)
        {
            dataVisualizers[i] = mapPinLayer.MapPins[i].GetComponent<DataVisualizer>();
        }
    }

    public void VisualizeData()
    {
        if (toggle.isOn)
        {
            foreach (DataVisualizer dataVisualizer in dataVisualizers)
            {
                StartCoroutine(dataVisualizer.VisualizeDatumByHeight(caseDataTypeRepresenting));
                StartCoroutine(dataVisualizer.VisualizeDatumByColour(caseDataTypeRepresenting));
            }
        }
        else
        {
            foreach (DataVisualizer dataVisualizer in dataVisualizers)
            {
                dataVisualizer.DevisualizeDatum();
            }
        }
    }
}
