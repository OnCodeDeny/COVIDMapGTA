using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.Networking;
using SimpleJSON;

public class DataLoader : MonoBehaviour
{
    string caseDataFilePath;

    [Serializable]
    public struct COVIDCaseData
    {
        public Field[] fields;
        public object[][] records;
    }

    [Serializable]
    public struct Field
    {
        public string type;
        public string id;
        public Info info;
    }

    [Serializable]
    public struct Info
    {
        public string notes;
        public string type_override;
        public string label;
    }

    void Awake()
    {
        caseDataFilePath = Path.Combine(Application.persistentDataPath, "TorontoCOVID19Cases.json");
        if (File.Exists(caseDataFilePath))
            ReadCaseDataFile();
        else
            StartCoroutine(DownloadCaseDataToFile());
    }

    IEnumerator DownloadCaseDataToFile()
    {
        var unityWebRequest = new UnityWebRequest("https://ckan0.cf.opendata.inter.prod-toronto.ca/datastore/dump/e5bf35bc-e681-43da-b2ce-0242d00922ad?format=json", UnityWebRequest.kHttpVerbGET);
        unityWebRequest.downloadHandler = new DownloadHandlerFile(caseDataFilePath);
        yield return unityWebRequest.SendWebRequest();
        if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
            Debug.LogError(unityWebRequest.error);
        else
        {
            Debug.Log("File successfully downloaded and saved to " + caseDataFilePath);
            ReadCaseDataFile();
        }
    }

    private void ReadCaseDataFile()
    {
        if (File.Exists(caseDataFilePath))
        {
            string caseDataFileContents = File.ReadAllText(caseDataFilePath);
            JSONNode covidCaseData = JSON.Parse(caseDataFileContents);
            //Debug.Log(covidCaseData["records"][0][7].Value);
            FilterCaseData(covidCaseData);
        }
    }

    private void FilterCaseData(JSONNode covidCaseData)
    {
        int c = 0;
        foreach (JSONArray jsonArray in covidCaseData["records"])
        {
            if (jsonArray[7].Value == "CONFIRMED")
                c++;
        }
        Debug.Log(c);
    }

    ///DEPRECATED///
    ///Inefficient Precise Data Request Implementation///
    /*string[] caseRequestFilterSuffix = new string[9];
    private void Awake()
    {
        caseRequestFilterSuffix[(int)CaseType.Active]= "\",\"Classification\":\"CONFIRMED\",\"Outcome\":\"ACTIVE\"}";
        caseRequestFilterSuffix[(int)CaseType.Cumulative] = "\",\"Classification\":\"CONFIRMED\"}";
        caseRequestFilterSuffix[(int)CaseType.EverHospitalized] = "\",\"Classification\":\"CONFIRMED\",\"Ever Hospitalized\":\"Yes\"}";
        caseRequestFilterSuffix[(int)CaseType.EverInICU] = "\",\"Classification\":\"CONFIRMED\",\"Ever in ICU\":\"Yes\"}";
        caseRequestFilterSuffix[(int)CaseType.EverIntubated] = "\",\"Classification\":\"CONFIRMED\",\"Ever Intubated\":\"Yes\"}";
        caseRequestFilterSuffix[(int)CaseType.CurrentlyHospitalized] = "\",\"Classification\":\"CONFIRMED\",\"Currently Hospitalized\":\"Yes\"}";
        caseRequestFilterSuffix[(int)CaseType.CurrentlyInICU] = "\",\"Classification\":\"CONFIRMED\",\"Currently in ICU\":\"Yes\"}";
        caseRequestFilterSuffix[(int)CaseType.CurrentlyIntubated] = "\",\"Classification\":\"CONFIRMED\",\"Currently Intubated\":\"Yes\"}";
        caseRequestFilterSuffix[(int)CaseType.Deceased] = "\",\"Classification\":\"CONFIRMED\",\"Outcome\":\"FATAL\"}";

        foreach (CaseType caseType in Enum.GetValues(typeof(CaseType)))
        {
            foreach (Neighbourhood neighbourhood in Neighbourhood.allNeighbourhoods)
            {
                RequestNeighbourhoodCaseData(neighbourhood, caseType);
            }
        }
    }

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

    //Request case datum
    public void RequestNeighbourhoodCaseData(Neighbourhood neighbourhood, CaseType caseType)
    {
        int caseTypeIndex = (int)caseType;
        string filter = "{\"Neighbourhood Name\":\"" + neighbourhood.displayName + caseRequestFilterSuffix[caseTypeIndex];
        StartCoroutine(GetCaseDatum(filter, (number) => { neighbourhood.caseCountData[caseTypeIndex] = number; }));
    }

    //Send data request
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
            CalculateNeighbourhoodWithMaxCaseData();
        }
    }

    public void CalculateNeighbourhoodWithMaxCaseData()
    {
        foreach (CaseType caseType in Enum.GetValues(typeof(CaseType)))
        {
            Neighbourhood.NeighbourhoodWithMaxCaseCount(caseType, true);
        }
    }*/
}
