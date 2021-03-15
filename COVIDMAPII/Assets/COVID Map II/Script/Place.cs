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
    public LatLon locationLatLon
    {
        get => new LatLon(latitude, longitude);
    }
    //COVID case data
    public int[] caseCountData = new int[9];

    public int cumulativeCaseCount
    {
        get
        {
            return caseCountData[(int)CaseType.Cumulative];
        }
        set
        {
            caseCountData[(int)CaseType.Cumulative] = value;
        }
    }
    public int everHospitalizedCaseCount
    {
        get
        {
            return caseCountData[(int)CaseType.EverHospitalized];
        }
        set
        {
            caseCountData[(int)CaseType.EverHospitalized] = value;
        }
    }
    public int everInICUCaseCount
    {
        get
        {
            return caseCountData[(int)CaseType.EverInICU];
        }
        set
        {
            caseCountData[(int)CaseType.EverInICU] = value;
        }
    }
    public int everIntubatedCaseCount
    {
        get
        {
            return caseCountData[(int)CaseType.EverIntubated];
        }
        set
        {
            caseCountData[(int)CaseType.EverIntubated] = value;
        }
    }
    public int activeCaseCount
    {
        get
        {
            return caseCountData[(int)CaseType.Active];
        }
        set
        {
            caseCountData[(int)CaseType.Active] = value;
        }
    }
    public int currentlyHospitalizedCaseCount
    {
        get
        {
            return caseCountData[(int)CaseType.CurrentlyHospitalized];
        }
        set
        {
            caseCountData[(int)CaseType.CurrentlyHospitalized] = value;
        }
    }
    public int currentlyInICUCaseCount
    {
        get
        {
            return caseCountData[(int)CaseType.CurrentlyInICU];
        }
        set
        {
            caseCountData[(int)CaseType.CurrentlyInICU] = value;
        }
    }
    public int currentlyIntubatedCaseCount
    {
        get
        {
            return caseCountData[(int)CaseType.CurrentlyIntubated];
        }
        set
        {
            caseCountData[(int)CaseType.CurrentlyIntubated] = value;
        }
    }
    public int deceasedCaseCount
    {
        get
        {
            return caseCountData[(int)CaseType.Deceased];
        }
        set
        {
            caseCountData[(int)CaseType.Deceased] = value;
        }
    }
}
