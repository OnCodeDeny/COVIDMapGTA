using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Geospatial;
using System;

public abstract class Place
{
    //Fast query the location(lat,long) from BingMaps REST service:
    //http://dev.virtualearth.net/REST/v1/Locations/CA/ON/Toronto/{AddressBeforeSpace}%20{AddressAfterSpace}?key={BingMapsAPIKey}

    //Store place info
    public string displayName;
    //Map data
    public double latitude;
    public double longitude;
    public LatLon locationLatLon
    {
        get => new LatLon(latitude, longitude);
    }
    //To store each episode days.
    public Dictionary<DateTime, Day> episodeDays = new Dictionary<DateTime, Day>();

    //COVID case data
    public int[] caseCountData = new int[9];

    public int cumulativeCaseCount
    {
        get
        {
            return caseCountData[(int)NeighbourhoodCaseDataType.Cumulative];
        }
        set
        {
            caseCountData[(int)NeighbourhoodCaseDataType.Cumulative] = value;
        }
    }
    public int everHospitalizedCaseCount
    {
        get
        {
            return caseCountData[(int)NeighbourhoodCaseDataType.EverHospitalized];
        }
        set
        {
            caseCountData[(int)NeighbourhoodCaseDataType.EverHospitalized] = value;
        }
    }
    public int everInICUCaseCount
    {
        get
        {
            return caseCountData[(int)NeighbourhoodCaseDataType.EverInICU];
        }
        set
        {
            caseCountData[(int)NeighbourhoodCaseDataType.EverInICU] = value;
        }
    }
    public int everIntubatedCaseCount
    {
        get
        {
            return caseCountData[(int)NeighbourhoodCaseDataType.EverIntubated];
        }
        set
        {
            caseCountData[(int)NeighbourhoodCaseDataType.EverIntubated] = value;
        }
    }
    public int activeCaseCount
    {
        get
        {
            return caseCountData[(int)NeighbourhoodCaseDataType.Active];
        }
        set
        {
            caseCountData[(int)NeighbourhoodCaseDataType.Active] = value;
        }
    }
    public int currentlyHospitalizedCaseCount
    {
        get
        {
            return caseCountData[(int)NeighbourhoodCaseDataType.CurrentlyHospitalized];
        }
        set
        {
            caseCountData[(int)NeighbourhoodCaseDataType.CurrentlyHospitalized] = value;
        }
    }
    public int currentlyInICUCaseCount
    {
        get
        {
            return caseCountData[(int)NeighbourhoodCaseDataType.CurrentlyInICU];
        }
        set
        {
            caseCountData[(int)NeighbourhoodCaseDataType.CurrentlyInICU] = value;
        }
    }
    public int currentlyIntubatedCaseCount
    {
        get
        {
            return caseCountData[(int)NeighbourhoodCaseDataType.CurrentlyIntubated];
        }
        set
        {
            caseCountData[(int)NeighbourhoodCaseDataType.CurrentlyIntubated] = value;
        }
    }
    public int deceasedCaseCount
    {
        get
        {
            return caseCountData[(int)NeighbourhoodCaseDataType.Deceased];
        }
        set
        {
            caseCountData[(int)NeighbourhoodCaseDataType.Deceased] = value;
        }
    }
}
