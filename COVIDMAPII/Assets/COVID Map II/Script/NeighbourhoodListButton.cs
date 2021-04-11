using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Maps.Unity;
using TMPro;

public class NeighbourhoodListButton : MonoBehaviour
{
    public Neighbourhood neighbourhoodRepresenting;

    public MapRenderer mapToBeAnimated;
    private MapSceneOfLocationAndZoomLevel _targetLocationOnMap;
    public CaseDatumListManager datumListToBePopulated;

    private void Start()
    {
        transform.GetComponentInChildren<TextMeshProUGUI>().text = neighbourhoodRepresenting.displayName;
        _targetLocationOnMap = new MapSceneOfLocationAndZoomLevel(neighbourhoodRepresenting.locationLatLon, 14f);
    }

    public void MoveMapCentreToTarget()
    {
        mapToBeAnimated.SetMapScene(_targetLocationOnMap, MapSceneAnimationKind.Bow, 5f);
    }

    public void DisplayCaseData()
    {
        datumListToBePopulated.DisplayDatumList(neighbourhoodRepresenting);
    }
}
