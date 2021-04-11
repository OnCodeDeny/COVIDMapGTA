using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.Maps.Unity;
using System;
using TMPro;

public class TimelinePPButton : MonoBehaviour
{
    TimelinePlayer _timelinePlayer;

    public TMP_Dropdown dropdown;
    public MapPinLayer mapPinLayer;
    CaseDataTypeForDay _caseDataTypeRepresenting;
    DataVisualizer[] _dataVisualizers;
    TMP_Text buttonText;
    IEnumerator _coroutine;

    private void Start()
    {
        _timelinePlayer = transform.parent.GetComponent<TimelinePlayer>();
        buttonText = GetComponentInChildren<TMP_Text>();
        _coroutine = StartDaySequence();

        _dataVisualizers = new DataVisualizer[mapPinLayer.MapPins.Count];
        for (int i = 0; i < mapPinLayer.MapPins.Count; i++)
        {
            _dataVisualizers[i]= mapPinLayer.MapPins[i].GetComponent<DataVisualizer>();
        }
    }

    public void CheckValue()
    {
        //If timeline is playing, pause it.
        if (_timelinePlayer.currentTimelineState == TimelinePlayer.TimelineState.Started)
        {
            buttonText.text = "PLAY";
            _timelinePlayer.currentTimelineState = TimelinePlayer.TimelineState.Paused;
        }
        //If timeline is paused, resume it.
        else if (_timelinePlayer.currentTimelineState == TimelinePlayer.TimelineState.Paused)
        {
            buttonText.text = "PAUSE";
            _timelinePlayer.currentTimelineState = TimelinePlayer.TimelineState.Started;
        }
        //If timeline is stopped, play it from the beginning.
        else if (_timelinePlayer.currentTimelineState == TimelinePlayer.TimelineState.Stopped)
        {
            buttonText.text = "PAUSE";
            _timelinePlayer.currentTimelineState = TimelinePlayer.TimelineState.Started;
            StopCoroutine(_coroutine);
            StartTimeline();
        }
    }

    void StartTimeline()
    {
        _caseDataTypeRepresenting = (CaseDataTypeForDay)dropdown.value;

        foreach (DataVisualizer dataVisualizer in _dataVisualizers)
        {
            dataVisualizer.DevisualizeDatum();
        }
        _coroutine = StartDaySequence();
        StartCoroutine(_coroutine);
    }

    IEnumerator StartDaySequence()
    {
        //Calculate how long it will take to visualize a day's data
        float animationLengthForADay = 1f / _timelinePlayer.daysVisualizedPerSecond;

        for (DateTime i = Neighbourhood.firstEpisodeDate; i <= Neighbourhood.lastEpisodeDate; i = i.AddDays(1))
        {
            //If the timeline has been stopped, devisualize data and stop day sequence
            if (_timelinePlayer.currentTimelineState == TimelinePlayer.TimelineState.Stopped)
            {
                foreach (DataVisualizer dataVisualizer in _dataVisualizers)
                {
                    dataVisualizer.DevisualizeDatum();
                }
                yield break;
            }

            else if (_timelinePlayer.currentTimelineState == TimelinePlayer.TimelineState.Paused)
            {
                yield return new WaitUntil(() => _timelinePlayer.currentTimelineState == TimelinePlayer.TimelineState.Started);
            }

            foreach (DataVisualizer dataVisualizer in _dataVisualizers)
            {
                StartCoroutine(dataVisualizer.VisualizeDatumByHeight(_caseDataTypeRepresenting, dataVisualizer.neighbourhoodRepresenting.episodeDays[i], animationLengthForADay));
                StartCoroutine(dataVisualizer.VisualizeDatumByColour(_caseDataTypeRepresenting, dataVisualizer.neighbourhoodRepresenting.episodeDays[i], animationLengthForADay));
            }

            yield return new WaitForSeconds(animationLengthForADay);
        }
    }
}