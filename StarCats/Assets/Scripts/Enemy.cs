using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	private void Update()
	{
		if (gameObject.transform.position.y < -8)
		{
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "Player")
		{
			ContactPoint2D contact = other.contacts[0];
			if (Vector2.Dot(contact.normal, Vector2.up) > 0.5)
			{
				Destroy(gameObject);
				if (ScoreManager.storageA > 0)
				{
					ScoreManager.AddScore((-1));
				}
				if (ScoreManager2.storageB > 0)
				{
					ScoreManager2.AddScore(-1);
				}
				if (ScoreManager3.storageC > 0)
				{
					ScoreManager3.AddScore(-1);
				}
				
			}

		}
	}
}
