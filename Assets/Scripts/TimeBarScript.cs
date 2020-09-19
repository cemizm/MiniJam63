using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarScript : MonoBehaviour
{
    public Slider positiveSlider;

    public Slider negativSlider;

    public TimeController timeController;

    private float max, min;

    void Start()
    {
        max = timeController.MaxSpeed - timeController.DefaultSpeed;
        min = timeController.MinSpeed - timeController.DefaultSpeed;
    }

    void Update()
    {
        float speed = timeController.WorldSpeed - timeController.DefaultSpeed;

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
