using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        print(_rigidbody);
    }
    
    public void Move(int directionIndex, float speed)
    {
        var velocity = directionIndex == 0 ? Vector3.forward : Vector3.right;
        velocity *= speed;
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;
    }
    

    private void OnDisable()
    {
        var velocity = Vector3.zero;
        velocity.y = _rigidbody.velocity.y;

        _rigidbody.velocity = velocity;

    }
}
