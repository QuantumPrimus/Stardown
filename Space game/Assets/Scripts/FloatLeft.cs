using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FloatLeft : MonoBehaviour {
	public Vector2 speed;
	public float rotateSpeed;
	private Rigidbody2D rb;
	// private PolygonCollider2D pc;
	
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		// pc = GetComponent<PolygonCollider2D>();
	}
	
	void FixedUpdate () {
		transform.Rotate(Vector3.forward * rotateSpeed);
		rb.velocity= speed*Time.fixedDeltaTime;		
	}
}
