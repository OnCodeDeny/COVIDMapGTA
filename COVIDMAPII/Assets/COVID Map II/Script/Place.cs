using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Geospatial;

public abstract class Place
{
    //Fast query the location(lat,long) from BingMaps REST service:
    //http://dev.virtualearth.net/REST/v1/Locations/CA/ON/Toronto/{AddressBeforeSpace}%20{AddressAfterSpace}?key={BingMapsAPIKey}

    //Store place info
    public string displayName;
    //Map data
    public double latitude;
    public double longitude;
    //COVID data
    public int cumulativeCaseCount;
    public int everHospitalizedCaseCount;
    public int everInICUCaseCount;
    public int everIntubatedCaseCount;

    public int activeCaseCount;
    public int currentlyHospitalizedCaseCount;
    public int currentlyInICUCaseCount;
    public int currentlyIntubatedCaseCount;

    public int deceasedCaseCount;

    public LatLon locationLatLon
    {
        get => new LatLon(latitude, longitude);
    }
}
