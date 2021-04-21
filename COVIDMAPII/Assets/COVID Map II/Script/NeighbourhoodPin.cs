using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Microsoft.Maps.Unity;

public class NeighbourhoodPin : MonoBehaviour
{
    public DataVisualizer dataVisualizer;
    public TextMeshPro infoText;
    public Neighbourhood neighbourhoodRepresenting;
    public MapRenderer mapToBeAnimated;
    public LatestCaseDatumList datumListToBePopulated;
    public TimelinePlayer timelinePlayer;
    MapSceneOfLocationAndZoomLevel _targetLocationOnMap;

    private void Start()
    {
        dataVisualizer.neighbourhoodRepresenting = neighbourhoodRepresenting;
        infoText.text = neighbourhoodRepresenting.displayName;
        infoText.transform.localPosition = new Vector3(0, infoText.transform.localScale.y / 2, 0);
        _targetLocationOnMap = new MapSceneOfLocationAndZoomLevel(neighbourhoodRepresenting.locationLatLon, 14f);
    }
    public void MoveMapCentreToTarget()
    {
        mapToBeAnimated.SetMapScene(_targetLocationOnMap, MapSceneAnimationKind.Linear, 30f);
    }
    public void DisplayCaseData()
    {
        datumListToBePopulated.DisplayDatumList(neighbourhoodRepresenting);
    }
    public void ChangeTimelinePlayerPresentingNeighbourhood()
    {
        timelinePlayer.presentingNeighbourhood = neighbourhoodRepresenting;
        timelinePlayer.UpdateDailyCaseDatumList();
    }
}
