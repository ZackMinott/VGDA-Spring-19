using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireEnemy : MonoBehaviour
{
    public float jumpSpeed;
    public float endPoint;
    private float clampSpeed;
    private float starty;
    private float endy;
    private bool upTurn;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        starty = transform.localPosition.y;
        endy = starty + Random.Range(1f, endPoint);
        rigid = gameObject.GetComponent<Rigidbody2D>();
        upTurn = true;
        clampSpeed = jumpSpeed * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y > endy)
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y - (jumpSpeed * Time.deltaTime));
            upTurn = false;
        }
        else if (transform.localPosition.y < starty)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, starty);
            //rigid.velocity = new Vector2(0, rigid.velocity.y + ((0.5f * rigid.velocity.y + jumpSpeed) * Time.deltaTime));
            endy = starty + Random.Range(1f, endPoint);
            upTurn = true;
        }
        if (upTurn)
        {
            rigid.velocity = new Vector2(0, jumpSpeed);
        }
        rigid.velocity = new Vector2(0, Mathf.Clamp(rigid.velocity.y, -clampSpeed, clampSpeed));
    }
}
