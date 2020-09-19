using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    bool destroyed = false;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (destroyed == false)
        {
            destroyed = true;
            Destroy(gameObject);
            ScoreTextScript.coinAmount += 1;
        }
    }
}
