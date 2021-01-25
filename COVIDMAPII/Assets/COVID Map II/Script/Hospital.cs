using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hospital : Place
{
    public Hospital(string name, double lon, double lat){
        displayName = name;
        longitude = lon;
        latitude = lat;
    }

    //Store hospital-specific info
    int currentICUCOVIDCaseNumber;
}
