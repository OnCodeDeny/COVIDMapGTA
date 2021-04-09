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
            return caseCountData[(int)CaseDataTypeForNeighbourhood.Cumulative];
        }
        set
        {
            caseCountData[(int)CaseDataTypeForNeighbourhood.Cumulative] = value;
        }
    }
    public int everHospitalizedCaseCount
    {
        get
        {
            return caseCountData[(int)CaseDataTypeForNeighbourhood.EverHospitalized];
        }
        set
        {
            caseCountData[(int)CaseDataTypeForNeighbourhood.EverHospitalized] = value;
        }
    }
    public int everInICUCaseCount
    {
        get
        {
            return caseCountData[(int)CaseDataTypeForNeighbourhood.EverInICU];
        }
        set
        {
            caseCountData[(int)CaseDataTypeForNeighbourhood.EverInICU] = value;
        }
    }
    public int everIntubatedCaseCount
    {
        get
        {
            return caseCountData[(int)CaseDataTypeForNeighbourhood.EverIntubated];
        }
        set
        {
            caseCountData[(int)CaseDataTypeForNeighbourhood.EverIntubated] = value;
        }
    }
    public int activeCaseCount
    {
        get
        {
            return caseCountData[(int)CaseDataTypeForNeighbourhood.Active];
        }
        set
        {
            caseCountData[(int)CaseDataTypeForNeighbourhood.Active] = value;
        }
    }
    public int currentlyHospitalizedCaseCount
    {
        get
        {
            return caseCountData[(int)CaseDataTypeForNeighbourhood.CurrentlyHospitalized];
        }
        set
        {
            caseCountData[(int)CaseDataTypeForNeighbourhood.CurrentlyHospitalized] = value;
        }
    }
    public int currentlyInICUCaseCount
    {
        get
        {
            return caseCountData[(int)CaseDataTypeForNeighbourhood.CurrentlyInICU];
        }
        set
        {
            caseCountData[(int)CaseDataTypeForNeighbourhood.CurrentlyInICU] = value;
        }
    }
    public int currentlyIntubatedCaseCount
    {
        get
        {
            return caseCountData[(int)CaseDataTypeForNeighbourhood.CurrentlyIntubated];
        }
        set
        {
            caseCountData[(int)CaseDataTypeForNeighbourhood.CurrentlyIntubated] = value;
        }
    }
    public int deceasedCaseCount
    {
        get
        {
            return caseCountData[(int)CaseDataTypeForNeighbourhood.Deceased];
        }
        set
        {
            caseCountData[(int)CaseDataTypeForNeighbourhood.Deceased] = value;
        }
    }
}
