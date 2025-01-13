using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSegmentPlayer : MonoBehaviour
{
    public AudioClip audioClip; // The audio clip to play
    public float startSeconds; // When to start playing
    public float lengthSeconds; // How long to play

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) 
        { // Ensure there's an AudioSource component
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = audioClip;
    }

    private void OnDestroy()
    {
        StartCoroutine(PlayAudioSegment());
    }

    private IEnumerator PlayAudioSegment()
    {
        audioSource.time = startSeconds;
        audioSource.Play();
        yield return new WaitForSeconds(lengthSeconds);
        audioSource.Stop();
    }
}
