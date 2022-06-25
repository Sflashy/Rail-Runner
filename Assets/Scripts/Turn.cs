using System;
using Unity.Mathematics;
using UnityEngine;

public class Turn : MonoBehaviour
{
    private void OnCollisionStay(Collision collisionInfo)
    {
        if(!collisionInfo.transform.CompareTag("Player")) return;
        var platforms = transform.parent.parent;
        if (platforms.localEulerAngles.y < 90f)
        {
            platforms.rotation = Quaternion.Lerp(platforms.rotation, Quaternion.Euler(0,90,0),0.2f);
        }
    }
}
