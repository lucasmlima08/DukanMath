using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MovementSphereRotacao : MonoBehaviour
{

    public float speedRotation = 50.0f;
    public float speedMovement = 50.0f;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speedRotation * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * speedMovement * Time.deltaTime;
        
        transform.Translate(0.0f, 0.0f, moveVertical);
        transform.Rotate(0.0f, moveHorizontal, 0.0f);

        Vector3 vectorPosition = new Vector3(0.0f, 0.0f, transform.position.z);
        //Quaternion vectorRotation = Quaternion.Euler(0.0f, transform.rotation.y, 0.0f);

        transform.position = vectorPosition;
        //transform.rotation = vectorRotation;
    }
}
