using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Creature : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float speed = 5f;
    [SerializeField] int health = 3;
    [SerializeField] int stamina = 3;

    public enum CreatureMovementType { tf, physics };
    [SerializeField] CreatureMovementType movementType = CreatureMovementType.tf;

    [Header("Physics")]
    [SerializeField] LayerMask groundMask;
   
    [Header("Flavor")]
    [SerializeField] string creatureName = "player";
    [SerializeField] private GameObject body;


    [Header("Tracked Data")]
    [SerializeField] Vector3 homePosition = Vector3.zero;
    [SerializeField] CreatureSO creatureSO;


    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(health);

    }



    // Update is called once per frame
    void Update()
    {
        if(creatureSO != null){
            creatureSO.health = health;
            creatureSO.stamina = stamina;
        }
    }

    void FixedUpdate(){

    }
public void MoveCreature(Vector3 direction)
{

    //Debug.Log($"Moving creature in direction: {direction}, Speed: {speed}");

    // This sets the velocity based on the input direction multiplied by the speed.

    // It now affects both horizontal and vertical movement.
    rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
/*
    // Adjust the scale based on the direction to flip the sprite left or right.
    if (direction.x < 0)
    {
        body.transform.localScale = new Vector3(-1, 1, 1);
    }
    else if (direction.x > 0)
    {
        body.transform.localScale = new Vector3(1, 1, 1);
    }*/
}
  

}
