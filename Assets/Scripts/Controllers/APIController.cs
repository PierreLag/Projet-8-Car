using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Globalization;
using System.Net;

public class APIController : MonoBehaviour
{
    private static bool lastInternetCheck;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
