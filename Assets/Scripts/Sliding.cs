using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : MonoBehaviour
{
    public AudioSource slidingSound;
    private void OnCollisionEnter(Collision collision)
    {
        slidingSound.Play();
    }

    private void OnCollisionExit(Collision other)
    {
        slidingSound.Stop();
    }
    
}
