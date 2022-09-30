using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerTime : MonoBehaviour
{
    public static ServerTime instance;
    private void Awake()
    {
        instance = this;
    }

    public static DateTime getCurrentTime()
    {
        DateTime now = System.DateTime.Now;

        UnityWebRequest request = UnityWebRequest.Get("http://quan.suning.com/getSysTime.do");
        request.timeout = 10000;
        try
        {
            request.SendWebRequest();

            if (request.error == null)
            {
                UTCTime time = JsonUtility.FromJson<UTCTime>(request.downloadHandler.text);
                now = DateTime.Parse(time.sysTime2);
            }

        }catch (Exception e)
        {
            Debug.Log(e);
        }

        return now;
    }
}

public class UTCTime
{
    public string sysTime2 = "";
    public string sysTime1 = "";
}
