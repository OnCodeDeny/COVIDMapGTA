using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Neighbourhood : Place
{
    public Neighbourhood(string name, double lat, double lon)
    {
        displayName = name;
        latitude = lat;
        longitude = lon;
    }

    //Store neighbourhood-specific info
    public static Neighbourhood westHumberClairville = new Neighbourhood("West Humber-Clairville", 43.713170, -79.595020);
    public static Neighbourhood eringateCentennialWestDeane = new Neighbourhood("Eringate-Centennial-West Deane", 43.657600, -79.580521);
    public static Neighbourhood[] allNeighbourhoods = new Neighbourhood[]{
    westHumberClairville,
    eringateCentennialWestDeane
    };
}
