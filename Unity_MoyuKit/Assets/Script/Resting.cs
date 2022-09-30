using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resting : MonoBehaviour
{
    public static Resting instance;
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
            desc1.text = "这种时间不应该在工作的！\n不要打开这个软件！";
        }
        else
        {
            desc1.text = "";
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
