using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CaseDatumListManager : MonoBehaviour
{
    public GameObject CaseDatumListTextPrefab;
    public Transform populatingSpace;

    public void DisplayDatumList(Neighbourhood neighbourhood)
    {
        foreach (Transform child in populatingSpace.transform)
        {
            Destroy(child.gameObject);
        }

        //abstract for future: dictionary+keyvaluepairs.
        string[] data = new string[] {
        "Cumulative Case: "+neighbourhood.cumulativeCaseCount,
        "Ever Hospitalized: "+neighbourhood.everHospitalizedCaseCount,
        "Ever in ICU: "+neighbourhood.everInICUCaseCount,
        "Ever Intubated: "+neighbourhood.everIntubatedCaseCount,

        "Deceased: "+neighbourhood.deceasedCaseCount,

        "Active Case: "+neighbourhood.activeCaseCount,
        "Currently Hospitalized: "+neighbourhood.currentlyHospitalizedCaseCount,
        "Currently in ICU: "+neighbourhood.currentlyInICUCaseCount,
        "Currently Intubated: "+neighbourhood.currentlyIntubatedCaseCount
        };

        foreach (string datum in data)
        {
            Instantiate(CaseDatumListTextPrefab, populatingSpace).GetComponent<TextMeshProUGUI>().text = datum;
        }

        gameObject.SetActive(true);
    }
}
