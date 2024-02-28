using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sounds
{
    public string name;
    public AudioClip clip;


    // Implements sliders to control volume/pitch
    [Range(0f, 1f)]
    public float volume;

    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;


    // Even if the variable is public, it will not show in inspector
    [HideInInspector]
    public AudioSource source;
}
