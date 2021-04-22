using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimelineCaseTypeSelection : MonoBehaviour
{
    TimelinePlayer _timelinePlayer;
    TMP_Dropdown _dropdown;

    // Start is called before the first frame update
    void Start()
    {
        _timelinePlayer = transform.parent.GetComponent<TimelinePlayer>();

        _dropdown = transform.GetComponentInChildren<TMP_Dropdown>();

        List<string> options = new List<string>();
        options.AddRange(new string[3]);

        options[(int)Neighbourhood.DailyCaseDataType.Cumulative] = "Cumulative Case";
        options[(int)Neighbourhood.DailyCaseDataType.Active] = "Active Case";
        options[(int)Neighbourhood.DailyCaseDataType.New] = "New Case";

        _dropdown.AddOptions(options);
    }
    public void ChangeChosenVisualizedDataType()
    {
        _timelinePlayer.caseDataTypePresenting = (Neighbourhood.DailyCaseDataType)_dropdown.value;
        _timelinePlayer.OnChangeChosenVisualizedDataType();
    }
}
