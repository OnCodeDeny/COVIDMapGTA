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

    Material agentMaterial;
    public AnimationCurve colourCurve = AnimationCurve.EaseInOut(0f, 0f, 0.5f, 1f);

    public float timeToVisualizeADay;

    // Start is called before the first frame update
    void Start()
    {
        agentTransform = visualizationAgent.transform;
        agentLabelTransform = agentLabel.transform;
        agentMaterial = visualizationAgent.GetComponent<Renderer>().material;
    }

    public IEnumerator VisualizeDatumByHeight(CaseDataTypeForDay caseType, Day day)
    {
        int caseTypeIndex = (int)caseType;

        for (DateTime i = Neighbourhood.firstEpisodeDate; i <= Neighbourhood.lastEpisodeDate; i = i.AddDays(1))
        {
            if (neighbourhoodRepresenting.episodeDays.ContainsKey(i))
            {
                float timeElapsedInAnimation = 0;
                float percentage;
                Vector3 initialAgentLocalScale = agentTransform.localScale;
                float targetAgentHeight = agentHeightMultiplier * neighbourhoodRepresenting.episodeDays[i].caseCountData[caseTypeIndex] / Neighbourhood.maxPlaceDayCaseCount[caseTypeIndex];

                Vector3 targetAgentLocalScale = new Vector3(agentTransform.localScale.x, targetAgentHeight, agentTransform.localScale.z);

                do
                {
                    timeElapsedInAnimation += Time.deltaTime;
                    percentage = timeElapsedInAnimation / timeToVisualizeADay;
                    agentTransform.localScale = Vector3.Lerp(initialAgentLocalScale, targetAgentLocalScale, percentage);
                    //Position offset due to scale change
                    agentTransform.localPosition = new Vector3(agentTransform.localPosition.x, agentTransform.localScale.y / 2, agentTransform.localPosition.z);
                    agentLabelTransform.localPosition = new Vector3(agentTransform.localPosition.x, agentTransform.localScale.y + agentLabelTransform.localScale.y / 2, agentTransform.localPosition.z);

                    yield return null;
                } while (percentage < 1);
            }
        }
    }

    public IEnumerator VisualizeDatumByHeight(CaseDataTypeForNeighbourhood caseType)
    {
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
        int caseTypeIndex = (int)caseType;

        float timeElapsedInAnimation = 0;
        Color initialAgentColour = agentMaterial.color;
        float targetAgentColourGB = 1 - ((float)neighbourhoodRepresenting.caseCountData[caseTypeIndex] / (float)Neighbourhood.NeighbourhoodWithMaxCaseCount(caseType, false).caseCountData[caseTypeIndex]);
        Color targetAgentColour = new Color(1, targetAgentColourGB, targetAgentColourGB);

        do
        {
            if (gameObject.activeSelf)
            {
                timeElapsedInAnimation += Time.deltaTime;
                agentMaterial.color = Color.Lerp(initialAgentColour, targetAgentColour, colourCurve.Evaluate(timeElapsedInAnimation));
            }
            yield return null;
        } while (timeElapsedInAnimation < colourCurve[colourCurve.length - 1].time);
    }

    public void DevisualizeDatum()
    {
        agentTransform.localScale = new Vector3(agentTransform.localScale.x, 0.1f, agentTransform.localScale.z);
        agentTransform.localPosition = new Vector3(agentTransform.localPosition.x, agentTransform.localScale.y / 2, agentTransform.localPosition.z);
        agentLabelTransform.localPosition = new Vector3(0, agentLabelTransform.localScale.y / 2, 0);
        visualizationAgent.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
    }
}
