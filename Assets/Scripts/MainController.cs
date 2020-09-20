using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private static MainController instance;

    public TimeController timeController;

    public AudioController audioController;

    public static TimeController TimeController => instance.timeController;

    void Awake()
    {
        instance = this;
    }
}
