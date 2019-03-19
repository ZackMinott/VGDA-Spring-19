using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackdrop : MonoBehaviour
{

    public float speed; //speed of the object
    public bool startOnScreen; //whether it starts on the screen
    public int switchTime; //number of times the background should pass before switching
    public List<Sprite> backgroundImages; //list of images to change between
    private float sizeX; //size of the image
    private float cameraBound; //rightmost position the camera can see
    private int timesPassed; //number of times tihs background has been seen consecutively
    private int listLocation; //Location in the list of images

    // Use this for initialization
    void Start()
    {
        listLocation = 0;
        sizeX = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        cameraBound = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth,0)).x;

        if (startOnScreen)
        {
            transform.position = new Vector3(0, transform.localScale.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3((sizeX * transform.localScale.x / 2 + cameraBound), transform.localScale.y, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timesPassed >= switchTime)
        {
            listLocation++;
            if (listLocation > backgroundImages.Count)
            {
                listLocation = 0;
            }
            gameObject.GetComponent<SpriteRenderer>().sprite = backgroundImages[listLocation];
            timesPassed = 0;
            sizeX = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        }
        if (transform.position.x <= ((sizeX * transform.localScale.x / 2 + cameraBound) * -1 + (speed / 30)))
        {
            transform.position = new Vector3((sizeX * transform.localScale.x / 2 + cameraBound), transform.localScale.y, transform.position.z);
            timesPassed++;
        }
        transform.Translate(new Vector3(-1 * speed * Time.deltaTime, 0));
    }

}


