using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelinePPButton : MonoBehaviour
{
    TimelinePlayer _timelinePlayer;

    private void Start()
    {
        _timelinePlayer = transform.parent.GetComponent<TimelinePlayer>();
    }

    public void OnClick()
    {
        //If timeline is playing, pause it.
        if (_timelinePlayer.currentTimelineState == TimelinePlayer.TimelineState.Started)
        {
            _timelinePlayer.TransferFromStartedToPaused();
        }
        //If timeline is paused, resume it.
        else if (_timelinePlayer.currentTimelineState == TimelinePlayer.TimelineState.Paused)
        {
            _timelinePlayer.TransferFromPausedToStarted();
        }
        //If timeline is stopped, play it from the beginning.
        else if (_timelinePlayer.currentTimelineState == TimelinePlayer.TimelineState.Stopped)
        {
            _timelinePlayer.TransferFromStoppedToStarted();
        }
    }
}