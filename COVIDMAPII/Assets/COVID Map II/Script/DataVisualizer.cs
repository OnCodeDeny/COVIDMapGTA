using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataVisualizer : MonoBehaviour
{
    [SerializeField]
    bool visualized;

    public Neighbourhood neighbourhoodRepresenting;

    public GameObject visualizationAgent;
    public GameObject agentLabel;

    public float agentHeightMultiplier;
    Transform _agentTransform;
    Transform _agentLabelTransform;
    public AnimationCurve scaleCurve = AnimationCurve.EaseInOut(0f, 0f, 0.5f, 1f);

    Renderer _agentRenderer;
    public AnimationCurve colourCurve = AnimationCurve.EaseInOut(0f, 0f, 0.5f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        _agentTransform = visualizationAgent.transform;
        _agentLabelTransform = agentLabel.transform;

        _agentRenderer = visualizationAgent.GetComponent<Renderer>();
    }

    public IEnumerator VisualizeDatumByHeight(NeighbourhoodDailyCaseDataType caseType, Day day, float animationLength)
    {
        visualized = true;
        int caseTypeIndex = (int)caseType;

        float timeElapsedInAnimation = 0;
        float progressPercentage = 0;
        Vector3 initialAgentLocalScale = _agentTransform.localScale;
        float targetAgentHeight = agentHeightMultiplier * day.caseCountData[caseTypeIndex] / Neighbourhood.maxNeighbourhoodDailyCaseCountData[caseTypeIndex];
        Vector3 targetAgentLocalScale = new Vector3(_agentTransform.localScale.x, targetAgentHeight, _agentTransform.localScale.z);

        //Detect if animation is needed
        if (initialAgentLocalScale != targetAgentLocalScale)
        {
            //Enable renderer and animate to target
            _agentRenderer.enabled = true;

            while (progressPercentage < 1 && visualized)
            {
                timeElapsedInAnimation += Time.deltaTime;
                progressPercentage = timeElapsedInAnimation / animationLength;
                _agentTransform.localScale = Vector3.Lerp(initialAgentLocalScale, targetAgentLocalScale, progressPercentage);
                //Position offset due to scale change
                _agentTransform.localPosition = new Vector3(_agentTransform.localPosition.x, _agentTransform.localScale.y / 2, _agentTransform.localPosition.z);
                _agentLabelTransform.localPosition = new Vector3(_agentTransform.localPosition.x, _agentTransform.localScale.y + _agentLabelTransform.localScale.y / 2, _agentTransform.localPosition.z);

                yield return null;
            }
        }
        //In case animation is not needed, enable renderer if there are cases to show
        else if (day.caseCountData[caseTypeIndex] > 0)
        {
            _agentRenderer.enabled = true;
        }

        //If renderer is enabled when agent scale y is <= 0, ugly black area will appear
        if (_agentTransform.localScale.y <= 0)
        {
            _agentRenderer.enabled = false;
        }
    }

    public IEnumerator VisualizeDatumByColour(NeighbourhoodDailyCaseDataType caseType, Day day, float animationLength)
    {
        visualized = true;
        int caseTypeIndex = (int)caseType;

        float timeElapsedInAnimation = 0;
        float progressPercentage = 0;
        Color initialAgentColour = _agentRenderer.material.color;
        float targetAgentColourGB = 1 - ((float)day.caseCountData[caseTypeIndex] / (float)Neighbourhood.maxNeighbourhoodDailyCaseCountData[caseTypeIndex]);
        Color targetAgentColour = new Color(1, targetAgentColourGB, targetAgentColourGB);

        //Detect if animation is needed
        if (initialAgentColour != targetAgentColour)
        {
            //Enable renderer and animate to target
            _agentRenderer.enabled = true;

            while (progressPercentage < 1 && visualized)
            {
                timeElapsedInAnimation += Time.deltaTime;
                progressPercentage = timeElapsedInAnimation / animationLength;
                _agentRenderer.material.color = Color.Lerp(initialAgentColour, targetAgentColour, progressPercentage);

                yield return null;
            }
        }
        //In case animation is not needed, enable renderer if there are cases to show
        else if (day.caseCountData[caseTypeIndex] > 0)
        {
            _agentRenderer.enabled = true;
        }

        //Disable renderer when there's no case to show to avoid confusion
        if (day.caseCountData[caseTypeIndex] <= 0)
        {
            _agentRenderer.enabled = false;
        }
    }

    public IEnumerator VisualizeDatumByHeight(NeighbourhoodCaseDataType caseType)
    {
        visualized = true;
        _agentRenderer.enabled = true;
        int caseTypeIndex = (int)caseType;

        float timeElapsedInAnimation = 0;
        Vector3 initialAgentLocalScale = _agentTransform.localScale;
        float targetAgentHeight = agentHeightMultiplier * neighbourhoodRepresenting.caseCountData[caseTypeIndex] / Neighbourhood.NeighbourhoodWithMaxCaseCount(caseType, false).caseCountData[caseTypeIndex];
        Vector3 targetAgentLocalScale = new Vector3(_agentTransform.localScale.x, targetAgentHeight, _agentTransform.localScale.z);

        while (timeElapsedInAnimation < scaleCurve[scaleCurve.length - 1].time && visualized)
        {
            if (gameObject.activeSelf)
            {
                timeElapsedInAnimation += Time.deltaTime;
                _agentTransform.localScale = Vector3.LerpUnclamped(initialAgentLocalScale, targetAgentLocalScale, scaleCurve.Evaluate(timeElapsedInAnimation));
                //Position offset due to scale change
                _agentTransform.localPosition = new Vector3(_agentTransform.localPosition.x, _agentTransform.localScale.y / 2, _agentTransform.localPosition.z);
                _agentLabelTransform.localPosition = new Vector3(_agentTransform.localPosition.x, _agentTransform.localScale.y + _agentLabelTransform.localScale.y / 2, _agentTransform.localPosition.z);
            }
            yield return null;
        }
    }

    public IEnumerator VisualizeDatumByColour(NeighbourhoodCaseDataType caseType)
    {
        visualized = true;
        _agentRenderer.enabled = true;
        int caseTypeIndex = (int)caseType;

        float timeElapsedInAnimation = 0;
        Color initialAgentColour = _agentRenderer.material.color;
        float targetAgentColourGB = 1 - ((float)neighbourhoodRepresenting.caseCountData[caseTypeIndex] / (float)Neighbourhood.NeighbourhoodWithMaxCaseCount(caseType, false).caseCountData[caseTypeIndex]);
        Color targetAgentColour = new Color(1, targetAgentColourGB, targetAgentColourGB);

        while (timeElapsedInAnimation < colourCurve[colourCurve.length - 1].time && visualized)
        {
            if (gameObject.activeSelf)
            {
                timeElapsedInAnimation += Time.deltaTime;
                _agentRenderer.material.color = Color.Lerp(initialAgentColour, targetAgentColour, colourCurve.Evaluate(timeElapsedInAnimation));
            }
            yield return null;
        }
    }

    public void DevisualizeDatum()
    {
        _agentTransform.localScale = new Vector3(_agentTransform.localScale.x, 0.1f, _agentTransform.localScale.z);
        _agentTransform.localPosition = new Vector3(_agentTransform.localPosition.x, 0, _agentTransform.localPosition.z);
        _agentLabelTransform.localPosition = new Vector3(0, _agentLabelTransform.localScale.y / 2, 0);
        visualizationAgent.GetComponent<Renderer>().material.color = Color.cyan;
        _agentRenderer.enabled = true;
        visualized = false;
    }
}
