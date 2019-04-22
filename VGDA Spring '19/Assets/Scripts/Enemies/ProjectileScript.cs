using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private ScrollingBackdrop[] backgroundSpeed;
    // Start is called before the first frame update
    void Start()
    {
        backgroundSpeed = FindObjectsOfType<ScrollingBackdrop>();

    }
  
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(backgroundSpeed[0].speed * -1 * Time.deltaTime, 0));
        if (transform.localPosition.x <= -50)
        {
            Destroy(gameObject);
        }
    }
}
