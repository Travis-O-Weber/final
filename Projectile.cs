using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        
            //Debug.Log("Projectile has hit outside loop: " + other.name);

        if (other.gameObject.tag == "Destructable")
        {
            GameObject playerCreature = GameObject.Find("playerbody");
            if (playerCreature != null)
            {
                PlayerColorManager colorManager = playerCreature.GetComponent<PlayerColorManager>();
                if (colorManager != null)
                {
                    colorManager.DarkenColor();
                }
                else
                {
                    Debug.LogError("PlayerColorManager component not found on Creature");
                }
            }
            else
            {
                Debug.LogError("Creature GameObject not found");
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    
}
