using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class NeighbourhoodPin : MonoBehaviour
{
    public Neighbourhood neighbourhoodRepresenting;

    public UnityEvent OnClick = new UnityEvent();
    private void OnMouseUpAsButton()
    {
        OnClick.Invoke();
        Debug.Log(neighbourhoodRepresenting.displayName);
    }

    private void Start()
    {
        //This should happen after data loading, try coroutine?
        //GetComponentInChildren<TextMeshPro>().text = neighbourhoodRepresenting.activeCaseCount.ToString();
    }
}
