using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public Animator animator;
    public TimeController timeController;
    public AudioSource audioSource;

    bool destroyed = false;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (destroyed == false)
        {
            destroyed = true;
            Destroy(gameObject);
            audioSource.Play();
            ScoreTextScript.coinAmount += 1;
        }
    }

    void Update()
    {
        animator.speed = timeController.WorldSpeed;
    }
}
