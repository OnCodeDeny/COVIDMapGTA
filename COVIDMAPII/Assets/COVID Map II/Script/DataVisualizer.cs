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

    public void VisualizeDatumByHeight(CaseAttribute caseAttribute)
    {
        int caseTypeIndex = (int)caseAttribute;
        float height = heightMultiplier * neighbourhoodRepresenting.caseCountData[caseTypeIndex] / Neighbourhood.NeighbourhoodWithMaxCaseCount(caseAttribute, false).caseCountData[caseTypeIndex];
        transform.localScale = new Vector3(transform.localScale.x, height, transform.localScale.z);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.x + transform.localScale.y / 2, transform.localPosition.z);
    }
    public void VisualizeDatumByColour(CaseAttribute caseAttribute)
    {
        int caseTypeIndex = (int)caseAttribute;
        float colourGB = 1 - ((float)neighbourhoodRepresenting.caseCountData[caseTypeIndex] / (float)Neighbourhood.NeighbourhoodWithMaxCaseCount(caseAttribute, false).caseCountData[caseTypeIndex]);
        GetComponent<Renderer>().material.color = new Color(1, colourGB, colourGB);
    }
    public void DevisualizeDatum()
    {
        transform.localScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
    }
}
