using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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
        StartCoroutine(GetNeighbourhoodCumulativeCaseNumber("Willowdale East"));

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

    IEnumerator GetNeighbourhoodCumulativeCaseNumber(string neighbourhoodName)
    {
        WWWForm form = new WWWForm();
        form.AddField("resource_id", "e5bf35bc-e681-43da-b2ce-0242d00922ad");
        form.AddField("limit", "0");
        form.AddField("filters", "{\"Neighbourhood Name\":\"" + neighbourhoodName + "\"}");
        using (UnityWebRequest searchRequest = UnityWebRequest.Post("http://ckan0.cf.opendata.inter.prod-toronto.ca/api/3/action/datastore_search", form))
        {
            yield return searchRequest.SendWebRequest();
            if (searchRequest.isNetworkError || searchRequest.isHttpError)
            {
                Debug.Log(searchRequest.error);
            }
            else
            {
                WebResponse response = JsonUtility.FromJson<WebResponse>(searchRequest.downloadHandler.text);
                Debug.Log(JsonUtility.ToJson(response));
            }
        }
    }
}
