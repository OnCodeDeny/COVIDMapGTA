using Microsoft.Maps.Unity;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class NeighbourhoodPin : MonoBehaviour
{
    public DataVisualizer dataVisualizer;
    public TextMeshPro textMeshPro;
    public Neighbourhood neighbourhoodRepresenting;
    public MapRenderer mapToBeAnimated;
    public CaseDatumListManager datumListToBePopulated;
    private MapSceneOfLocationAndZoomLevel _targetLocationOnMap;

    private void Start()
    {
        dataVisualizer.neighbourhoodRepresenting = neighbourhoodRepresenting;
        textMeshPro.text = neighbourhoodRepresenting.displayName;
        textMeshPro.transform.localPosition = new Vector3(0, textMeshPro.transform.localScale.y / 2, 0);
        _targetLocationOnMap = new MapSceneOfLocationAndZoomLevel(neighbourhoodRepresenting.locationLatLon, 14f);
        //This should happen after data loading, try coroutine?
        //GetComponentInChildren<TextMeshPro>().text = neighbourhoodRepresenting.activeCaseCount.ToString();
    }
    public void MoveMapCentreToTarget()
    {
        mapToBeAnimated.SetMapScene(_targetLocationOnMap);
    }
    public void DisplayCaseData()
    {
        datumListToBePopulated.DisplayDatumList(neighbourhoodRepresenting);
    }
}
