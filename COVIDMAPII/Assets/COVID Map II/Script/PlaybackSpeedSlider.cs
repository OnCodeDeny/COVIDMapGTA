using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaybackSpeedSlider : MonoBehaviour
{
    TimelinePlayer _timelinePlayer;
    Slider slider;


    // Start is called before the first frame update
    void Start()
    {
        _timelinePlayer = transform.parent.GetComponent<TimelinePlayer>();
        slider = GetComponent<Slider>();
        ChangePlaybackSpeed();
    }

    public void ChangePlaybackSpeed()
    {
        _timelinePlayer.SetPlaybackSpeed(slider.value);
    }
}
