using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbourhood : Place
{
    public Neighbourhood(string name, double lon, double lat)
    {
        displayName = name;
        longitude = lon;
        latitude = lat;
    }

    //Store neighbourhood-specific info
    int population;
}
