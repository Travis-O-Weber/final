using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
public static AudioManager singleton;/// <summary>
/// { get; private set; }
/// </summary>

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject); // This will keep the AudioManager alive across different scenes.
        }
        else if (singleton != this)
        {
            Destroy(gameObject); // Ensures there's only one instance of the AudioManager.
        }
    }

    public void PlayAudioSegment(AudioClip clip, float startSeconds, float lengthSeconds)
    {
        StartCoroutine(PlaySegmentCoroutine(clip, startSeconds, lengthSeconds));
    }

    private IEnumerator PlaySegmentCoroutine(AudioClip clip, float startSeconds, float lengthSeconds)
    {
        GameObject tempAudioObject = new GameObject("TempAudio");
        AudioSource tempAudioSource = tempAudioObject.AddComponent<AudioSource>();

        // Check if the current scene is "Cave"
        if (SceneManager.GetActiveScene().name == "cave")
        {
            // Add echo effect only if in the Cave scene
            AudioEchoFilter echoFilter = tempAudioObject.AddComponent<AudioEchoFilter>();
            echoFilter.delay = 500; // Adjust delay to suit the effect you want
            echoFilter.decayRatio = 0.5f; // Adjust decay ratio to suit the effect you want
        }

        tempAudioSource.clip = clip;
        tempAudioSource.time = startSeconds;
        tempAudioSource.Play();
        Debug.Log("eSystemCustomDataMode");
        yield return new WaitForSeconds(lengthSeconds);

        tempAudioSource.Stop();
        Destroy(tempAudioObject);
    }
}