using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParallaxCamera : MonoBehaviour
{
    [System.Serializable]
    public class CameraMoveEvent : UnityEvent<float> { }

    public CameraMoveEvent OnCameraMove;

    private float oldPosition;


    private void Awake()
    {
        if (OnCameraMove == null)
            OnCameraMove = new CameraMoveEvent();
    }

    void Start()
    {
        oldPosition = transform.position.x;
    }
    void Update()
    {
        if (transform.position.x != oldPosition)
        {
            OnCameraMove.Invoke(oldPosition - transform.position.x);
            oldPosition = transform.position.x;
        }
    }
}
