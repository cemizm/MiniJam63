using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private static MainController instance;

    public TimeController timeController;

    public AudioController audioController;

    public IntroController introController;

    public GameManager gameManager;

    public static TimeController TimeController => instance.timeController;

    public static IntroController IntroController => instance.introController;

    public static GameManager GameManager => instance.gameManager;

    void Awake()
    {
        instance = this;
    }
}
