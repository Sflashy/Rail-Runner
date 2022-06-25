using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public State state;

    public string CurrentLevel = "Level01";

    public static LevelManager Instance;
    

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        switch (state)
        {
            case State.Failed:
                UIManager.Instance.ShowFailedUI();
                break;
            case State.Success:
                UIManager.Instance.ShowSuccessUI();
                break;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(CurrentLevel);
    }

    public void Load(string level)
    {
        CurrentLevel = level;
        SceneManager.LoadScene(level);
    }

    public void ChangeState(State state)
    {
        this.state = state;
    }
    public enum State
    {
        Playing,
        Failed,
        Success
    }
}