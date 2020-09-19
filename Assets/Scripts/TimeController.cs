using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeController : MonoBehaviour
{
    public float WorldSpeed = 1;

    public float MinSpeed = 0.3f;

    public float MaxSpeed = 3;

    public float DefaultSpeed = 1;

    public float UserSmoothness = 2;

    public float SystemSmoothness = 4;


    void FixedUpdate()
    {
        float sp = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        if (Math.Abs(sp) > 0)
        {
            WorldSpeed += sp * UserSmoothness;
            WorldSpeed = Math.Min(MaxSpeed, Math.Max(MinSpeed, WorldSpeed));
        }
        else if (WorldSpeed > DefaultSpeed)
        {
            WorldSpeed -= SystemSmoothness * Time.deltaTime;
            WorldSpeed = Math.Max(DefaultSpeed, WorldSpeed);
        }
        else if (WorldSpeed < DefaultSpeed)
        {
            WorldSpeed += SystemSmoothness * Time.deltaTime;
            WorldSpeed = Math.Min(DefaultSpeed, WorldSpeed);
        }
    }
}
