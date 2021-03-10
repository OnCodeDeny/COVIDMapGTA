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
    public static Neighbourhood westHumberClairville = new Neighbourhood("West Humber-Clairville", 43.713165, -79.595016);
    public static Neighbourhood eringateCentennialWestDeane = new Neighbourhood("Eringate-Centennial-West Deane", 43.65760040283203, -79.58052062988281);
    //public static Neighbourhood mountOliveSilverstoneJamestown = new Neighbourhood("Mount Olive-Silverstone-Jamestown", 43.657600, -79.580521);
    //public static Neighbourhood thistletownBeaumondHeights = new Neighbourhood("Thistletown-Beaumond Heights", 43.657600, -79.580521);
    //public static Neighbourhood rexdaleKipling = new Neighbourhood("Rexdale-Kipling", 43.657600, -79.580521);

    public static Neighbourhood[] allNeighbourhoods = {
    westHumberClairville,
    eringateCentennialWestDeane,
    //mountOliveSilverstoneJamestown,
    //thistletownBeaumondHeights,
    //rexdaleKipling
    };
}
