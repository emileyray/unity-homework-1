using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public float movingSpeed =  120f;
    public float movingRange = 0.01f;

    private float initY = 0;
    private float timer = 0;

    private void Awake()
    {
        initY = transform.position.y;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(
            0, 
            transform.rotation.eulerAngles.y +
            rotationSpeed  * Time.deltaTime, 
            0
        );

        Vector3 _position = transform.position;
        _position.y = initY + movingRange * Mathf.Sin(timer * movingSpeed);
        timer += Time.deltaTime;
        transform.position = _position;
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement == null) return;

        playerMovement.updateScore();
        Destroy(gameObject);
    }
}
