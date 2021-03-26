using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataVisualizer : MonoBehaviour
{
    public Neighbourhood neighbourhoodRepresenting;
    public GameObject visualizationAgent;
    public GameObject agentLabel;

    Transform agentTransform;
    Transform agentLabelTransform;
    public AnimationCurve scaleCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
    public float agentHeightMultiplier;
    bool scaleAnimating;
    float timeElapsedSinceScaleAnimationStart;
    Vector3 initialAgentLocalScale;
    Vector3 targetAgentLocalScale;

    Material agentMaterial;
    public AnimationCurve colourCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
    bool colourAnimating;
    float timeElapsedSinceColourAnimationStart;
    Color initialAgentColour;
    Color targetAgentColour;

    // Start is called before the first frame update
    void Start()
    {
        agentTransform = visualizationAgent.transform;
        agentLabelTransform = agentLabel.transform;
        agentMaterial = visualizationAgent.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (scaleAnimating)
        {
            timeElapsedSinceScaleAnimationStart += Time.deltaTime;
            agentTransform.localScale = Vector3.LerpUnclamped(initialAgentLocalScale, targetAgentLocalScale, scaleCurve.Evaluate(timeElapsedSinceScaleAnimationStart));
            //Position offset due to scale change
            agentTransform.localPosition = new Vector3(agentTransform.localPosition.x, agentTransform.localScale.y / 2, agentTransform.localPosition.z);
            agentLabelTransform.localPosition = new Vector3(agentTransform.localPosition.x, agentTransform.localScale.y + agentLabelTransform.localScale.y / 2, agentTransform.localPosition.z);
            if (timeElapsedSinceScaleAnimationStart >= scaleCurve[scaleCurve.length - 1].time)
            {
                scaleAnimating = false;
                timeElapsedSinceScaleAnimationStart = 0;
            }
        }
        if (colourAnimating)
        {
            timeElapsedSinceColourAnimationStart += Time.deltaTime;
            agentMaterial.color = Color.Lerp(initialAgentColour, targetAgentColour, colourCurve.Evaluate(timeElapsedSinceColourAnimationStart));
            if (timeElapsedSinceColourAnimationStart >= colourCurve[colourCurve.length - 1].time)
            {
                colourAnimating = false;
                timeElapsedSinceColourAnimationStart = 0;
            }
        }
    }

    public void VisualizeDatumByHeight(CaseDataType caseAttribute)
    {
        int caseTypeIndex = (int)caseAttribute;

        initialAgentLocalScale = agentTransform.localScale;
        float targetAgentHeight = agentHeightMultiplier * neighbourhoodRepresenting.caseCountData[caseTypeIndex] / Neighbourhood.NeighbourhoodWithMaxCaseCount(caseAttribute, false).caseCountData[caseTypeIndex];
        targetAgentLocalScale = new Vector3(agentTransform.localScale.x, targetAgentHeight, agentTransform.localScale.z);
        scaleAnimating = true;
    }

    public void VisualizeDatumByColour(CaseDataType caseAttribute)
    {
        int caseTypeIndex = (int)caseAttribute;

        initialAgentColour = agentMaterial.color;
        float targetAgentColourGB = 1 - ((float)neighbourhoodRepresenting.caseCountData[caseTypeIndex] / (float)Neighbourhood.NeighbourhoodWithMaxCaseCount(caseAttribute, false).caseCountData[caseTypeIndex]);
        targetAgentColour = new Color(1, targetAgentColourGB, targetAgentColourGB);
        colourAnimating = true;
    }

    public void DevisualizeDatum()
    {
        agentTransform.localScale = new Vector3(agentTransform.localScale.x, 0.1f, agentTransform.localScale.z);
        agentTransform.localPosition = new Vector3(agentTransform.localPosition.x, agentTransform.localScale.y / 2, agentTransform.localPosition.z);
        agentLabelTransform.localPosition = new Vector3(0, agentLabelTransform.localScale.y / 2, 0);
        visualizationAgent.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
    }
}
