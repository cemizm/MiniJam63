using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool ResetToStart;

    public GameObject ResetPosition;

    public GameObject Player;

    void Start()
    {
        if (ResetToStart)
            Player.transform.position = ResetPosition.transform.position;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
