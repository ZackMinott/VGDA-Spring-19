using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private GameObject pickupEffect;
    [SerializeField] private GameObject speedPrefab;

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

        //TODO: Call the SpeedBoost Function inside Player
        //Increase Background speed by a large amount for a short duration, use coroutine 

        

        Destroy(gameObject);
    }

}
