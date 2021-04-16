using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LatestCaseDatumList : MonoBehaviour
{
    public GameObject CaseDatumTextPrefab;
    public Transform populatingSpace;

    public TMP_Text neighbourhoodNameText;
    TMP_Text[] caseDatumTexts;

    private void Start()
    {
        caseDatumTexts = new TMP_Text[Neighbourhood.LatestCaseDataTypeDisplayNames.Length];
        for (int i = 0; i < caseDatumTexts.Length; i++)
        {
            caseDatumTexts[i] = Instantiate(CaseDatumTextPrefab, populatingSpace).GetComponent<TMP_Text>();
        }
    }

    public void DisplayDatumList(Neighbourhood neighbourhood)
    {
        neighbourhoodNameText.text = neighbourhood.displayName;

        foreach (Neighbourhood.LatestCaseDataType dataType in Enum.GetValues(typeof(Neighbourhood.LatestCaseDataType)))
        {
            int dataTypeIndex = (int)dataType;
            caseDatumTexts[dataTypeIndex].text = Neighbourhood.LatestCaseDataTypeDisplayNames[dataTypeIndex] + " Case: " + neighbourhood.caseCountData[dataTypeIndex];
        }
    }
}
