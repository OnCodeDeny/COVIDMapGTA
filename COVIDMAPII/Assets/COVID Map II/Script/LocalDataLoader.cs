using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalDataLoader : MonoBehaviour
{
    ///COMPROMISED ABSTRACT SCOPE///
    ///These data are expected to be retrieved from online database///
    public Hospital[] hospitals;
    public Neighbourhood[] neighbourhoods;
    private void Awake()
    {
        hospitals = new Hospital[]
        {
        new Hospital("Baycrest Health Sciences", 43.729984, -79.434189),
        new Hospital("Bellwood Health Services", 43.719452, -79.366241)
        };

        neighbourhoods = new Neighbourhood[]
        {
        new Neighbourhood("West Humber-Clairville", 43.713170, -79.595020),
        new Neighbourhood("Eringate-Centennial-West Deane", 43.657600, -79.580521)
        };
    }
}
