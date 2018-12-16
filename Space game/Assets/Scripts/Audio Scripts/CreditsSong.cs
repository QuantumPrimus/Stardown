using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreditsSong : MonoBehaviour {

	public string[] songNames;
	public CreditsSong artist;

	private Text txt;

	private Rigidbody2D rb;
	private RectTransform rt;
	[SerializeField]
	private Vector2 speed;

	private bool floatRight = true;
	private bool floatLeft = false;

	private float time = 0;
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rt = GetComponent<RectTransform>();
		rt.position = new Vector2(-23f, rt.position.y);
		txt = GetComponent<Text>();
		songName(0);
	}


	void Update () {
		// Debug.Log(transform.position.x);
		// Debug.Log(rt.position.x);
		// Debug.Log(rb.velocity);
		if (floatRight)
			moveRight();
		else if (floatLeft)
			moveLeft();

	}


	private void moveRight()
	{
		
		if (rt.position.x <= -3)
		{
			time = 0;
			rb.AddForce(speed);
		}
		else
		{
			rb.velocity = Vector2.zero;
			//Timer
			time += Time.deltaTime;
			if(time >= 5)
			{
				floatRight = false;
				floatLeft = true;
				// moveLeft();
			}
		} 

	}

	private void moveLeft()
	{
		if (rt.position.x >= -23f)
			rb.AddForce(-(speed));
		else
			rb.velocity = Vector2.zero;
	}



	public void songName(int index)
	{
		txt.text = songNames[index];
		if(artist != null)
			artist.songName(index);

	}


}
