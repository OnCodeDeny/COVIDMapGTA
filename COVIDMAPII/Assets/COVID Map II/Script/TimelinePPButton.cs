using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.Maps.Unity;
using System;
using TMPro;

public class TimelinePPButton : MonoBehaviour
{
    //How many days are visualized per second, this is the timeline play speed.
    public float daysVisualizedPerSecond;

    public TMP_Dropdown dropdown;
    public MapPinLayer mapPinLayer;
    CaseDataTypeForDay _caseDataTypeRepresenting;
    DataVisualizer[] _dataVisualizers;

    private void Start()
    {
        _dataVisualizers = new DataVisualizer[mapPinLayer.MapPins.Count];
        for (int i = 0; i < mapPinLayer.MapPins.Count; i++)
        {
            _dataVisualizers[i]= mapPinLayer.MapPins[i].GetComponent<DataVisualizer>();
        }
    }

    public void PlayTimeline()
    {
        _caseDataTypeRepresenting = (CaseDataTypeForDay)dropdown.value;

        foreach (DataVisualizer dataVisualizer in _dataVisualizers)
        {
            dataVisualizer.DevisualizeDatum();
        }
        StartCoroutine(StartDaySequence());
    }

    public IEnumerator StartDaySequence()
    {
        //Calculate how long it will take to visualize a day's data
        float animationLengthForADay = 1f / daysVisualizedPerSecond;

        for (DateTime i = Neighbourhood.firstEpisodeDate; i <= Neighbourhood.lastEpisodeDate; i = i.AddDays(1))
        {
            foreach (DataVisualizer dataVisualizer in _dataVisualizers)
            {
                StartCoroutine(dataVisualizer.VisualizeDatumByHeight(_caseDataTypeRepresenting, dataVisualizer.neighbourhoodRepresenting.episodeDays[i], animationLengthForADay));
                StartCoroutine(dataVisualizer.VisualizeDatumByColour(_caseDataTypeRepresenting, dataVisualizer.neighbourhoodRepresenting.episodeDays[i], animationLengthForADay));
            }
            yield return new WaitForSeconds(animationLengthForADay);
        }
    }
}
