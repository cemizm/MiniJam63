using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;

    bool destroyed = false;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (destroyed == false)
        {
            destroyed = true;
            Destroy(gameObject);

            MainController.GameManager.EatCoin();
        }
    }

    void Update()
    {
        animator.speed = MainController.TimeController.WorldSpeed;
    }
}
