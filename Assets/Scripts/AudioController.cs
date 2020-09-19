using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;

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
            audioSource.pitch = 1 + (speed / max * 0.2f);
        }
        else
        {
            audioSource.pitch = 1 - (speed / min * 0.1f);
        }
    }
}
