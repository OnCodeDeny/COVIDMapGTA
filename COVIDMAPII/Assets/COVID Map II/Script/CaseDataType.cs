using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NeighbourhoodCaseDataType
{
    Cumulative,
    EverHospitalized,
    EverInICU,
    EverIntubated,
    Active,
    CurrentlyHospitalized,
    CurrentlyInICU,
    CurrentlyIntubated,
    Deceased
}
public enum NeighbourhoodDailyCaseDataType
{
    Cumulative,
    Active,
    New
}