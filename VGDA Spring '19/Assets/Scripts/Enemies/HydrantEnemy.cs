using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrantEnemy : MonoBehaviour
{
    private float nextFirePoint; //the next time the cloud will jump
    private bool fireReady; //whether the cloud is prepared to jump
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        fireReady = true;
        nextFirePoint = Time.time + Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (fireReady && Time.time >= nextFirePoint)
        {
            Object.Instantiate(projectile, new Vector3(transform.localPosition.x,transform.localPosition.y,0), new Quaternion(0,0,0,0));
            fireReady = false;
        }
        else if (!fireReady)
        {
            nextFirePoint = Time.time + Random.Range(1f, 3f);
            fireReady = true;
        }
    }
}
