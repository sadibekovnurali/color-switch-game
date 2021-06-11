using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    bool move = false;
    bool isGrounded = false; 

    public Rigidbody2D rigidBody;

    public float speed = 30f;
    public float rotationSpeed = 2f; 

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            move = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            move = false;
        }
    }

    private void FixedUpdate()
    {
        if (move == true)
        {
            if (isGrounded)
            {
                rigidBody.AddForce(transform.right * speed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            } else
            {
                rigidBody.AddTorque(rotationSpeed * speed * Time.fixedDeltaTime * 30f, ForceMode2D.Force);
            }
        } 
    }

    private void OnCollisionEnter2D()
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D()
    {
        isGrounded = false;
    }
}
