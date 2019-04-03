﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float Thrustspeed = 5f; // int or bool?
    [SerializeField] float Rotationspeed = 5f;
    // Do I need a seperate rotate speed?

    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementControls();
    }

    private void MovementControls()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * Thrustspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-transform.right * Thrustspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.up * Thrustspeed * Time.deltaTime);
            //rb2D.velocity = -transform.up * Thrustspeed; // This one causes it to fall.
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.up * Thrustspeed * Time.deltaTime);
            //rb2D.velocity = transform.up * Thrustspeed;
            //transform.Translate(Vector2.up * Thrustspeed * Time.deltaTime);
        }
        //else if (Input.GetKey(KeyCode.Q))
        //{
        //    transform.Rotate(transform.forward * Rotationspeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.E))
        //{
        //    transform.Rotate(-transform.forward * Rotationspeed * Time.deltaTime);
        //}
    }
}
