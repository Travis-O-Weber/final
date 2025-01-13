using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscreteMovement : MonoBehaviour
{
    [SerializeField] private float moveDistance = 1.0f; // Set the distance to move per button press
    private Vector3 targetPosition;
    private bool isMoving = false;

    private void Update()
    {
        if (isMoving)
        {
            float step = moveDistance * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }

    public void Move(Vector2 direction)
    {
        if (!isMoving)
        {
            Vector3 newPosition = transform.position + new Vector3(direction.x, direction.y, 0f) * moveDistance;

            // You can add additional logic to restrict movement here if needed.

            targetPosition = newPosition;
            isMoving = true;
        }
    }
}