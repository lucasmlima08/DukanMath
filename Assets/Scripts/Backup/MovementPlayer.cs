using UnityEngine;
using System.Collections;

public class MovementPlayer : MonoBehaviour
{

    public float speedRotation = 80.0f;
    public float speedMovement = 20.0f;

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
        
        //Vector3 vectorPosition = new Vector3(0.0f, 0.0f, transform.position.z);
        //transform.position = vectorPosition;

        //Vector3 vectorRotation = new Vector3(0.0f, transform.rotation.y, 0.0f);
        //transform.rotation = Quaternion.LookRotation(vectorRotation);

    }
}