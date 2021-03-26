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
            return caseCountData[(int)CaseDataType.Cumulative];
        }
        set
        {
            caseCountData[(int)CaseDataType.Cumulative] = value;
        }
    }
    public int everHospitalizedCaseCount
    {
        get
        {
            return caseCountData[(int)CaseDataType.EverHospitalized];
        }
        set
        {
            caseCountData[(int)CaseDataType.EverHospitalized] = value;
        }
    }
    public int everInICUCaseCount
    {
        get
        {
            return caseCountData[(int)CaseDataType.EverInICU];
        }
        set
        {
            caseCountData[(int)CaseDataType.EverInICU] = value;
        }
    }
    public int everIntubatedCaseCount
    {
        get
        {
            return caseCountData[(int)CaseDataType.EverIntubated];
        }
        set
        {
            caseCountData[(int)CaseDataType.EverIntubated] = value;
        }
    }
    public int activeCaseCount
    {
        get
        {
            return caseCountData[(int)CaseDataType.Active];
        }
        set
        {
            caseCountData[(int)CaseDataType.Active] = value;
        }
    }
    public int currentlyHospitalizedCaseCount
    {
        get
        {
            return caseCountData[(int)CaseDataType.CurrentlyHospitalized];
        }
        set
        {
            caseCountData[(int)CaseDataType.CurrentlyHospitalized] = value;
        }
    }
    public int currentlyInICUCaseCount
    {
        get
        {
            return caseCountData[(int)CaseDataType.CurrentlyInICU];
        }
        set
        {
            caseCountData[(int)CaseDataType.CurrentlyInICU] = value;
        }
    }
    public int currentlyIntubatedCaseCount
    {
        get
        {
            return caseCountData[(int)CaseDataType.CurrentlyIntubated];
        }
        set
        {
            caseCountData[(int)CaseDataType.CurrentlyIntubated] = value;
        }
    }
    public int deceasedCaseCount
    {
        get
        {
            return caseCountData[(int)CaseDataType.Deceased];
        }
        set
        {
            caseCountData[(int)CaseDataType.Deceased] = value;
        }
    }
}
