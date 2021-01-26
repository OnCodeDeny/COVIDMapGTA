using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hospital : Place
{
    public Hospital(string name, double lat, double lon)
    {
        displayName = name;
        latitude = lat;
        longitude = lon;
    }

    //Store hospital-specific info
    public int currentICUCOVIDCaseNumber;
}
