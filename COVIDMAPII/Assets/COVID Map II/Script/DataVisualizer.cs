using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataVisualizer : MonoBehaviour
{
    public Neighbourhood neighbourhoodRepresenting;
    public GameObject visualizationAgent;
    public GameObject agentLabel;
    public DataLoader dataLoader;

    public float agentHeightMultiplier;
    Transform agentTransform;
    Transform agentLabelTransform;
    public AnimationCurve scaleCurve = AnimationCurve.EaseInOut(0f, 0f, 0.5f, 1f);

    Renderer agentRenderer;
    public AnimationCurve colourCurve = AnimationCurve.EaseInOut(0f, 0f, 0.5f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        agentTransform = visualizationAgent.transform;
        agentLabelTransform = agentLabel.transform;

        agentRenderer = visualizationAgent.GetComponent<Renderer>();
    }

    public IEnumerator VisualizeDatumByHeight(CaseDataTypeForDay caseType, Day day, float animationLength)
    {
        int caseTypeIndex = (int)caseType;

        float timeElapsedInAnimation = 0;
        float progressPercentage = 0;
        Vector3 initialAgentLocalScale = agentTransform.localScale;
        float targetAgentHeight = agentHeightMultiplier * day.caseCountData[caseTypeIndex] / Neighbourhood.maxNeighbourhoodDailyCaseCountData[caseTypeIndex];
        Vector3 targetAgentLocalScale = new Vector3(agentTransform.localScale.x, targetAgentHeight, agentTransform.localScale.z);

        //Detect if animation is needed
        if (initialAgentLocalScale != targetAgentLocalScale)
        {
            //Enable renderer and animate to target
            agentRenderer.enabled = true;

            while (progressPercentage < 1)
            {
                timeElapsedInAnimation += Time.deltaTime;
                progressPercentage = timeElapsedInAnimation / animationLength;
                agentTransform.localScale = Vector3.Lerp(initialAgentLocalScale, targetAgentLocalScale, progressPercentage);
                //Position offset due to scale change
                agentTransform.localPosition = new Vector3(agentTransform.localPosition.x, agentTransform.localScale.y / 2, agentTransform.localPosition.z);
                agentLabelTransform.localPosition = new Vector3(agentTransform.localPosition.x, agentTransform.localScale.y + agentLabelTransform.localScale.y / 2, agentTransform.localPosition.z);

                yield return null;
            }
        }
        //If animation is not needed, enable renderer if there are cases to show
        else if (day.caseCountData[caseTypeIndex] > 0)
        {
            agentRenderer.enabled = true;
        }

        //If renderer is enabled when agent scale y is <= 0, ugly black area will appear.
        if (agentTransform.localScale.y <= 0)
        {
            agentRenderer.enabled = false;
        }
    }

    public IEnumerator VisualizeDatumByColour(CaseDataTypeForDay caseType, Day day, float animationLength)
    {
        int caseTypeIndex = (int)caseType;

        float timeElapsedInAnimation = 0;
        float progressPercentage = 0;
        Color initialAgentColour = agentRenderer.material.color;
        float targetAgentColourGB = 1 - ((float)day.caseCountData[caseTypeIndex] / (float)Neighbourhood.maxNeighbourhoodDailyCaseCountData[caseTypeIndex]);
        Color targetAgentColour = new Color(1, targetAgentColourGB, targetAgentColourGB);

        //Detect if animation is needed
        if (initialAgentColour != targetAgentColour)
        {
            //Enable renderer and animate to target
            agentRenderer.enabled = true;

            while (progressPercentage < 1)
            {
                timeElapsedInAnimation += Time.deltaTime;
                progressPercentage = timeElapsedInAnimation / animationLength;
                agentRenderer.material.color = Color.Lerp(initialAgentColour, targetAgentColour, progressPercentage);

                yield return null;
            }
        }
        //If animation is not needed, enable renderer if there are cases to show
        else if (day.caseCountData[caseTypeIndex] > 0)
        {
            agentRenderer.enabled = true;
        }

        //Disable renderer when there's no case to show to avoid confusion.
        if (day.caseCountData[caseTypeIndex] <= 0)
        {
            agentRenderer.enabled = false;
        }
    }

    public IEnumerator VisualizeDatumByHeight(CaseDataTypeForNeighbourhood caseType)
    {
        agentRenderer.enabled = true;
        int caseTypeIndex = (int)caseType;

        float timeElapsedInAnimation = 0;
        Vector3 initialAgentLocalScale = agentTransform.localScale;
        float targetAgentHeight = agentHeightMultiplier * neighbourhoodRepresenting.caseCountData[caseTypeIndex] / Neighbourhood.NeighbourhoodWithMaxCaseCount(caseType, false).caseCountData[caseTypeIndex];
        Vector3 targetAgentLocalScale = new Vector3(agentTransform.localScale.x, targetAgentHeight, agentTransform.localScale.z);

        do
        {
            if (gameObject.activeSelf)
            {
                timeElapsedInAnimation += Time.deltaTime;
                agentTransform.localScale = Vector3.LerpUnclamped(initialAgentLocalScale, targetAgentLocalScale, scaleCurve.Evaluate(timeElapsedInAnimation));
                //Position offset due to scale change
                agentTransform.localPosition = new Vector3(agentTransform.localPosition.x, agentTransform.localScale.y / 2, agentTransform.localPosition.z);
                agentLabelTransform.localPosition = new Vector3(agentTransform.localPosition.x, agentTransform.localScale.y + agentLabelTransform.localScale.y / 2, agentTransform.localPosition.z);
            }
            yield return null;
        } while (timeElapsedInAnimation < scaleCurve[scaleCurve.length - 1].time);
    }

    public IEnumerator VisualizeDatumByColour(CaseDataTypeForNeighbourhood caseType)
    {
        agentRenderer.enabled = true;
        int caseTypeIndex = (int)caseType;

        float timeElapsedInAnimation = 0;
        Color initialAgentColour = agentRenderer.material.color;
        float targetAgentColourGB = 1 - ((float)neighbourhoodRepresenting.caseCountData[caseTypeIndex] / (float)Neighbourhood.NeighbourhoodWithMaxCaseCount(caseType, false).caseCountData[caseTypeIndex]);
        Color targetAgentColour = new Color(1, targetAgentColourGB, targetAgentColourGB);

        do
        {
            if (gameObject.activeSelf)
            {
                timeElapsedInAnimation += Time.deltaTime;
                agentRenderer.material.color = Color.Lerp(initialAgentColour, targetAgentColour, colourCurve.Evaluate(timeElapsedInAnimation));
            }
            yield return null;
        } while (timeElapsedInAnimation < colourCurve[colourCurve.length - 1].time);
    }

    public void DevisualizeDatum(bool disableRenderer)
    {
        agentTransform.localScale = new Vector3(agentTransform.localScale.x, 0.1f, agentTransform.localScale.z);
        agentTransform.localPosition = new Vector3(agentTransform.localPosition.x, agentTransform.localScale.y / 2, agentTransform.localPosition.z);
        agentLabelTransform.localPosition = new Vector3(0, agentLabelTransform.localScale.y / 2, 0);
        visualizationAgent.GetComponent<Renderer>().material.color = Color.cyan;
        if (disableRenderer)
        {
            agentRenderer.enabled = false;
        }
    }
}
