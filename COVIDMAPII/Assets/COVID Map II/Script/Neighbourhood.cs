using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbourhood : Place
{
    public Neighbourhood(string name, double lat, double lon)
    {
        displayName = name;
        latitude = lat;
        longitude = lon;
    }

    //Store neighbourhood-specific info
    int population;
    float ratePer100000PeopleCumulative;
    int caseCountCumulative;
    float ratePer100000PeopleRecent;
    int caseCountRecent;
}
