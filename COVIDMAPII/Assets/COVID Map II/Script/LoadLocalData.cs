using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Geospatial;
using Microsoft.Maps.Unity;

public class LoadLocalData : MonoBehaviour
{
    ///COMPROMISED ABSTRACT SCOPE///
    ///These data are expected to be grabbed from online database///
    Hospital[] hospitals = new Hospital[]
    {
        new Hospital("Baycrest Health Sciences", 43.729984, -79.434189),
        new Hospital("Bellwood Health Services", 43.719452, -79.366241)
    };
}
