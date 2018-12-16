using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

	public float speed = 40f;
	private Vector3 velocity = Vector3.zero;
	public float dampen = .79f;
	private float maxVelocity;
	// Use this for initialization
	void Start () {
		maxVelocity = 3;
	}
	
	// Update is called once per frame
	void Update () {
		velocity = transform.up * Time.deltaTime * speed;
		velocity = Vector3.ClampMagnitude(velocity, maxVelocity) * dampen;
		transform.position += velocity;
	}
}
