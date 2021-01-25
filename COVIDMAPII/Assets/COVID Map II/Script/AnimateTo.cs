using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Geospatial;
using Microsoft.Maps.Unity;

public class AnimateTo : MonoBehaviour
{
    MapSceneOfLocationAndZoomLevel BaycrestHealthSciences = new MapSceneOfLocationAndZoomLevel(new LatLon(43.729967, -79.434236), 17.0f);

    [SerializeField]
    private MapRenderer _map = null;

    private void Awake()
    {
        Debug.Assert(_map != null);
    }

    public void AnimateCentreTo(MapSceneOfLabelAndZoomLevel labelAndZoomLevel)
    {
        _map.SetMapScene(labelAndZoomLevel);
    }

    public void AnimateCentreTo(MapSceneOfLocationAndZoomLevel locationAndZoomLevel)
    {
        _map.SetMapScene(locationAndZoomLevel);
    }
}
