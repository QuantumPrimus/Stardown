using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class StarsFloating : MonoBehaviour {
	private Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(1.5f, 0f);
	}

	private void Update()
	{
		
	}
}
