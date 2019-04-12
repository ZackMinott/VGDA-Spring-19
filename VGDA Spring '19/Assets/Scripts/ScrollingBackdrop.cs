using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackdrop : MonoBehaviour
{
    public GameObject[] levelFramesPark;
    public GameObject[] levelFramesCity;
    public GameObject[] levelFramesJunkyard;

    public float speed; //speed of the object
    public bool startOnScreen; //whether it starts on the screen
    public int switchTime; //number of times the background should pass before switching
    public List<Sprite> backgroundImages; //list of images to change between
    //GameSession gameSesh;

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
            if (listLocation == backgroundImages.Count)
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

    private void LevelGeneration()
    {
        int frameSelect = 0;
        GameObject generated = null;

        Object.Destroy(transform.GetChild(0).gameObject);

        switch (listLocation)
        {
            case 0:
                frameSelect = Random.Range(0, levelFramesPark.Length - 1);
                generated = Instantiate(levelFramesPark[frameSelect]);
                generated.transform.parent = gameObject.transform;
                break;
            case 1:
                frameSelect = Random.Range(0, levelFramesCity.Length - 1);
                generated = Instantiate(levelFramesCity[frameSelect]);
                generated.transform.parent = gameObject.transform;
                break;
            case 2:
                frameSelect = Random.Range(0, levelFramesJunkyard.Length - 1);
                generated = Instantiate(levelFramesJunkyard[frameSelect]);
                generated.transform.parent = gameObject.transform;
                break;
            default:
                frameSelect = 0;
                break;
        }
    }

}


