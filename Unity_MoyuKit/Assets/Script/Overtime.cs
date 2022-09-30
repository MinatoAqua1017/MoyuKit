using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overtime : MonoBehaviour
{
    public static Overtime instance;
    public bool isRunning = false;
    private void Awake()
    {
        instance = this;
    }

    public GameObject panel1;
    public GameObject panel2;
    public Text desc;

    bool isSad = false;

    // Update is called once per frame
    void Update()
    {
        if (isRunning && !panel1.activeSelf && !isSad)
        {
            panel1.SetActive(true);
            panel2.SetActive(false);
        }
        else
        {
            if (isSad)
            {
                TimeSpan aim = Manager.getDurationTime();
                desc.text = "距离该下班的时间已经过去了：\n" +
                    Math.Floor(aim.TotalHours) + "小时" +
                    Math.Floor(aim.TotalMinutes - Math.Floor(aim.TotalHours) * 60) + "分钟\n" +
                    "（总计" + Math.Floor(aim.TotalSeconds) + "秒）";
            }
            if (!isRunning)
            {
                panel1.SetActive(false);
                panel2.SetActive(false);
            }
        }
    }

    public void Sad()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
        isSad = true;
    }

    public static void Run()
    {
        instance.isRunning = true;
    }

    public static void Close()
    {
        instance.isRunning = false;
    }
}
