using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Maps.Unity;

public class MapMover : MonoBehaviour
{
    public MapSceneOfLocationAndZoomLevel defaultTarget;
    public MapRenderer map;

    public void MoveCentreTo(MapSceneOfLabelAndZoomLevel labelAndZoomLevel)
    {
        map.SetMapScene(labelAndZoomLevel);
    }

    public void MoveCentreTo(MapSceneOfLocationAndZoomLevel locationAndZoomLevel)
    {
        map.SetMapScene(locationAndZoomLevel);
    }

    public void MoveCentreToDefault()
    {
        MoveCentreTo(defaultTarget);
    }
}
