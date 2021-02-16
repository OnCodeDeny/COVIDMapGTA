using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Maps.Unity;
using TMPro;

public class NeighbourhoodListButton : MonoBehaviour
{
    public Neighbourhood neighbourhoodRepresenting;

    public MapRenderer mapToBeAnimated;
    public MapSceneOfLocationAndZoomLevel targetLocationOnMap;
    public GameObject datumListToBePopulated;

    private void Start()
    {
        transform.GetComponentInChildren<TextMeshProUGUI>().text = neighbourhoodRepresenting.displayName;
        targetLocationOnMap = new MapSceneOfLocationAndZoomLevel(neighbourhoodRepresenting.locationLatLon, 14f);
    }

    public void MoveMapCentreToTarget()
    {
        mapToBeAnimated.SetMapScene(targetLocationOnMap);
    }

    public void DisplayCaseData()
    {
        datumListToBePopulated.SetActive(true);
        datumListToBePopulated.GetComponent<CaseDatumListManager>().DisplayDatumList(neighbourhoodRepresenting);
    }
}
