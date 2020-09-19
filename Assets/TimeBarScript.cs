using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarScript : MonoBehaviour
{
    public Slider slider; 

    public void SetSpeed(float factor)
    {
        slider.value = factor; 
    }

    public void SetMaxSpeed(float maxSpeed)
    {
        slider.maxValue = maxSpeed; 
    }
}
