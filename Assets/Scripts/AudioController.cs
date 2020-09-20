using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;

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
            audioSource.pitch = 1 + (speed / max * 0.2f);
        }
        else
        {
            audioSource.pitch = 1 - (speed / min * 0.1f);
        }
    }
}
