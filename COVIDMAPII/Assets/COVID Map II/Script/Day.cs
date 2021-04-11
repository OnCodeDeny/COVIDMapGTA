using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day
{
    //COVID case data
    public int[] caseCountData = new int[3];
    //Case for the day (increasement).
    public int newCase
    {
        get
        {
            return caseCountData[(int)CaseDataTypeForDay.New];
        }
        set
        {
            caseCountData[(int)CaseDataTypeForDay.New] = value;
        }
    }
    //Cumulative case till the day (old amount + increasement) (Inclusive).
    public int cumulativeCase
    {
        get
        {
            return caseCountData[(int)CaseDataTypeForDay.Cumulative];
        }
        set
        {
            caseCountData[(int)CaseDataTypeForDay.Cumulative] = value;
        }
    }

    //Active case till the day
    public int activeCase
    {
        get
        {
            return caseCountData[(int)CaseDataTypeForDay.Active];
        }
        set
        {
            caseCountData[(int)CaseDataTypeForDay.Active] = value;
        }
    }
}
