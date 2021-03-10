using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class NeighbourhoodPin : MonoBehaviour
{
    public UnityEvent OnClick=new UnityEvent();
    private void OnMouseUpAsButton()
    {
        OnClick.Invoke();
    }
}
