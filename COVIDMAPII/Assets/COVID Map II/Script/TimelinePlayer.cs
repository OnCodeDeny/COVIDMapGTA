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

    public TMP_Dropdown dropdown;
    public MapPinLayer mapPinLayer;
    CaseDataTypeForDay _caseDataTypePresenting;
    DataVisualizer[] _dataVisualizers;
    public TMP_Text pPButtonText;
    IEnumerator _runDaySequence;

    //How many days are visualized per second, this is the timeline play speed.
    public float daysVisualizedPerSecond;

    private void Start()
    {
        _runDaySequence = RunDaySequence();

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
        _caseDataTypePresenting = (CaseDataTypeForDay)dropdown.value;
        _runDaySequence = RunDaySequence();
        StartCoroutine(_runDaySequence);
    }

    void DevisualizeData()
    {
        foreach (DataVisualizer dataVisualizer in _dataVisualizers)
        {
            dataVisualizer.DevisualizeDatum();
        }
    }

    IEnumerator RunDaySequence()
    {
        //Calculate how long it will take to visualize a day's data
        float animationLengthForADay = 1f / daysVisualizedPerSecond;

        for (DateTime i = Neighbourhood.firstEpisodeDate; i <= Neighbourhood.lastEpisodeDate; i = i.AddDays(1))
        {
            foreach (DataVisualizer dataVisualizer in _dataVisualizers)
            {
                StartCoroutine(dataVisualizer.VisualizeDatumByHeight(_caseDataTypePresenting, dataVisualizer.neighbourhoodRepresenting.episodeDays[i], animationLengthForADay));
                StartCoroutine(dataVisualizer.VisualizeDatumByColour(_caseDataTypePresenting, dataVisualizer.neighbourhoodRepresenting.episodeDays[i], animationLengthForADay));
            }

            yield return new WaitForSeconds(animationLengthForADay);
        }
        TransferToStopped(false);
    }
}
