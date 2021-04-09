using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CaseDataTypeForNeighbourhood
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
public enum CaseDataTypeForDay
{
    New,
    Cumulative,
    Active
}