using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private static MainController instance;



    public TimeController timeController;

    public GameManager gameManager;

    public static TimeController TimeController => instance.timeController;

    public static GameManager GameManager => instance.gameManager;



    void Awake()
    {
        instance = this;
    }
}
