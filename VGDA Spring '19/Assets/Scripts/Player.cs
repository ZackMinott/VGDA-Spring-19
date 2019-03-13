using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Attributes")]
    [SerializeField] private float upForce;
    [SerializeField] private float smashForce;

    private CameraShake cameraShake;
    private Rigidbody2D rb2d;
    private bool isDead = false;
    private bool isSmashing = false;
    private bool inAir = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cameraShake = GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            FlappyJump();
            Smash();

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

    //Add camera shake
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

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            if (isSmashing)
            {
                //Add camera shake
                cameraShake.setDuration();
            }

            //Checks to see if play is on the ground
            inAir = false;
            isSmashing = false;
        }
    }

   
}
