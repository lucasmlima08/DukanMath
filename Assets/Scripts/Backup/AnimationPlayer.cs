using UnityEngine;
using System.Collections;

public class AnimationPlayer : MonoBehaviour {

    public Animation animation;

    public float speedRotation = 50.0f;
	public float speedMovement = 50.0f;

	// Use this for initialization
	void Start () {
        animation = GetComponent<Animation>();
    }

	void Update () {

		float moveHorizontal = Input.GetAxis ("Horizontal") * speedRotation * Time.deltaTime;
		float moveVertical = Input.GetAxis ("Vertical") * speedMovement * Time.deltaTime;

		if (conditionPressedRotation ())
		{
			transform.Rotate(0.0f, moveHorizontal, 0.0f);
		}

		if (conditionPressedMovement())
		{
			animation.CrossFade("Caminhada");
			transform.Translate(0.0f, 0.0f, moveVertical);
		}
		else if (conditionTwoPressedAnimation() || conditionPressedAtack())
		{
			animation.CrossFade("Ataque");
		}
	}

	private bool conditionPressedMovement()
	{
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S))
			return true;
		if (Input.GetAxis ("Vertical") != 0.0f)
			return true;
		return false;
	}

	private bool conditionPressedRotation()
	{
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D))
			return true;
		if (Input.GetAxis ("Horizontal") != 0.0f)
			return true;
		return false;
	}

	private bool conditionPressedAtack()
	{
		if (Input.GetKey (KeyCode.Space))
			return true;
		if (Input.GetMouseButtonDown (0))
			return true;
		return false;
	}

	private bool conditionTwoPressedAnimation()
	{
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.Space))
			return true;
		if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.Space))
			return true;
		if (Input.GetKey (KeyCode.W) && Input.GetMouseButtonDown(0))
			return true;
		if (Input.GetKey (KeyCode.S) && Input.GetMouseButtonDown(0))
			return true;
		return false;
	}
}
