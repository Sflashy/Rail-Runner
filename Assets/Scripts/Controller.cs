using System;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Transform _playerBody;
    private Transform _barTip;
    private Vector3 _position;
    public bool isGrounded = true;
    private Bar _barController;
    private Transform _bar;
    private CharacterController _controller;
    private Vector3 _movement;

    private void Awake()
    {
        _bar = transform.Find("Bar");
        _barTip = _bar.Find("Tip");
        _barController = _bar.GetComponent<Bar>();
        _playerBody = transform.Find("PlayerBody");

    }

    private void Update()
    {
        if (GameManager.Instance.IsGameOver) return;
        CheckGrounded();
        UpdateRotation();
    }

    private void UpdateRotation()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _barController.RotateVertical();
            Climb();
        }
        else
        {
            _barController.RotateHorizontal();
            Push();
        }
    }

    private void Push()
    {
        AnimationManager.Instance.ChangeState(isGrounded ? AnimationManager.State.Pushing : AnimationManager.State.Hanging);
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }

    private void Climb()
    {
        if (Math.Abs(_playerBody.position.y - _barTip.position.y) > 0.5f)
        {
            AnimationManager.Instance.ChangeState(AnimationManager.State.Climbing);
        }
        else
        {
            AnimationManager.Instance.ChangeState(AnimationManager.State.Hanging);
        }

        _playerBody.position = Vector3.Lerp(_playerBody.position, _barTip.position, 0.05f);
    }

    private void CheckGrounded()
    {
        isGrounded = Physics.Raycast(_playerBody.position, Vector3.down, 1f);
    }
}