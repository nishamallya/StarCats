﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetB : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	/*private void Update()
	{
		if (gameObject.transform.position.y < -8)
		{
			Destroy(gameObject);
		}
	}
	*/
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "Player")
		{
			ContactPoint2D contact = other.contacts[0];
			if (Vector2.Dot(contact.normal, Vector2.up) > 0.5)
			{
				Destroy(gameObject);
				ScoreManager.AddScore(1);
			}
		}
		if (other.gameObject.GetComponent<BoxCollider2D>() != null)
		{
			Destroy(gameObject);
		}
	}
}