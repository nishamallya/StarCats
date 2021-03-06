﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    private Transform bullet;
    public float speed;
	public GameObject player;

	// Use this for initialization
	void Start ()
	{

		bullet = GetComponent<Transform>();


	}

	void FixedUpdate()
	{
		bullet.position += Vector3.up * speed;

		if (bullet.position.y >= 6)
		{
			Destroy(gameObject);
		}
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Enemy"))
		{
			Destroy(other.gameObject);
			Destroy(gameObject);
			
			//need to increase score and decrease ammo
		}
	}

	
}
