using Microsoft.Maps.Unity;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class NeighbourhoodPin : MonoBehaviour
{
    public Neighbourhood neighbourhoodRepresenting;

    public MapRenderer mapToBeAnimated;
    private MapSceneOfLocationAndZoomLevel _targetLocationOnMap;

    private void Start()
    {
        _targetLocationOnMap = new MapSceneOfLocationAndZoomLevel(neighbourhoodRepresenting.locationLatLon, 14f);
        //This should happen after data loading, try coroutine?
        //GetComponentInChildren<TextMeshPro>().text = neighbourhoodRepresenting.activeCaseCount.ToString();
    }
    public void MoveMapCentreToTarget()
    {
        mapToBeAnimated.SetMapScene(_targetLocationOnMap);
    }

    public UnityEvent OnClick = new UnityEvent();
    private void OnMouseUpAsButton()
    {
        OnClick.Invoke();
        Debug.Log(neighbourhoodRepresenting.displayName);
    }
}
