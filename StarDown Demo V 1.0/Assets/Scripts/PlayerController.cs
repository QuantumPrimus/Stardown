using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour {

	public float speed = 2f;
	public float brakeSpeed = 1f;
	public float thrustSpeed = 4f;
	public float rotateSpeed = 70f;
	public float dampen = .98f;
	public float maxVelocity = 2f;

	private Vector3 velocity = Vector3.zero;
	
	void Start () {
		
	}

	void Update()
	{
	
		getInput();
		velocity += transform.up * speed * Time.deltaTime;
		velocity = Vector3.ClampMagnitude(velocity, maxVelocity) * dampen;
		transform.position += velocity;
		
	}


	void getInput()
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			velocity += transform.up * thrustSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime));
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(new Vector3(0f, 0f, -rotateSpeed * Time.deltaTime));
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			velocity += transform.up * brakeSpeed * Time.deltaTime;
		}

		

	}

	
}
