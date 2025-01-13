using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    private Vector3 randomDirection;

    void Start()
    {
        // Generate a random direction by creating a random angle
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        randomDirection = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f);
    }

    void Update()
    {
        // Move the sprite in the random direction
        transform.position += randomDirection * moveSpeed * Time.deltaTime;
    }
}