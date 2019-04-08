using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject pickupEffect;
    public GameObject shieldPrefab;

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
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //Instantiates shield as a child of the player
        var shield = Instantiate(shieldPrefab, player.transform.position, Quaternion.identity);
        shield.transform.parent = player.transform;

        //activates shieldPowerUp
        playerMain.shieldOn = true;
        playerMain.canDie = false;

        Destroy(gameObject);
    }

    
}
