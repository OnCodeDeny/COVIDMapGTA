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

    //Cumulative case datum fetch
    public void FetchNeighbourhoodCumulativeCase(Neighbourhood neighbourhood)
    {
        string filter = "{\"Neighbourhood Name\":\"" + neighbourhood.displayName + "\",\"Classification\":\"CONFIRMED\"}";
        StartCoroutine(GetCaseDatum(filter, (number) => { neighbourhood.cumulativeCaseCount = number; }));
    }

    //Active case datum fetch
    public void FetchNeighbourhoodActiveCase(Neighbourhood neighbourhood)
    {
        string filter = "{\"Neighbourhood Name\":\"" + neighbourhood.displayName + "\",\"Classification\":\"CONFIRMED\",\"Outcome\":\"ACTIVE\"}";
        StartCoroutine(GetCaseDatum(filter, (number) => { neighbourhood.activeCaseCount = number; }));
    }

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
