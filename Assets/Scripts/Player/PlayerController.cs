using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Attach to Player
//Player Controller functionality
public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public float boost = 0;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public GameObject whoosh; //SFX

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnBoost()
    {
        Vector3 boostVector = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(boostVector * boost);
        Instantiate(whoosh, transform.position, Quaternion.identity);
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }
}
