using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimelineCaseTypeSelection : MonoBehaviour
{
    TimelinePlayer _timelinePlayer;
    TMP_Dropdown _dropdown;

    // Start is called before the first frame update
    void Start()
    {
        _timelinePlayer = transform.parent.GetComponent<TimelinePlayer>();

        _dropdown = transform.GetComponent<TMP_Dropdown>();

        List<string> options = new List<string>();
        options.AddRange(new string[3]);

        options[(int)NeighbourhoodDailyCaseDataType.Cumulative] = "Cumulative Case";
        options[(int)NeighbourhoodDailyCaseDataType.Active] = "Active Case";
        options[(int)NeighbourhoodDailyCaseDataType.New] = "New Case";

        _dropdown.AddOptions(options);
    }
    public void ChangeChosenVisualizedDataType()
    {
        _timelinePlayer.caseDataTypePresenting = (NeighbourhoodDailyCaseDataType)_dropdown.value;
        _timelinePlayer.OnChangeChosenVisualizedDataType();
    }
}
