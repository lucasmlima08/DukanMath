using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MovementSphere : MonoBehaviour
{
    public float speedSphere;
    
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontalSphere = Input.GetAxis("Horizontal") * speedSphere * Time.deltaTime;
        float moveVerticalSphere = Input.GetAxis("Vertical") * speedSphere * Time.deltaTime;

        // Movimento da esfera.
        Vector3 movement = new Vector3(moveHorizontalSphere, 0.0f, moveVerticalSphere);
        rigidBody.AddForce(movement * speedSphere);
    }
}
