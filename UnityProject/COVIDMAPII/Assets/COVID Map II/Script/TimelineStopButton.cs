using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (_timelinePlayer.timelineInUse)
        {
            _timelinePlayer.TransferToStoppedWithReset();
        }
    }
}
