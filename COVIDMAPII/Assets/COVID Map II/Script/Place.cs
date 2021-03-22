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
            return caseCountData[(int)CaseAttribute.Cumulative];
        }
        set
        {
            caseCountData[(int)CaseAttribute.Cumulative] = value;
        }
    }
    public int everHospitalizedCaseCount
    {
        get
        {
            return caseCountData[(int)CaseAttribute.EverHospitalized];
        }
        set
        {
            caseCountData[(int)CaseAttribute.EverHospitalized] = value;
        }
    }
    public int everInICUCaseCount
    {
        get
        {
            return caseCountData[(int)CaseAttribute.EverInICU];
        }
        set
        {
            caseCountData[(int)CaseAttribute.EverInICU] = value;
        }
    }
    public int everIntubatedCaseCount
    {
        get
        {
            return caseCountData[(int)CaseAttribute.EverIntubated];
        }
        set
        {
            caseCountData[(int)CaseAttribute.EverIntubated] = value;
        }
    }
    public int activeCaseCount
    {
        get
        {
            return caseCountData[(int)CaseAttribute.Active];
        }
        set
        {
            caseCountData[(int)CaseAttribute.Active] = value;
        }
    }
    public int currentlyHospitalizedCaseCount
    {
        get
        {
            return caseCountData[(int)CaseAttribute.CurrentlyHospitalized];
        }
        set
        {
            caseCountData[(int)CaseAttribute.CurrentlyHospitalized] = value;
        }
    }
    public int currentlyInICUCaseCount
    {
        get
        {
            return caseCountData[(int)CaseAttribute.CurrentlyInICU];
        }
        set
        {
            caseCountData[(int)CaseAttribute.CurrentlyInICU] = value;
        }
    }
    public int currentlyIntubatedCaseCount
    {
        get
        {
            return caseCountData[(int)CaseAttribute.CurrentlyIntubated];
        }
        set
        {
            caseCountData[(int)CaseAttribute.CurrentlyIntubated] = value;
        }
    }
    public int deceasedCaseCount
    {
        get
        {
            return caseCountData[(int)CaseAttribute.Deceased];
        }
        set
        {
            caseCountData[(int)CaseAttribute.Deceased] = value;
        }
    }
}
