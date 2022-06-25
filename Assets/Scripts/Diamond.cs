using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Bar")) return;
        PickUp();
    }

    private void PickUp()
    {
        UIManager.Instance.AddDiamond(1);
        SoundManager.Play(SoundManager.Instance.collectSound);
        Destroy(gameObject);
    }
}
