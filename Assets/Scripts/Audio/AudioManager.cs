using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public Sounds[] soundclips;

    // public static AudioManager instance;

    void Awake()
    {
        // // This conditional ensures only 1 instance of AudioManager is playing per scene
        // if(instance == null)
        // {
        //     instance = this;
        // }
        // else
        // {
        //     Destroy(gameObject);
        //     return;
        // }

        // DontDestroyOnLoad(gameObject);
        
        foreach (Sounds s in soundclips)
        {
            // Our current source is the new audio clip
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        
    }

    void Start()
    {
        Play("Theme");
    }

    public void Play (string name)
    {
        // Checks the Sounds array for an audio clip with a name that matches
        Sounds s = Array.Find(soundclips, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found: " + name);
            return;
        }
        s.source.Play();
    }

    public void StopPlaying (string name)
    {
        // Checks the Sounds array for an audio clip with a name that matches
        Sounds s = Array.Find(soundclips, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found: " + name);
            return;
        }

        s.source.Stop();
    }

    public void HoverSound()
    {
        Play("HoverSound");
    }

    public void ClickSound()
    {
        Play("ClickSound");
    }
}
