using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataVisualizer : MonoBehaviour
{
    public GameObject visualizationAgent;
    public Neighbourhood neighbourhoodRepresenting;
    public float heightMultiplier;
    Transform agentTransform;

    // Start is called before the first frame update
    void Start()
    {
        agentTransform = visualizationAgent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VisualizeDatumByHeight(CaseDataType caseAttribute)
    {
        int caseTypeIndex = (int)caseAttribute;
        float height = heightMultiplier * neighbourhoodRepresenting.caseCountData[caseTypeIndex] / Neighbourhood.NeighbourhoodWithMaxCaseCount(caseAttribute, false).caseCountData[caseTypeIndex];
        agentTransform.localScale = new Vector3(agentTransform.localScale.x, height, agentTransform.localScale.z);
        agentTransform.localPosition = new Vector3(agentTransform.localPosition.x, agentTransform.localScale.y / 2, agentTransform.localPosition.z);
    }
    public void VisualizeDatumByColour(CaseDataType caseAttribute)
    {
        int caseTypeIndex = (int)caseAttribute;
        float colourGB = 1 - ((float)neighbourhoodRepresenting.caseCountData[caseTypeIndex] / (float)Neighbourhood.NeighbourhoodWithMaxCaseCount(caseAttribute, false).caseCountData[caseTypeIndex]);
        visualizationAgent.GetComponent<Renderer>().material.color = new Color(1, colourGB, colourGB);
    }
    public void DevisualizeDatum()
    {
        agentTransform.localScale = new Vector3(agentTransform.localScale.x, 0.1f, agentTransform.localScale.z);
        agentTransform.localPosition = new Vector3(agentTransform.localPosition.x, agentTransform.localScale.y / 2, agentTransform.localPosition.z);
        visualizationAgent.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
    }
}
