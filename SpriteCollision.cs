using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpriteCollision : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip; // The sound to play
    [SerializeField] private float startSeconds; // Start time of the audio clip segment
    [SerializeField] private float lengthSeconds; // Length of the audio clip segment
  private void OnTriggerEnter2D(Collider2D collision)
{
    // Check if the collider is a projectile
    if (collision.gameObject.tag == "projectile3")
    {
        if (AudioManager.singleton != null)
        {
            AudioManager.singleton.PlayAudioSegment(audioClip, startSeconds, lengthSeconds);
        }
        else
        {
            //Debug.LogError("AudioManager.singleton is null.");
        }
       // Debug.LogError(collision.gameObject.name);
        Destroy(gameObject);
    }
}
}
