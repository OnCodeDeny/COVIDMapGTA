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
    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    public void VisualizeData()
    {
        if (toggle.isOn)
        {
            foreach (MapPin mapPin in mapPinLayer.MapPins)
            {
                DataVisualizer visualizer = mapPin.GetComponent<DataVisualizer>();
                StartCoroutine(visualizer.VisualizeDatumByHeight(caseDataTypeRepresenting));
                StartCoroutine(visualizer.VisualizeDatumByColour(caseDataTypeRepresenting));
            }
        }
        else
        {
            foreach (MapPin mapPin in mapPinLayer.MapPins)
            {
                mapPin.gameObject.GetComponent<DataVisualizer>().DevisualizeDatum();
            }
        }
    }
}
