using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimelineCaseTypeSelection : MonoBehaviour
{
    public CaseDataTypeForDay chosenCaseDataTypeForDay;
    TMP_Dropdown _dropdown;

    // Start is called before the first frame update
    void Start()
    {
        _dropdown = transform.GetComponent<TMP_Dropdown>();

        List<string> options = new List<string>();
        options.AddRange(new string[3]);

        options[(int)CaseDataTypeForDay.Cumulative] = "Cumulative Case";
        options[(int)CaseDataTypeForDay.Active] = "Active Case";
        options[(int)CaseDataTypeForDay.New] = "New Case";

        _dropdown.AddOptions(options);
    }
    public void ChangeChosenCaseDataTypeForDay()
    {
        chosenCaseDataTypeForDay = (CaseDataTypeForDay)_dropdown.value;
    }
}
