using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PinTip : MonoBehaviour
{
    public UnityEvent OnHover = new UnityEvent();
    public UnityEvent OnEnter = new UnityEvent();
    public UnityEvent OnExit = new UnityEvent();
    public UnityEvent OnClick = new UnityEvent();

    private void OnMouseOver()
    {
        OnHover.Invoke();
        Debug.Log("hoverTip!");
    }
    private void OnMouseEnter()
    {
        OnEnter.Invoke();
        Debug.Log("enterTip!");
    }
    private void OnMouseExit()
    {
        OnExit.Invoke();
        Debug.Log("exitTip!");
    }
    private void OnMouseUpAsButton()
    {
        OnClick.Invoke();
        Debug.Log("clickTip!");
    }
}
