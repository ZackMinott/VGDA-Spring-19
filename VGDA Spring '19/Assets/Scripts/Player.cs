using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Player : MonoBehaviour
{
    [Header("Player Attributes")]
    [SerializeField] private float upForce;
    [SerializeField] private float smashForce;
    [SerializeField] private float dashSpeed = 3f;
    [SerializeField] private float dashDuration = 0.4f;

    [Header("Camera Shake")]
    public float shakeMagnitude= .4f;
    public float shakeRoughness = 4f;
    public float fadeInTime = .1f;
    public float fadeOutTime = 1f;

    private ScrollingBackdrop[] backgroundSpeed;

   // private CameraShake cameraShake;
    private Rigidbody2D rb2d;
    private bool isDead = false;
    private bool isSmashing = false;
    private bool inAir = false;
    public bool canDie = true;

    //Power Ups
    [NonSerialized] public bool shieldOn;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //cameraShake = GetComponent<CameraShake>();

        backgroundSpeed = FindObjectsOfType<ScrollingBackdrop>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            FlappyJump();
            Smash();
            Dash();

            Debug.Log(inAir);

        }
    }

    void FlappyJump()
    {
        if (Input.GetMouseButtonDown(0) && !isSmashing)
        {
            rb2d.velocity = Vector2.zero;

            rb2d.AddForce(new Vector2(0, upForce));
            //Checks to see if player is in the air
            inAir = true;
        }
    }

    
    void Smash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inAir)
        {
            rb2d.AddForce(new Vector2(0, -smashForce));

            isSmashing = true;
        }
    }

    //will need to grab side scrolling script and add post processing effect
    void Dash()
    {
        //TODO: Add a short cooldown?
        if (Input.GetMouseButton(1))
        {
            StartCoroutine(DashSpeed());
        }
    }

    IEnumerator DashSpeed()
    {
        for (int i = 0; i < backgroundSpeed.Length; i++)
        {
            backgroundSpeed[i].speed *= dashSpeed;
        }

        yield return new WaitForSeconds(dashDuration);

        for (int i = 0; i < backgroundSpeed.Length; i++)
        {
            backgroundSpeed[i].speed /= dashSpeed;
        }
    }

    //TODO: If smashing, Destroy Enemy with Particle Effect 
    //TODO: Instantiate Particle effect on ground hit
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Floor")
        {
            shieldPickup();
            PlayerDeath();
        }

        if (other.gameObject.tag == "Floor")
        {
            if (isSmashing)
            {
                //Add camera shake
                CameraShaker.Instance.ShakeOnce(shakeMagnitude, shakeRoughness, fadeInTime, fadeOutTime);
            }

            //Checks to see if play is on the ground
            inAir = false;
            isSmashing = false;
        }
    }


    //TODO: Trigger Power Up Effects
    void onTriggerEnter2D(Collider2D other)
    {

    }

    //activates when shield is picked up
    public void shieldPickup()
    {
        if (shieldOn)
        {
            Destroy(FindObjectOfType<Shield>());
            isInvulnerable(0.3f);
            shieldOn = false;
        }
    }

    IEnumerator isInvulnerable(float duration)
    {
        yield return new WaitForSeconds(duration);
        canDie = true;
    }


    public void boostPickup()
    {

    }

    //may or may not need
    public void timeSlowPickup()
    {

    }

    void PlayerDeath()
    {
        //Not final
        if(canDie)
            isDead = true;
    }


}
