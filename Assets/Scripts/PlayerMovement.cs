using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public AudioSource jumpingSound;

    public float runSpeed = 40f;

    public bool AutoRun = true;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    private MovementController platform;

    public float PlatformSpeed
    {
        get
        {
            return (platform.Forward ? platform.MoveSpeed : -platform.MoveSpeed) * 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (AutoRun)
            horizontalMove = runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (platform != null)
            horizontalMove += PlatformSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            if (!jumpingSound.isPlaying && !animator.GetBool("IsJumping"))
            {
                jumpingSound.Play();
            }
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            ScoreTextScript.coinAmount = 0;
        }

        if (other.gameObject.CompareTag("Platform"))
        {
            platform = other.gameObject.GetComponent<MovementController>();
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            platform = null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Intro"))
            MainController.IntroController.ShowIntroUI();
    }
}
