using Microsoft.Maps.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimelinePlayer : MonoBehaviour
{
    public enum TimelineState
    {
        Started,
        Stopped,
        Paused
    }

    public TimelineState currentTimelineState = TimelineState.Stopped;
    public NeighbourhoodDailyCaseDataType caseDataTypePresenting;
    public DateTime presentingDate;

    public TMP_Dropdown dropdown;
    public TMP_Text pPButtonText;
    public TMP_Text dateText;

    public MapPinLayer mapPinLayer;
    DataVisualizer[] _dataVisualizers;
    IEnumerator _runDaySequence;

    //How many days are visualized per second, this is the timeline play speed.
    public float daysVisualizedPerSecond;

    private void Start()
    {
        _runDaySequence = VisualizeHistoryDaysData(Neighbourhood.firstEpisodeDate, Neighbourhood.lastEpisodeDate);

        _dataVisualizers = new DataVisualizer[mapPinLayer.MapPins.Count];
        for (int i = 0; i < mapPinLayer.MapPins.Count; i++)
        {
            _dataVisualizers[i] = mapPinLayer.MapPins[i].GetComponent<DataVisualizer>();
        }
    }

    public void TransferFromStartedToPaused()
    {
        currentTimelineState = TimelineState.Paused;
        StopCoroutine(_runDaySequence);
        pPButtonText.text = "PLAY";
    }

    public void TransferFromPausedToStarted()
    {
        currentTimelineState = TimelineState.Started;
        StartCoroutine(_runDaySequence);
        pPButtonText.text = "PAUSE";
    }

    public void TransferFromStoppedToStarted()
    {
        currentTimelineState = TimelineState.Started;
        StartTimelineFromBeginning();
        pPButtonText.text = "PAUSE";
    }

    public void TransferToStopped(bool manuallyStopped)
    {
        currentTimelineState = TimelineState.Stopped;
        StopCoroutine(_runDaySequence);
        if (manuallyStopped)
        {
            DevisualizeData();
            dateText.text = "MM/DD/YYYY";
            pPButtonText.text = "PLAY";
        }
        else
        {
            pPButtonText.text = "REPLAY";
        }
    }

    public void StartTimelineFromBeginning()
    {
        DevisualizeData();
        caseDataTypePresenting = (NeighbourhoodDailyCaseDataType)dropdown.value;
        _runDaySequence = VisualizeHistoryDaysData(Neighbourhood.firstEpisodeDate, Neighbourhood.lastEpisodeDate);
        StartCoroutine(_runDaySequence);
    }

    void DevisualizeData()
    {
        foreach (DataVisualizer dataVisualizer in _dataVisualizers)
        {
            dataVisualizer.DevisualizeDatum();
        }
        presentingDate = default;
    }

    public void OnChangeChosenVisualizedDataType()
    {
        if (currentTimelineState != TimelineState.Started && presentingDate != default)
        {
            VisualizeSingleDayData(presentingDate);
        }
    }

    IEnumerator VisualizeHistoryDaysData(DateTime startDate, DateTime endDate)
    {
        //Calculate how long it will take to visualize a day's data
        float animationLengthForADay = 1f / daysVisualizedPerSecond;

        for (DateTime i = startDate; i <= endDate; i = i.AddDays(1))
        {
            presentingDate = i;
            dateText.text = i.ToString("d");

            foreach (DataVisualizer dataVisualizer in _dataVisualizers)
            {
                StartCoroutine(dataVisualizer.VisualizeDatumByHeight(caseDataTypePresenting, dataVisualizer.neighbourhoodRepresenting.episodeDays[i], animationLengthForADay));
                StartCoroutine(dataVisualizer.VisualizeDatumByColour(caseDataTypePresenting, dataVisualizer.neighbourhoodRepresenting.episodeDays[i], animationLengthForADay));
            }

            yield return new WaitForSeconds(animationLengthForADay);
        }
        TransferToStopped(false);
    }

    void VisualizeSingleDayData(DateTime targetDate)
    {
        //Calculate how long it will take to visualize a day's data
        float animationLengthForADay = 1f / daysVisualizedPerSecond;

        foreach (DataVisualizer dataVisualizer in _dataVisualizers)
        {
            StartCoroutine(dataVisualizer.VisualizeDatumByHeight(caseDataTypePresenting, dataVisualizer.neighbourhoodRepresenting.episodeDays[targetDate], animationLengthForADay));
            StartCoroutine(dataVisualizer.VisualizeDatumByColour(caseDataTypePresenting, dataVisualizer.neighbourhoodRepresenting.episodeDays[targetDate], animationLengthForADay));
        }
    }
}
