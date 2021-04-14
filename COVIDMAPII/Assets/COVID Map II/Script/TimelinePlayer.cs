using Microsoft.Maps.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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

    //How many days are visualized per second, this is the timeline play speed
    //It will take speed control slider's value if provided, if the speed control slider is missing, it will use its default value set here
    float _daysVisualizedPerSecond = 15;
    //Calculate how long it will take to visualize a day's data
    float _animationLengthForADay;

    public TMP_Text playbackSpeedText;

    //For manipulating date jump buttons
    public Button jumpToNextDayButton;
    public Button jumpToNextMonthButton;
    public Button jumpToNextYearButton;
    public Button jumpToLastDayButton;
    public Button jumpToLastMonthButton;
    public Button jumpToLastYearButton;

    //Event is invoked on visualized day/presentingDate change
    public UnityEvent OnDayChange;

    private void Start()
    {
        caseDataTypePresenting = (NeighbourhoodDailyCaseDataType)dropdown.value;

        _animationLengthForADay = 1f / _daysVisualizedPerSecond;

        _runDaySequence = VisualizeHistoryDaysData(Neighbourhood.firstEpisodeDate, Neighbourhood.lastEpisodeDate);

        _dataVisualizers = new DataVisualizer[mapPinLayer.MapPins.Count];
        for (int i = 0; i < mapPinLayer.MapPins.Count; i++)
        {
            _dataVisualizers[i] = mapPinLayer.MapPins[i].GetComponent<DataVisualizer>();
        }
    }

    public void JumpToNextDay()
    {
        DateTime targetDate = presentingDate.AddDays(1);
        JumpToDate(targetDate);
    }
    public void JumpToNextMonth()
    {
        DateTime targetDate = presentingDate.AddMonths(1);
        JumpToDate(targetDate);
    }
    public void JumpToNextYear()
    {
        DateTime targetDate = presentingDate.AddYears(1);
        JumpToDate(targetDate);
    }
    public void JumpToLastDay()
    {
        DateTime targetDate = presentingDate.AddDays(-1);
        JumpToDate(targetDate);
    }
    public void JumpToLastMonth()
    {
        DateTime targetDate = presentingDate.AddMonths(-1);
        JumpToDate(targetDate);
    }
    public void JumpToLastYear()
    {
        DateTime targetDate = presentingDate.AddYears(-1);
        JumpToDate(targetDate);
    }

    public void JumpToDate(DateTime targetDate)
    {
        if (targetDate >= Neighbourhood.firstEpisodeDate && targetDate <= Neighbourhood.lastEpisodeDate)
        {
            StopCoroutine(_runDaySequence);
            presentingDate = targetDate;
            VisualizeSingleDayData(targetDate);
            dateText.text = targetDate.ToString("d");
            OnDayChange.Invoke();
        }
        if (currentTimelineState==TimelineState.Started)
        {
            StartTimelineFromPresentingDate();
        }
    }

    public void DetermineJumpToDateButtonsState()
    {
        if (presentingDate == default)
        {
            jumpToNextDayButton.interactable = false;
            jumpToNextMonthButton.interactable = false;
            jumpToNextYearButton.interactable = false;
            jumpToLastDayButton.interactable = false;
            jumpToLastMonthButton.interactable = false;
            jumpToLastYearButton.interactable = false;
            return;
        }

        if (presentingDate.AddDays(1) > Neighbourhood.lastEpisodeDate)
        {
            jumpToNextDayButton.interactable = false;
            jumpToNextMonthButton.interactable = false;
            jumpToNextYearButton.interactable = false;
        }
        else
        {
            jumpToNextDayButton.interactable = true;
            if (presentingDate.AddMonths(1) > Neighbourhood.lastEpisodeDate)
            {
                jumpToNextMonthButton.interactable = false;
                jumpToNextYearButton.interactable = false;
            }
            else
            {
                jumpToNextMonthButton.interactable = true;
                if (presentingDate.AddYears(1) > Neighbourhood.lastEpisodeDate)
                {
                    jumpToNextYearButton.interactable = false;
                }
                else
                {
                    jumpToNextYearButton.interactable = true;
                }
            }
        }

        if (presentingDate.AddDays(-1) < Neighbourhood.firstEpisodeDate)
        {
            jumpToLastDayButton.interactable = false;
            jumpToLastMonthButton.interactable = false;
            jumpToLastYearButton.interactable = false;
        }
        else
        {
            jumpToLastDayButton.interactable = true;
            if (presentingDate.AddMonths(-1) < Neighbourhood.firstEpisodeDate)
            {
                jumpToLastMonthButton.interactable = false;
                jumpToLastYearButton.interactable = false;
            }
            else
            {
                jumpToLastMonthButton.interactable = true;
                if (presentingDate.AddYears(-1) < Neighbourhood.firstEpisodeDate)
                {
                    jumpToLastYearButton.interactable = false;
                }
                else
                {
                    jumpToLastYearButton.interactable = true;
                }
            }
        }
    }

    public void SetPlaybackSpeed(float speed)
    {
        _daysVisualizedPerSecond = speed;
        _animationLengthForADay = 1f / _daysVisualizedPerSecond;
        if(speed>1)
        playbackSpeedText.text = speed.ToString() + " Days Per Second";
        else
            playbackSpeedText.text = speed.ToString() + " Day Per Second";
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
        StartTimelineFromPresentingDate();
        pPButtonText.text = "PAUSE";
    }

    public void TransferFromStoppedToStarted()
    {
        currentTimelineState = TimelineState.Started;
        if (presentingDate > Neighbourhood.firstEpisodeDate && presentingDate < Neighbourhood.lastEpisodeDate)
        {
            StartTimelineFromPresentingDate();
        }
        else
        {
            StartTimelineFromBeginning();
        }
        pPButtonText.text = "PAUSE";
    }

    public void TransferToStopped(bool manuallyStopped)
    {
        currentTimelineState = TimelineState.Stopped;
        StopCoroutine(_runDaySequence);
        if (manuallyStopped)
        {
            presentingDate = default;
            DevisualizeData();
            OnDayChange.Invoke();
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
        _runDaySequence = VisualizeHistoryDaysData(Neighbourhood.firstEpisodeDate, Neighbourhood.lastEpisodeDate);
        StartCoroutine(_runDaySequence);
    }

    public void StartTimelineFromPresentingDate()
    {
        if (currentTimelineState == TimelineState.Paused)
        {
            StartCoroutine(_runDaySequence);
        }
        else
        {
            _runDaySequence = VisualizeHistoryDaysData(presentingDate, Neighbourhood.lastEpisodeDate);
            StartCoroutine(_runDaySequence);
        }
    }

    void DevisualizeData()
    {
        foreach (DataVisualizer dataVisualizer in _dataVisualizers)
        {
            dataVisualizer.DevisualizeDatum();
        }
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
        for (DateTime i = startDate; i <= endDate; i = i.AddDays(1))
        {
            presentingDate = i;
            dateText.text = i.ToString("d");
            OnDayChange.Invoke();

            foreach (DataVisualizer dataVisualizer in _dataVisualizers)
            {
                StartCoroutine(dataVisualizer.VisualizeDatumByHeight(caseDataTypePresenting, dataVisualizer.neighbourhoodRepresenting.episodeDays[i], _animationLengthForADay));
                StartCoroutine(dataVisualizer.VisualizeDatumByColour(caseDataTypePresenting, dataVisualizer.neighbourhoodRepresenting.episodeDays[i], _animationLengthForADay));
            }

            yield return new WaitForSeconds(_animationLengthForADay);
        }
        TransferToStopped(false);
    }

    void VisualizeSingleDayData(DateTime targetDate)
    {
        foreach (DataVisualizer dataVisualizer in _dataVisualizers)
        {
            StartCoroutine(dataVisualizer.VisualizeDatumByHeight(caseDataTypePresenting, dataVisualizer.neighbourhoodRepresenting.episodeDays[targetDate], _animationLengthForADay));
            StartCoroutine(dataVisualizer.VisualizeDatumByColour(caseDataTypePresenting, dataVisualizer.neighbourhoodRepresenting.episodeDays[targetDate], _animationLengthForADay));
        }
    }
}
