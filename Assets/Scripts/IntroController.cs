using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    public static bool ShowIntro = true;

    public GameObject IntroCanvas;

    // Start is called before the first frame update
    void Start()
    {
        IntroCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (IntroCanvas.activeSelf && Input.GetButtonDown("Submit"))
        {
            IntroCanvas.SetActive(false);

            MainController.GameManager.ResumeGame();
        }
    }

    public void ShowIntroUI()
    {
        if (ShowIntro)
        {
            MainController.GameManager.PauseGame();

            ShowIntro = false;
            IntroCanvas.SetActive(true);
        }
    }
}
