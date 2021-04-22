using Microsoft.Maps.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapCopyrightText : MonoBehaviour
{
    public MapRenderer mapRenderer;

    //Copyright info is continually being updated during runtime.
    private void Update()
    {
        GetComponent<Text>().text = mapRenderer.Copyright;
    }
}
