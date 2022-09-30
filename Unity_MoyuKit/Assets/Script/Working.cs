using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Working : MonoBehaviour
{
    public static Working instance;
    public bool isRunning = false;
    private void Awake()
    {
        instance = this;
    }

    public Text desc1;
    public Text desc2;

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            desc1.text = "打工中……\n当前时间：" + Manager.getCurrentTime();

            TimeSpan aim = Manager.getDurationTime();
            string temp = ((aim.TotalHours > 0) ? Math.Floor(aim.TotalHours) + "小时" : "")
                + Math.Floor(aim.TotalMinutes - Math.Floor(aim.TotalHours) * 60) + "分钟" +
                "（总计" + Math.Floor(aim.TotalSeconds) + "秒）";
            desc2.text = "解放倒计时\n" + temp;
        }
        else
        {
            desc1.text = "";
            desc2.text = "";
        }
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
