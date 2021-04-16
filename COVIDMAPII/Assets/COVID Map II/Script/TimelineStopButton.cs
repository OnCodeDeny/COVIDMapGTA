using Microsoft.Maps.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimelineStopButton : MonoBehaviour
{
    TimelinePlayer _timelinePlayer;

    // Start is called before the first frame update
    void Start()
    {
        _timelinePlayer = transform.parent.GetComponent<TimelinePlayer>();
    }

    public void StopTimeline()
    {
        if (_timelinePlayer.currentTimelineState != TimelinePlayer.TimelineState.Stopped)
        {
            _timelinePlayer.TransferToStopped(true);
        }
    }
}
