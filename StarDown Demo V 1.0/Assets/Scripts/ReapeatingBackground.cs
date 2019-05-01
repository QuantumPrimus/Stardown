using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapeatingBackground : MonoBehaviour {

	private BoxCollider2D col;
	private float horizontalLength;
    // public float TempfixTest;
	void Start() {
		col = GetComponent<BoxCollider2D>();
		horizontalLength = col.size.x;
	}

	void Update () {
		if (transform.position.x > horizontalLength + 4f)
		{
			repositionBackground();
		}
	}


	private void repositionBackground()
	{
		Vector2 groundOffset = new Vector2(horizontalLength * 2.4f, 0);
		transform.position = (Vector2)transform.position - groundOffset;
	}
}
