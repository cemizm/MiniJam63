using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool ShowIntro = true;

    public bool ResetToStart;

    public GameObject ResetPosition;

    public GameObject Player;

    public GameObject IntroCanvas;

    public GameObject RestartCanvas;

    public Text textHighScore;

    public Text textScore;

    public AudioSource audioSourceDie;

    public AudioSource audioSourceCoin;

    private static int highScore;
    private int score;

    void Start()
    {
        if (ResetToStart)
            Player.transform.position = ResetPosition.transform.position;

        IntroCanvas.SetActive(false);
        RestartCanvas.SetActive(false);

        UpdateScores();
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
            }
        }
    }

    void UpdateScores()
    {
        textHighScore.text = highScore.ToString();
        textScore.text = score.ToString();
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

    public void EatCoin()
    {
        score++;
        if (score > highScore)
            highScore = score;

        UpdateScores();

        audioSourceCoin.Play();
    }
}
