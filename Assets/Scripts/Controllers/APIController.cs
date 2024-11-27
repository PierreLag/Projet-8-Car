using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Globalization;
using System.Net;

public class APIController : MonoBehaviour
{
    [SerializeField]
    private string apiUrlBase;

    private static bool lastInternetCheck;
    private static object latestResponse;
    private static APIController _this;

    void Awake()
    {
        if (_this != null)
            Destroy(this.gameObject);
        else
        {
            _this = this;
            DontDestroyOnLoad(this);
        }
    }

    public static bool CheckInternetConnection(int timeoutMs = 10000, string url = null)
    {
        try
        {
            url ??= CultureInfo.InstalledUICulture switch
            {
                { Name: var n } when n.StartsWith("fa") => // Iran
                    "http://www.aparat.com",
                { Name: var n } when n.StartsWith("zh") => // China
                    "http://www.baidu.com",
                _ =>
                    "http://www.gstatic.com/generate_204",
            };

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.KeepAlive = false;
            request.Timeout = timeoutMs;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                lastInternetCheck = true;
                return true;
            }
        }
        catch
        {
            lastInternetCheck = false;
            return false;
        }
    }

    public static bool GetLastInternetcheck()
    {
        return lastInternetCheck;
    }

    public static IEnumerator GetAllCars()
    {
        UnityWebRequest apiRequest = UnityWebRequest.Get(_this.apiUrlBase + "GetAllCars.php");
        apiRequest.SendWebRequest();

        while (!apiRequest.isDone)
        {
            yield return null;
        }

        List<Car> response = new List<Car>();
        switch (apiRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
                response = null;
                break;
            case UnityWebRequest.Result.Success:
                string furnituresJSON = apiRequest.downloadHandler.text;
                response = Car.ListFromJSON(furnituresJSON);
                break;
            default:
                break;
        }

        Debug.Log(response);
        latestResponse = response;
    }

    public static object GetLatestResponse()
    {
        return latestResponse;
    }

    public static void ResetLatestResponse()
    {
        latestResponse = null;
    }
}
