using System.Collections;
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
    public void PlayTimeline()
    {
        StartCoroutine(StartDaySequence());
    }

    public IEnumerator StartDaySequence()
    {
        //How long will it take to visualize a day's data.
        float animationLengthForADay = 1 / daysVisualizedPerSecond;

        for (DateTime i = Neighbourhood.firstEpisodeDate; i <= Neighbourhood.lastEpisodeDate; i = i.AddDays(1))
        {
            foreach (MapPin mapPin in mapPinLayer.MapPins)
            {
                DataVisualizer visualizer = mapPin.GetComponent<DataVisualizer>();
                if (visualizer.neighbourhoodRepresenting.episodeDays.ContainsKey(i))
                {
                    StartCoroutine(visualizer.VisualizeDatumByHeight(caseDataTypeRepresenting, visualizer.neighbourhoodRepresenting.episodeDays[i], animationLengthForADay));
                    StartCoroutine(visualizer.VisualizeDatumByColour(caseDataTypeRepresenting, visualizer.neighbourhoodRepresenting.episodeDays[i], animationLengthForADay));
                }
            }
            yield return new WaitForSeconds(animationLengthForADay);
        }
        Debug.Log("end!");
    }
}
