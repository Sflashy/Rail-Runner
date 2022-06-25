using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform Player;
    public bool IsGameOver;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (IsGameOver && Input.GetKeyDown(KeyCode.Space))
            LevelManager.Instance.Restart();
    }

    public void ReleaseObjects()
    {
        var bar = Player.Find("Bar");
        bar.gameObject.AddComponent<Rigidbody>();
        bar.parent = null;
    }
}
