using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A day that belongs to a place
//Example: Guildwood/4/12/2021
public class PlaceDay
{
    public PlaceDay(Place place)
    {
        placeRepresenting = place;
    }

    public Place placeRepresenting
    {
        get 
        {
            return placeRepresenting;
        }
        private set { }
    }

    //COVID case data
    public int[] caseCountData = new int[3];
    //Case for the day (increasement).
    public int newCase
    {
        get
        {
            return caseCountData[(int)NeighbourhoodDailyCaseDataType.New];
        }
        set
        {
            caseCountData[(int)NeighbourhoodDailyCaseDataType.New] = value;
        }
    }
    //Cumulative case till the day (old amount + increasement) (Inclusive).
    public int cumulativeCase
    {
        get
        {
            return caseCountData[(int)NeighbourhoodDailyCaseDataType.Cumulative];
        }
        set
        {
            caseCountData[(int)NeighbourhoodDailyCaseDataType.Cumulative] = value;
        }
    }

    //Active case till the day
    public int activeCase
    {
        get
        {
            return caseCountData[(int)NeighbourhoodDailyCaseDataType.Active];
        }
        set
        {
            caseCountData[(int)NeighbourhoodDailyCaseDataType.Active] = value;
        }
    }
}
