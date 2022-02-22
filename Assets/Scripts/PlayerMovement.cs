using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{   
    public float Speed = 1f;
    public Text text;

    private int _directionIndex = 0;
    private Rigidbody _rigidbody;
    private int score = 0;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        print(_rigidbody);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _directionIndex = _directionIndex == 0 ? 1 : 0;
        }
    }

    private void FixedUpdate()
    {
        var velocity = _directionIndex == 0 ? Vector3.forward : Vector3.right;
        velocity *= Speed;
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;

    }

    private void OnDisable()
    {
        var velocity = Vector3.zero;
        velocity.y = _rigidbody.velocity.y;

        _rigidbody.velocity = velocity;

    }

    public void updateScore()
    {
        score++;
        text.text = "Score: " + score.ToString();
    }
}
