using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource collectSound;
    public static SoundManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public static void Play(AudioSource audio)
    {
        audio.Play();
    }
}