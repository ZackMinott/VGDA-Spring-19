using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudEnemy : MonoBehaviour
{
    public float jumpHeight; //how high it jumps, 2 is a good default number
    public float jumpSpeed; //how fast it jumps, 50 is a good default number
    private float nextJumpPoint; //the next time the cloud will jump
    private bool jumpReady; //whether the cloud is prepared to jump
    private float starty; //where the cloud started
    private Rigidbody2D rigid; //the rigidbody of the cloud

    // Start is called before the first frame update
    void Start()
    {
        starty = transform.localPosition.y;
        nextJumpPoint = Time.time + Random.Range(1f, 3f);
        rigid = gameObject.GetComponent<Rigidbody2D>();
        jumpReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpReady && Time.time >= nextJumpPoint)
        {
            rigid.AddForce(new Vector2(0, jumpSpeed));
            if (transform.localPosition.y >= starty + jumpHeight)
            {
                jumpReady = false;
            }
        }
        else if (transform.localPosition.y == starty && !jumpReady)
        {
            nextJumpPoint = Time.time + Random.Range(1f, 3f);
            jumpReady = true;
        }

        if (transform.localPosition.y < starty)
        {
            transform.localPosition = new Vector2(transform.localPosition.x,starty);
        }
    }

}
