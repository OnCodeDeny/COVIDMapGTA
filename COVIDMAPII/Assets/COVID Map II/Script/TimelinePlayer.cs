using System.Collections;
using System.Collections.Generic;
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

    //How many days are visualized per second, this is the timeline play speed.
    public float daysVisualizedPerSecond;
}
