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
    public static Neighbourhood westHumberClairville = new Neighbourhood("West Humber-Clairville", 43.713165283203125, -79.59501647949219);
    public static Neighbourhood mountOliveSilverstoneJamestown = new Neighbourhood("Mount Olive-Silverstone-Jamestown", 43.744873046875, -79.59306335449219);
    public static Neighbourhood thistletownBeaumondHeights = new Neighbourhood("Thistletown-Beaumond Heights", 43.737648010253906, -79.56346893310547);
    public static Neighbourhood rexdaleKipling = new Neighbourhood("Rexdale-Kipling", 43.72358322143555, -79.56682586669922);
    public static Neighbourhood elmsOldRexdale = new Neighbourhood("Elms-Old Rexdale", 43.72114562988281, -79.5484848022461);

    public static Neighbourhood eringateCentennialWestDeane = new Neighbourhood("Eringate-Centennial-West Deane", 43.65760040283203, -79.58052062988281);

    public static Neighbourhood[] allNeighbourhoods = {
    westHumberClairville,
    mountOliveSilverstoneJamestown,
    thistletownBeaumondHeights,
    rexdaleKipling,
    elmsOldRexdale,

    eringateCentennialWestDeane
    };
}
