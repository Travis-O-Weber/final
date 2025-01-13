using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // Make sure this is the only declaration of 'target'
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothSpeed = 0.125f; // Adjusted for a smoother follow

    // You can remove Awake and Start if they are empty and not used

   void LateUpdate()
{
    if (target != null)
    {
        Vector3 desiredPosition = target.position + offset;
        // Explicitly set the Z value to maintain the camera's distance to the 2D plane
        desiredPosition.z = -10; // Assuming -10 is the correct distance for your camera

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}

    public void AssignTarget(Transform newTarget)
    {
        target = newTarget; // Make sure this method is correctly assigning a new target
    }
}
