using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DailyCaseDatumList : MonoBehaviour
{
    public GameObject CaseDatumTextPrefab;
    public Transform populatingSpace;

    public TMP_Text neighbourhoodNameText;
    TMP_Text[] caseDatumTexts;

    private void Start()
    {
        caseDatumTexts = new TMP_Text[Neighbourhood.DailyCaseDataTypeDisplayNames.Length];
        for (int i = 0; i < caseDatumTexts.Length; i++)
        {
            caseDatumTexts[i] = Instantiate(CaseDatumTextPrefab, populatingSpace).GetComponent<TMP_Text>();
        }
    }

    public void DisplayDatumList(Neighbourhood neighbourhood, DateTime date)
    {
        gameObject.SetActive(true);
        neighbourhoodNameText.text = neighbourhood.displayName;

        foreach (Neighbourhood.DailyCaseDataType dataType in Enum.GetValues(typeof(Neighbourhood.DailyCaseDataType)))
        {
            int dataTypeIndex = (int)dataType;
            caseDatumTexts[dataTypeIndex].text = Neighbourhood.DailyCaseDataTypeDisplayNames[dataTypeIndex] + " Case: " + neighbourhood.placeDays[date].caseCountData[dataTypeIndex];
        }
    }

    public void ClearDatumList()
    {
        neighbourhoodNameText.text = "";
        for (int i = 0; i < caseDatumTexts.Length; i++)
        {
            caseDatumTexts[i].text = "";
        }
        gameObject.SetActive(false);
    }
}
