﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.Maps.Unity;
using System;

public class TimelinePlayButton : MonoBehaviour
{
    public MapPinLayer mapPinLayer;
    public CaseDataTypeForDay caseDataTypeRepresenting;
    //How many days are visualized per second, this is the timeline playback speed.
    public float daysVisualizedPerSecond;

    DataVisualizer[] dataVisualizers;

    private void Start()
    {
        dataVisualizers = new DataVisualizer[mapPinLayer.MapPins.Count];
        for (int i = 0; i < mapPinLayer.MapPins.Count; i++)
        {
            dataVisualizers[i]= mapPinLayer.MapPins[i].GetComponent<DataVisualizer>();
        }
    }

    public void PlayTimeline()
    {
        foreach (DataVisualizer dataVisualizer in dataVisualizers)
        {
            dataVisualizer.DevisualizeDatum(true);
        }
        StartCoroutine(StartDaySequence());
    }

    public IEnumerator StartDaySequence()
    {
        //How long will it take to visualize a day's data.
        float animationLengthForADay = 1f / daysVisualizedPerSecond;

        for (DateTime i = Neighbourhood.firstEpisodeDate; i <= Neighbourhood.lastEpisodeDate; i = i.AddDays(1))
        {
            foreach (DataVisualizer dataVisualizer in dataVisualizers)
            {
                if (dataVisualizer.neighbourhoodRepresenting.episodeDays.ContainsKey(i))
                {
                    StartCoroutine(dataVisualizer.VisualizeDatumByHeight(caseDataTypeRepresenting, dataVisualizer.neighbourhoodRepresenting.episodeDays[i], animationLengthForADay));
                    StartCoroutine(dataVisualizer.VisualizeDatumByColour(caseDataTypeRepresenting, dataVisualizer.neighbourhoodRepresenting.episodeDays[i], animationLengthForADay));
                }
            }
            yield return new WaitForSeconds(animationLengthForADay);
        }
    }
}
