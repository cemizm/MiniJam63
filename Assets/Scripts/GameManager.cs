using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool ResetToStart;

    public GameObject ResetPosition;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        if (ResetToStart)
            Player.transform.position = ResetPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
