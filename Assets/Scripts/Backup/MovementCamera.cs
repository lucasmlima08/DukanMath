using UnityEngine;
using System.Collections;

public class MovementCamera : MonoBehaviour
{
    public float speedMovement = 20.0f;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speedMovement * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * speedMovement * Time.deltaTime;

        transform.Translate(moveHorizontal, 0.0f, moveVertical);
    }
}
