using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderDemo : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
