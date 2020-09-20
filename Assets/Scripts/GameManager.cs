using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool ShowIntro = true;

    public bool ResetToStart;

    public GameObject ResetPosition;

    public GameObject Player;

    public GameObject IntroCanvas;

    public GameObject RestartCanvas;

    public AudioSource audioSourceDie;

    void Start()
    {
        if (ResetToStart)
            Player.transform.position = ResetPosition.transform.position;

        IntroCanvas.SetActive(false);
        RestartCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            if (IntroCanvas.activeSelf)
            {
                IntroCanvas.SetActive(false);
                ResumeGame();
            }
            else if (RestartCanvas.activeSelf)
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
                ResumeGame();

                ScoreTextScript.coinAmount = 0;
            }
        }
    }

    public void ShowIntroUI()
    {
        if (ShowIntro)
        {
            PauseGame();

            ShowIntro = false;
            IntroCanvas.SetActive(true);
        }
    }

    public void ShowRestartUI()
    {
        PauseGame();

        audioSourceDie.Play();

        RestartCanvas.SetActive(true);
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
