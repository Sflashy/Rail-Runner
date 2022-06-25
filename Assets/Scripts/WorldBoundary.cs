using UnityEngine;

public class WorldBoundary : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        LevelManager.Instance.Restart();
    }
}
