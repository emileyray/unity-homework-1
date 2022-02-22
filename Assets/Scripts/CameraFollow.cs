using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public PlayerMovement Follow;

    private Vector3 _offsetFromFollowToCamera;
    private float _initY;

    private void Awake()
    {
        _offsetFromFollowToCamera = transform.position - Follow.transform.position;
        _initY = transform.position.y;
    }

    private void LateUpdate()
    {
        var position = Follow.transform.position + _offsetFromFollowToCamera;
        position.y = _initY;
        transform.position = position;
    }

}
