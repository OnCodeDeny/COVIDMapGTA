using Microsoft.Maps.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimelineStopButton : MonoBehaviour
{
    TimelinePlayer _timelinePlayer;
    public MapPinLayer mapPinLayer;
    DataVisualizer[] _dataVisualizers;

    // Start is called before the first frame update
    void Start()
    {
        _timelinePlayer = transform.parent.GetComponent<TimelinePlayer>();
        _dataVisualizers = new DataVisualizer[mapPinLayer.MapPins.Count];
        for (int i = 0; i < mapPinLayer.MapPins.Count; i++)
        {
            _dataVisualizers[i] = mapPinLayer.MapPins[i].GetComponent<DataVisualizer>();
        }
    }
    public void StopTimeline()
    {
        foreach (DataVisualizer dataVisualizer in _dataVisualizers)
        {
            dataVisualizer.DevisualizeDatum();
        }
        _timelinePlayer.currentTimelineState = TimelinePlayer.TimelineState.Stopped;
    }
}
