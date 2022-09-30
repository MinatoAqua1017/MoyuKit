using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    private void Awake()
    {
        instance = this;
    }

    enum PanelType
    {
        Working = 1,
        Resting = 2,
        Overtime = 3
    };

    PanelType current = PanelType.Resting;
    DateTime now, aim;
    
    // Start is called before the first frame update
    void Start()
    {
        now = System.DateTime.Now;
        aim = new DateTime(now.Year, now.Month, now.Day, 21, 0, 0);

        Working.Close();
        Resting.Run();
        Overtime.Close();

        PanelType last = current;
        CheckTimeStatus();
        if (last != current)
        {
            RunStatus();
        }
    }

    // Update is called once per frame
    void Update()
    {
        PanelType last = current;
        CheckTimeStatus();
        if (last != current)
        {
            RunStatus();
        }

        //Debug.Log(ServerTime.getCurrentTime());
    }

    void CheckTimeStatus()
    {
        //now = System.DateTime.Now;
        now = ServerTime.getCurrentTime();
        if (now.Hour >= 11 && now.Hour < 21)
        {
            current = PanelType.Working;
        }
        else if (now.Hour >= 21 && now.Hour < 24)
        {
            current = PanelType.Overtime;
        }
        else 
        {
            current = PanelType.Resting;
        }
    }

    void RunStatus()
    {
        Working.Close();
        Resting.Close();
        Overtime.Close();
        switch (current)
        {
            case PanelType.Working:
                Working.Run();
                break;
            case PanelType.Resting:
                Resting.Run();
                break;
            case PanelType.Overtime:
                Overtime.Run();
                break;
            default:
                break;
        }
    }

    public static string getCurrentTime()
    {
        DateTime now = instance.now;
        return (now.Year + "年" + now.Month + "月" + now.Day + "日 " +
            (now.Hour < 10 ? "0" + now.Hour : now.Hour.ToString()) + ":" +
            (now.Minute < 10 ? "0" + now.Minute : now.Minute.ToString()) + ":" +
            (now.Second < 10 ? "0" + now.Second : now.Second.ToString())
            );
    }

    public static DateTime getAimTime()
    {
        return instance.aim;
    }

    public static TimeSpan getDurationTime()
    {
        return instance.now.Subtract(instance.aim).Duration();
    }

    public void Close()
    {
        Application.Quit();
    }
}
