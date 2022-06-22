using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LatestDataSelectionToggle : MonoBehaviour
{
    public Neighbourhood.LatestCaseDataType caseDataTypeRepresenting;
    Toggle _toggle;
    LatestDataSelection _latestDataSelection;


    // Start is called before the first frame update
    void Start()
    {
        _toggle = GetComponent<Toggle>();
        _latestDataSelection = GetComponentInParent<LatestDataSelection>();

        GetComponentInChildren<Text>().text = Neighbourhood.LatestCaseDataTypeDisplayNames[(int)caseDataTypeRepresenting] + " Case";
    }

    public void SwitchDataVisualizationState()
    {
        if (_toggle.isOn)
        {
            _latestDataSelection.OnLatestDataVisualize.Invoke();
            _latestDataSelection.VisualizeData(caseDataTypeRepresenting);
        }
        else
        {
            if (!_latestDataSelection.VisualizingData())
            {
                _latestDataSelection.DevisualizeData();
            }
        }
    }
}
