using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        if (GameManager.Instance.IsGameOver) return;
        MoveForward();
    }
    
    private void MoveForward()
    {
        var platform = transform;
        platform.position += new Vector3(0,0,-1) * speed * Time.deltaTime;
    }
}
