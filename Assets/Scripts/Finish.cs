using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name != "Player") return;
        Debug.Log("Level completed x" + transform.name);
        GameManager.Instance.IsGameOver = true;
        AnimationManager.Instance.ChangeState(AnimationManager.State.Dance);
        LevelManager.Instance.ChangeState(LevelManager.State.Success);
        GameManager.Instance.ReleaseObjects();
    }
}
