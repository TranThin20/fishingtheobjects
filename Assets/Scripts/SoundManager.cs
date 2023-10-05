using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    //public Sound[] sounds;
    public AudioSource audioSource;

    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
        instance = this;
    }

    //public AudioClip clip;
    void Start()
    {
    }

    public void PlaySoundOnce(AudioClip clip, float volume)
    {
        if (audioSource != null)
        {
            if (clip != null)
            {
                audioSource.volume = volume;
                audioSource.PlayOneShot(clip);
                Debug.Log("Playing sound: " + clip.name);
            }
        }
    }
    public void PlaySoundLoop(AudioClip clip, float volume)
    {
        if (audioSource != null)
        {
            
            if (clip != null)
            {
                audioSource.loop = true; 
                audioSource.clip = clip;
                audioSource.volume = volume;
                audioSource.Play();
            }
        }
    }
    public void StopSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            audioSource.clip = null;
            Debug.Log("stop");
        }
    }
}
