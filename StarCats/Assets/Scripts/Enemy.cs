using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	public GameObject explosionGO;
	public GameObject boltStrikeGO;


	private void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.CompareTag("Wall") || other.gameObject.name == "Player")
		{
			playBoltStrike();
			Destroy(gameObject);
			if (Health.healthcount > 0)
			{
				Health.AddHealth(-10);
			}
		}

		if (other.gameObject.CompareTag("Trap"))
		{

			    playExplosion();
				Destroy(gameObject);
				ScoreManager.AddScore(2);	
		}
		
		if (other.gameObject.CompareTag("Bullet"))
		{
			playExplosion();
			Destroy(gameObject);
			Destroy(other.gameObject);
			ScoreManager.AddScore(2);
			
		}

		if (other.gameObject.CompareTag("Grenade"))
		{
			playExplosion();
			Destroy(gameObject);
			ScoreManager.AddScore(2);
		}
	}

	void playExplosion()
	{
		GameObject explosion = (GameObject) Instantiate(explosionGO);
		explosion.transform.position = transform.position;
	}

	void playBoltStrike()
	{
		GameObject strike = (GameObject) Instantiate(boltStrikeGO);
		strike.transform.position = transform.position;
	}
	
	}

