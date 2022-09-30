using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase : MonoBehaviour
{
    public static PanelBase instance;
    public bool isRunning = false;

    public static void Run()
    {
        instance.isRunning = true;
    }

    public static void Close()
    {
        instance.isRunning = false;
    }
}
