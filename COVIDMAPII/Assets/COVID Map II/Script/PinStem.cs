using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PinStem : MonoBehaviour
{
    public UnityEvent OnHover = new UnityEvent();
    public UnityEvent OnEnter = new UnityEvent();
    public UnityEvent OnExit = new UnityEvent();
    public UnityEvent OnClick = new UnityEvent();

    private void OnMouseOver()
    {
        OnHover.Invoke();
        Debug.Log("hoverStem!");
    }
    private void OnMouseEnter()
    {
        OnEnter.Invoke();
        Debug.Log("enterStem!");
    }
    private void OnMouseExit()
    {
        OnExit.Invoke();
        Debug.Log("exitStem!");
    }
    private void OnMouseUpAsButton()
    {
        OnClick.Invoke();
        Debug.Log("clickStem!");
    }
}
