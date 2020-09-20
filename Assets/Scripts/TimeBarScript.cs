using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarScript : MonoBehaviour
{
    public Slider positiveSlider;

    public Slider negativSlider;

    private float max, min;

    void Start()
    {
        max = MainController.TimeController.MaxSpeed - MainController.TimeController.DefaultSpeed;
        min = MainController.TimeController.MinSpeed - MainController.TimeController.DefaultSpeed;
    }

    void Update()
    {
        float speed = MainController.TimeController.WorldSpeed - MainController.TimeController.DefaultSpeed;

        if (speed >= 0)
        {
            positiveSlider.value = speed / max;
            negativSlider.value = 0;
        }
        else
        {
            positiveSlider.value = 0;
            negativSlider.value = speed / min;
        }
    }
}
