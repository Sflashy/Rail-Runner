using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[SuppressMessage("ReSharper", "Unity.InefficientPropertyAccess")]
public class Bar : MonoBehaviour
{
    public bool isVertical;
    [SerializeField] private bool isHorizontal;
    private const float HeightOffset = 0.3f;
    private const float ForwardOffset = 0.68f;
    private Transform _player;
    private Transform _playerBody;
    private Transform _barBottomPos;

    private void Awake()
    {
        _player = transform.parent;
        _playerBody = transform.parent.Find("PlayerBody");
        _barBottomPos = transform.Find("Bottom");
    }
    public void RotateVertical()
    {
        if (isVertical) return;
        var barHeight = transform.localScale.y - HeightOffset;
        transform.position = new Vector3(_player.position.x, _player.position.y + barHeight, _player.position.z + ForwardOffset);
        transform.rotation = Quaternion.identity;
        
        isVertical = true;
        isHorizontal = false;

    }

    public void RotateHorizontal()
    {
        if (isHorizontal) return;
        _player.position = new Vector3(0, _barBottomPos.position.y, _player.position.z);
        transform.rotation = Quaternion.Euler(0,0,90);
        transform.position = new Vector3(transform.position.x, _player.position.y + HeightOffset, _player.position.z + ForwardOffset);
        _playerBody.position = _player.position;
        isVertical = false;
        isHorizontal = true;
    }
}
