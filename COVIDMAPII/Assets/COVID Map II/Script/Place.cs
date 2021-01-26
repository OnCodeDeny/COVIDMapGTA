using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Geospatial;

public class Place
{
    //Store place info
    public string displayName;
    //Map data
    public double latitude;
    public double longitude;
    //COVID data
    public int totalCOVIDCaseNumber;
    public int activeCOVIDCaseNumber;

    public LatLon locationLatLon
    {
        get => new LatLon(latitude, longitude);
    }
}
