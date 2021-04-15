using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.Networking;
using SimpleJSON;

public class DataLoader : MonoBehaviour
{
    //For calculating active case count
    //Unit: Day
    int _averageVirusRetentionTime = 14;

    string _caseDataFilePath;

    void Awake()
    {
        _caseDataFilePath = Path.Combine(Application.persistentDataPath, "TorontoCOVID19Cases.tsv");
        if (File.Exists(_caseDataFilePath))
        {
            ReadCaseDataFile();
        }
        else
            StartCoroutine(DownloadCaseDataToFile());
    }

    IEnumerator DownloadCaseDataToFile()
    {
        var unityWebRequest = new UnityWebRequest("https://ckan0.cf.opendata.inter.prod-toronto.ca/datastore/dump/e5bf35bc-e681-43da-b2ce-0242d00922ad?format=tsv", UnityWebRequest.kHttpVerbGET);
        unityWebRequest.downloadHandler = new DownloadHandlerFile(_caseDataFilePath);
        yield return unityWebRequest.SendWebRequest();
        if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
            Debug.LogError(unityWebRequest.error);
        else
        {
            Debug.Log("File successfully downloaded and saved to " + _caseDataFilePath);
            ReadCaseDataFile();
        }
    }

    private void ReadCaseDataFile()
    {
        LoadRawDataset();
        CalculatePlaceDaysData();
        CalculateNeighbourhoodsWithMaxCaseCount();
        CalculatePlaceDaysWithMaxCaseCount();
    }

    private void LoadRawDataset()
    {
        DateTime lastEpisodeDate = Neighbourhood.lastEpisodeDate;
        DateTime firstEpisodeDate = Neighbourhood.firstEpisodeDate;

        string caseDataFileContents = File.ReadAllText(_caseDataFilePath);

        string[] lines = caseDataFileContents.Split('\n');
        for (int i = 1; i < lines.Length; i++)
        {
            string[] singleCaseData = lines[i].Split('\t');
            //Legth check
            if (singleCaseData.Length == 18)
            {
                Neighbourhood caseNeighbourhood = CheckCaseNeighbourhood(singleCaseData);
                DateTime episodeDate = CheckCaseEpisodeDate(singleCaseData);

                if (episodeDate > lastEpisodeDate)
                {
                    lastEpisodeDate = episodeDate;
                }
                else if (episodeDate < firstEpisodeDate)
                {
                    firstEpisodeDate = episodeDate;
                }

                if (caseNeighbourhood != null)
                {
                    if (IsConfirmed(singleCaseData))
                    {
                        //Check if episode day is already recorded
                        if (!caseNeighbourhood.episodeDays.ContainsKey(episodeDate))
                        {
                            caseNeighbourhood.episodeDays[episodeDate] = new PlaceDay(caseNeighbourhood);
                        }
                        //Add to episode day
                        caseNeighbourhood.episodeDays[episodeDate].newCase++;

                        caseNeighbourhood.cumulativeCaseCount++;
                        if (IsActive(singleCaseData))
                        {
                            caseNeighbourhood.activeCaseCount++;
                        }
                        else if (IsDeceased(singleCaseData))
                        {
                            caseNeighbourhood.deceasedCaseCount++;
                        }

                        if (CurrentlyHospitalized(singleCaseData))
                        {
                            caseNeighbourhood.currentlyHospitalizedCaseCount++;
                            caseNeighbourhood.everHospitalizedCaseCount++;
                        }
                        else if (EverHospitalized(singleCaseData))
                        {
                            caseNeighbourhood.everHospitalizedCaseCount++;
                        }

                        if (CurrentlyInICU(singleCaseData))
                        {
                            caseNeighbourhood.currentlyInICUCaseCount++;
                            caseNeighbourhood.everInICUCaseCount++;
                        }
                        else if (EverInICU(singleCaseData))
                        {
                            caseNeighbourhood.everInICUCaseCount++;
                        }

                        if (CurrentlyIntubated(singleCaseData))
                        {
                            caseNeighbourhood.currentlyIntubatedCaseCount++;
                            caseNeighbourhood.everIntubatedCaseCount++;
                        }
                        else if (EverIntubated(singleCaseData))
                        {
                            caseNeighbourhood.everIntubatedCaseCount++;
                        }
                    }
                }
            }
        }
        Neighbourhood.lastEpisodeDate = lastEpisodeDate;
        Neighbourhood.firstEpisodeDate = firstEpisodeDate;
        Neighbourhood.totalPlaceDays = lastEpisodeDate.Subtract(firstEpisodeDate).Days;
    }

    //Calculate and assign case data value for each episode day in each neighbourhood
    private void CalculatePlaceDaysData()
    {
        foreach (Neighbourhood neighbourhood in Neighbourhood.allNeighbourhoodsInNumericalOrder)
        {
            //For calculating active case count
            int dailyActiveCaseCount = 0;

            for (DateTime i = Neighbourhood.firstEpisodeDate; i <= Neighbourhood.lastEpisodeDate; i = i.AddDays(1))
            {
                //Fill empty episode days with generated days
                if (!neighbourhood.episodeDays.ContainsKey(i))
                {
                    neighbourhood.episodeDays[i] = new PlaceDay(neighbourhood);
                }

                //For calculating cumulative case count
                DateTime lastEpisodeDate = i.AddDays(-1);
                if (neighbourhood.episodeDays.ContainsKey(lastEpisodeDate))
                {
                    neighbourhood.episodeDays[i].cumulativeCase = neighbourhood.episodeDays[i].newCase + neighbourhood.episodeDays[lastEpisodeDate].cumulativeCase;
                }
                //In case this is the first episode date on record
                else
                {
                    neighbourhood.episodeDays[i].cumulativeCase = neighbourhood.episodeDays[i].newCase;
                }

                //Calculate active case count
                dailyActiveCaseCount += neighbourhood.episodeDays[i].newCase;
                DateTime lastDayOfVirusRetention = i.AddDays(-_averageVirusRetentionTime);
                if (neighbourhood.episodeDays.ContainsKey(lastDayOfVirusRetention))
                {
                    dailyActiveCaseCount -= neighbourhood.episodeDays[lastDayOfVirusRetention].newCase;
                }
                neighbourhood.episodeDays[i].activeCase = dailyActiveCaseCount;
            }
        }
    }

    private void CalculateNeighbourhoodsWithMaxCaseCount()
    {
        List<Neighbourhood>[] neighbourhoodsWithMaxCaseCount = new List<Neighbourhood>[9];

        foreach (Neighbourhood.LatestCaseDataType caseType in Enum.GetValues(typeof(Neighbourhood.LatestCaseDataType)))
        {
            int caseTypeIndex = (int)caseType;

            neighbourhoodsWithMaxCaseCount[caseTypeIndex] = new List<Neighbourhood>();
            neighbourhoodsWithMaxCaseCount[caseTypeIndex].Add(Neighbourhood.allNeighbourhoodsInNumericalOrder[0]);
            for (int i = 1; i < Neighbourhood.allNeighbourhoodsInNumericalOrder.Length; i++)
            {
                if (neighbourhoodsWithMaxCaseCount[caseTypeIndex][0].caseCountData[caseTypeIndex] < Neighbourhood.allNeighbourhoodsInNumericalOrder[i].caseCountData[caseTypeIndex])
                {
                    neighbourhoodsWithMaxCaseCount[caseTypeIndex].Clear();
                    neighbourhoodsWithMaxCaseCount[caseTypeIndex].Add(Neighbourhood.allNeighbourhoodsInNumericalOrder[i]);
                }
                else if (neighbourhoodsWithMaxCaseCount[caseTypeIndex][0].caseCountData[caseTypeIndex] == Neighbourhood.allNeighbourhoodsInNumericalOrder[i].caseCountData[caseTypeIndex])
                {
                    neighbourhoodsWithMaxCaseCount[caseTypeIndex].Add(Neighbourhood.allNeighbourhoodsInNumericalOrder[i]);
                }
            }
        }

        Neighbourhood.neighbourhoodsWithMaxCaseCount = neighbourhoodsWithMaxCaseCount;
    }

    private void CalculatePlaceDaysWithMaxCaseCount()
    {
        //Universal but inefficient way to calculate and assign values for placedays with max case count
        //To implement efficient calculations, calculation method will vary depending on data type
        List<PlaceDay>[] placeDaysWithMaxCaseCount = new List<PlaceDay>[3];

        foreach (Neighbourhood.DailyCaseDataType caseType in Enum.GetValues(typeof(Neighbourhood.DailyCaseDataType)))
        {
            int caseTypeIndex = (int)caseType;

            placeDaysWithMaxCaseCount[caseTypeIndex] = new List<PlaceDay>();
            placeDaysWithMaxCaseCount[caseTypeIndex].Add(Neighbourhood.allNeighbourhoodsInNumericalOrder[0].episodeDays[Neighbourhood.firstEpisodeDate]);
            for (int i = 0; i < Neighbourhood.allNeighbourhoodsInNumericalOrder.Length; i++)
            {
                foreach (KeyValuePair<DateTime, PlaceDay> dayEntry in Neighbourhood.allNeighbourhoodsInNumericalOrder[i].episodeDays)
                {
                    if (placeDaysWithMaxCaseCount[caseTypeIndex][0].caseCountData[caseTypeIndex] < dayEntry.Value.caseCountData[caseTypeIndex])
                    {
                        placeDaysWithMaxCaseCount[caseTypeIndex].Clear();
                        placeDaysWithMaxCaseCount[caseTypeIndex].Add(dayEntry.Value);
                    }
                    else if (placeDaysWithMaxCaseCount[caseTypeIndex][0].caseCountData[caseTypeIndex] == dayEntry.Value.caseCountData[caseTypeIndex])
                    {
                        placeDaysWithMaxCaseCount[caseTypeIndex].Add(dayEntry.Value);
                    }
                }
            }
        }

        Neighbourhood.placeDaysWithMaxCaseCount = placeDaysWithMaxCaseCount;
    }

    private Neighbourhood CheckCaseNeighbourhood(string[] caseData)
    {
        foreach (Neighbourhood neighbourhood in Neighbourhood.allNeighbourhoodsInNumericalOrder)
        {
            if (caseData[4]==neighbourhood.displayName)
            {
                return neighbourhood;
            }
        }
        return null;
    }

    private DateTime CheckCaseEpisodeDate(string[] caseData)
    {
        DateTime episodeDate;
        if (DateTime.TryParse(caseData[8], out episodeDate))
        {
            return episodeDate;
        }
        return new DateTime();
    }

    private bool IsConfirmed(string[] caseData)
    {
        if (caseData[7] == "CONFIRMED")
        {
            return true;
        }
        return false;
    }

    private bool IsActive(string[] caseData)
    {
        if (caseData[11] == "ACTIVE")
        {
            return true;
        }
        return false;
    }

    private bool IsDeceased(string[] caseData)
    {
        if (caseData[11] == "FATAL")
        {
            return true;
        }
        return false;
    }

    private bool CurrentlyHospitalized(string[] caseData)
    {
        if (caseData[12] == "Yes")
        {
            return true;
        }
        return false;
    }

    private bool CurrentlyInICU(string[] caseData)
    {
        if (caseData[13] == "Yes")
        {
            return true;
        }
        return false;
    }

    private bool CurrentlyIntubated(string[] caseData)
    {
        if (caseData[14] == "Yes")
        {
            return true;
        }
        return false;
    }

    private bool EverHospitalized(string[] caseData)
    {
        if (caseData[15] == "Yes")
        {
            return true;
        }
        return false;
    }

    private bool EverInICU(string[] caseData)
    {
        if (caseData[16] == "Yes")
        {
            return true;
        }
        return false;
    }

    private bool EverIntubated(string[] caseData)
    {
        if (caseData[17] == "Yes")
        {
            return true;
        }
        return false;
    }

    ///DEPRECATED///
    ///Data Request Implementation V.2///
    ///Impracticable Data Request Implementation(incomplete data, limited JSON file size)///
    /*string caseDataFilePath;

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
    }*/

    ///DEPRECATED///
    ///Data Request Implementation V.1///
    ///Inefficient Precise Data Request Implementation(too many requests, gateway timeout)///
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
