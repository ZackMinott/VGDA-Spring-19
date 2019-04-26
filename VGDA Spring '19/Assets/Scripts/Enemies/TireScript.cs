using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireScript : MonoBehaviour
{
    public float jumpSpeed;
    private float starty;
    private float endy;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        starty = transform.localPosition.y;
        endy = transform.localPosition.y + 4f;
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y > endy)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, endy, 0);
            rigid.velocity = new Vector2(0, 0);
        }
        else if (transform.localPosition.y < starty)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, starty, 0);
            rigid.velocity = new Vector2(0, jumpSpeed);
        }
    }
}
