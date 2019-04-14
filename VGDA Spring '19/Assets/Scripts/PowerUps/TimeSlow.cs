using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlow : MonoBehaviour
{
    [SerializeField] private GameObject pickupEffect;
    [SerializeField] private GameObject timeSlowPrefab;

    private Player playerMain;

    void onTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }

        playerMain = FindObjectOfType<Player>();
    }

    void Pickup(Collider2D player)
    {
        //Might not need 
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //TODO: Call the timeSlow function inside player

        Destroy(gameObject);
    }



}
