using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{

    [SerializeField] Creature playerCreature;
    ProjectileThrower projectileThrower;
    void Start()
    {
        projectileThrower = playerCreature.GetComponent<ProjectileThrower>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 input = Vector3.zero;

         if (Input.GetKey(KeyCode.W))
         {
             input.y += 1;
         }

         if (Input.GetKey(KeyCode.S))
         {
             input.y += -1;
         }

        if (Input.GetKey(KeyCode.A))
        {
            input.x += -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            input.x += 1;
        }
  
      if (Input.GetKeyDown(KeyCode.Q))
    {
        // Find the "Creature" GameObject
        GameObject creature = GameObject.Find("Creature");
        if (creature != null)
        {
            // Find the "playerbody" GameObject as a child of "Creature"
            Transform playerBodyTransform = creature.transform.Find("playerbody");
            if (playerBodyTransform != null)
            {
                SpriteRenderer spriteRenderer = playerBodyTransform.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = Color.white; // Change back to white
                }
                else
                {
                    Debug.LogError("SpriteRenderer not found on the playerbody object");
                }
            }
            else
            {
                Debug.LogError("playerbody object not found under Creature");
            }
        }
        else
        {
            Debug.LogError("Creature GameObject not found");
        }
    }
        

    if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            projectileThrower.Launch(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        playerCreature.MoveCreature(input);   

        // Call the new RotatePlayer method
        RotatePlayerToCursor(); 

void RotatePlayerToCursor()
{
    Vector3 mousePosition = Input.mousePosition;
    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    // Set this to the inverse of your camera's Z position
    mousePosition.z = Camera.main.transform.position.z * -1;

    Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

    Debug.DrawLine(transform.position, mousePosition, Color.red); // For debugging

    transform.up = direction.normalized; // The direction should be normalized
}
    
    }
}
