using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    //Store place info
    public string displayName;
    //Map data
    public double longitude;
    public double latitude;
    public float defaultZoomLevel;
    //COVID data
    public int totalCOVIDCaseNumber;
    public int activeCOVIDCaseNumber;
}
