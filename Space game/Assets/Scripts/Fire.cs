using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	
	public GameObject bulletPrefab;
	//public Transform offset;
	public float fireRate = 0.5f;
	private float cooldown = 0;
	void Update () {
		cooldown -= Time.deltaTime;
		if(Input.GetButton("Fire1") && cooldown <= 0)
		{
			cooldown = fireRate;
			Instantiate(bulletPrefab, transform.position, transform.rotation);
		}
	}
}
