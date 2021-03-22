using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSelectionToggle : MonoBehaviour
{
    [SerializeField]
    DataVisualizer[] dataBars;
    Toggle toggle;
    public CaseAttribute caseTypeRepresenting;
    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    public void VisualizeData()
    {
        dataBars = FindObjectsOfType<DataVisualizer>();
        if (toggle.isOn)
        {
            foreach (DataVisualizer dataBar in dataBars)
            {
                dataBar.VisualizeDatumByHeight(caseTypeRepresenting);
                dataBar.VisualizeDatumByColour(caseTypeRepresenting);
            }
        }
        else
        {
            foreach (DataVisualizer dataBar in dataBars)
            {
                dataBar.DevisualizeDatum();
            }
        }
    }
}
