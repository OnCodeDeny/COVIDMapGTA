using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataVisualizer : MonoBehaviour
{
    public Neighbourhood neighbourhoodRepresenting;
    public float heightMultiplier;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VisualizeDatumByHeight(CaseType caseType)
    {
        int caseTypeIndex = (int)caseType;
        float height = heightMultiplier * neighbourhoodRepresenting.caseCountData[caseTypeIndex] / Neighbourhood.NeighbourhoodWithMaxCaseCount(caseType, false).caseCountData[caseTypeIndex];
        transform.localScale = new Vector3(transform.localScale.x, height, transform.localScale.z);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.x + transform.localScale.y / 2, transform.localPosition.z);
    }
    public void VisualizeDatumByColour(CaseType caseType)
    {
        int caseTypeIndex = (int)caseType;
        float colourGB = 1 - ((float)neighbourhoodRepresenting.caseCountData[caseTypeIndex] / (float)Neighbourhood.NeighbourhoodWithMaxCaseCount(caseType, false).caseCountData[caseTypeIndex]);
        GetComponent<Renderer>().material.color = new Color(1, colourGB, colourGB);
    }
    public void DevisualizeDatum()
    {
        transform.localScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
    }
}
