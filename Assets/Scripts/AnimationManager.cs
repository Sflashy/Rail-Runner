using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private int _isHanging = Animator.StringToHash("IsHanging");
    private int _isClimbing = Animator.StringToHash("IsClimbing");
    private int _isFailed = Animator.StringToHash("IsFailed");
    private int _isSuccess = Animator.StringToHash("IsSuccess");
    public enum State
    {
        Pushing,
        Climbing,
        Hanging,
        Failed,
        Dance
    }

    public Animator animator;
    public static AnimationManager Instance;
    private State _state;

    public AnimationManager()
    {
        Instance = this;
    }
    public void ChangeState(State state)
    {
        _state = state;
    }
    private void Update()
    {
        switch (_state)
        {
            case State.Pushing:
                animator.SetBool(_isHanging, false);
                animator.SetBool(_isClimbing, false);
                break;
            case State.Climbing:
                animator.SetBool(_isClimbing, true);
                break;
            case State.Hanging:
                animator.SetBool(_isClimbing, false);
                animator.SetBool(_isHanging, true);
                break;
            case State.Failed:
                animator.SetBool(_isHanging, false);
                animator.SetBool(_isClimbing, false);
                animator.SetBool(_isFailed, true);
                break;
            case State.Dance:
                animator.SetBool(_isHanging, false);
                animator.SetBool(_isClimbing, false);
                animator.SetBool(_isSuccess, true);
                break;
        }
    }
}