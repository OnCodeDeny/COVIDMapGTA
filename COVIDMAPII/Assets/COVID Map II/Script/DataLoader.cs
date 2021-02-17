using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class DataLoader : MonoBehaviour
{
    private void Awake()
    {
        foreach (Neighbourhood neighbourhood in Neighbourhood.allNeighbourhoods)
        {
            FetchNeighbourhoodCumulativeCase(neighbourhood);
            FetchNeighbourhoodActiveCase(neighbourhood);
            FetchNeighbourhoodEverHospitalizedCase(neighbourhood);
            FetchNeighbourhoodEverInICUCase(neighbourhood);
            FetchNeighbourhoodEverIntubatedCase(neighbourhood);
            FetchNeighbourhoodCurrentlyHospitalizedCase(neighbourhood);
            FetchNeighbourhoodCurrentlyInICUCase(neighbourhood);
            FetchNeighbourhoodCurrentlyIntubatedCase(neighbourhood);
            FetchNeighbourhoodDeceasedCase(neighbourhood);
        }

        /***COMPROMISED FETCHING INTERFACE***
        FetchCaseData("https://drive.google.com/uc?export=download&id=1jzH64LvFQ-UsDibXO0MOtvjbL2CvnV3N");***/
    }

    /***COMPROMISED FETCHING INTERFACE***
    public void FetchCaseData(string url)
    {
        WebClient client = new WebClient();
        client.DownloadFile(url, Application.persistentDataPath+@"\CaseData.xlsx");

    }***/
    [System.Serializable]
    public struct Result
    {
        public int total;
    }

    [System.Serializable]
    public struct WebResponse
    {
        public Result result;
    }

    //Fetch datum: Cumulative Case
    public void FetchNeighbourhoodCumulativeCase(Neighbourhood neighbourhood)
    {
        string filter = "{\"Neighbourhood Name\":\"" + neighbourhood.displayName + "\",\"Classification\":\"CONFIRMED\"}";
        StartCoroutine(GetCaseDatum(filter, (number) => { neighbourhood.cumulativeCaseCount = number; }));
    }

    //Fetch datum: Active Case
    public void FetchNeighbourhoodActiveCase(Neighbourhood neighbourhood)
    {
        string filter = "{\"Neighbourhood Name\":\"" + neighbourhood.displayName + "\",\"Classification\":\"CONFIRMED\",\"Outcome\":\"ACTIVE\"}";
        StartCoroutine(GetCaseDatum(filter, (number) => { neighbourhood.activeCaseCount = number; }));
    }

    //Fetch datum: Ever Hospitalized
    public void FetchNeighbourhoodEverHospitalizedCase(Neighbourhood neighbourhood)
    {
        string filter = "{\"Neighbourhood Name\":\"" + neighbourhood.displayName + "\",\"Classification\":\"CONFIRMED\",\"Ever Hospitalized\":\"Yes\"}";
        StartCoroutine(GetCaseDatum(filter, (number) => { neighbourhood.everHospitalizedCaseCount = number; }));
    }

    //Fetch datum: Ever in ICU
    public void FetchNeighbourhoodEverInICUCase(Neighbourhood neighbourhood)
    {
        string filter = "{\"Neighbourhood Name\":\"" + neighbourhood.displayName + "\",\"Classification\":\"CONFIRMED\",\"Ever in ICU\":\"Yes\"}";
        StartCoroutine(GetCaseDatum(filter, (number) => { neighbourhood.everInICUCaseCount = number; }));
    }

    //Fetch datum: Ever Intubated
    public void FetchNeighbourhoodEverIntubatedCase(Neighbourhood neighbourhood)
    {
        string filter = "{\"Neighbourhood Name\":\"" + neighbourhood.displayName + "\",\"Classification\":\"CONFIRMED\",\"Ever Intubated\":\"Yes\"}";
        StartCoroutine(GetCaseDatum(filter, (number) => { neighbourhood.everIntubatedCaseCount = number; }));
    }

    //Fetch datum: Currently Hospitalized
    public void FetchNeighbourhoodCurrentlyHospitalizedCase(Neighbourhood neighbourhood)
    {
        string filter = "{\"Neighbourhood Name\":\"" + neighbourhood.displayName + "\",\"Classification\":\"CONFIRMED\",\"Currently Hospitalized\":\"Yes\"}";
        StartCoroutine(GetCaseDatum(filter, (number) => { neighbourhood.currentlyHospitalizedCaseCount = number; }));
    }

    //Fetch datum: Currently in ICU
    public void FetchNeighbourhoodCurrentlyInICUCase(Neighbourhood neighbourhood)
    {
        string filter = "{\"Neighbourhood Name\":\"" + neighbourhood.displayName + "\",\"Classification\":\"CONFIRMED\",\"Currently in ICU\":\"Yes\"}";
        StartCoroutine(GetCaseDatum(filter, (number) => { neighbourhood.currentlyInICUCaseCount = number; }));
    }

    //Fetch datum: Currently Intubated
    public void FetchNeighbourhoodCurrentlyIntubatedCase(Neighbourhood neighbourhood)
    {
        string filter = "{\"Neighbourhood Name\":\"" + neighbourhood.displayName + "\",\"Classification\":\"CONFIRMED\",\"Currently Intubated\":\"Yes\"}";
        StartCoroutine(GetCaseDatum(filter, (number) => { neighbourhood.currentlyIntubatedCaseCount = number; }));
    }

    //Fetch datum: Deceased
    public void FetchNeighbourhoodDeceasedCase(Neighbourhood neighbourhood)
    {
        string filter = "{\"Neighbourhood Name\":\"" + neighbourhood.displayName + "\",\"Classification\":\"CONFIRMED\",\"Outcome\":\"FATAL\"}";
        StartCoroutine(GetCaseDatum(filter, (number) => { neighbourhood.deceasedCaseCount = number; }));
    }

    //Fetch datum
    public IEnumerator GetCaseDatum(string filter, Action<int> callbackOnFinish)
    {
        WWWForm requestForm = new WWWForm();
        requestForm.AddField("resource_id", "e5bf35bc-e681-43da-b2ce-0242d00922ad");
        requestForm.AddField("limit", "0");
        requestForm.AddField("filters", filter);
        UnityWebRequest searchRequest = UnityWebRequest.Post("http://ckan0.cf.opendata.inter.prod-toronto.ca/api/3/action/datastore_search", requestForm);
        yield return searchRequest.SendWebRequest();
        if (searchRequest.isNetworkError || searchRequest.isHttpError)
        {
            Debug.Log(searchRequest.error);
        }
        else
        {
            WebResponse searchResponse = JsonUtility.FromJson<WebResponse>(searchRequest.downloadHandler.text);
            callbackOnFinish(searchResponse.result.total);
            //Debug.Log(JsonUtility.ToJson(searchResponse));
        }
    }
}
