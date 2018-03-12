using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownEnemy : MonoBehaviour
{

	public GameObject explosionGO;
	public GameObject boltStrikeGO;

	void Start () {
		
	}
	
	private void Update()
	{
		
	}
	
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
			
			PlayerController.SlowDown();
			ReminderManager.SlowDown();
			PlayerController.slow.SetActive(true);
			

		}

		if (other.gameObject.CompareTag("Trap"))
		{
			if (other.gameObject.GetComponent<Trap>().isSet)
			{
				playerExplosion();
				Destroy(gameObject);
				ScoreManager.AddScore(2);
			}
			
		}
		
		if (other.gameObject.CompareTag("Bullet"))
		{
			playerExplosion();
			Destroy(gameObject);
			Destroy(other.gameObject);
			ScoreManager.AddScore(2);
			
		}
		
		if (other.gameObject.CompareTag("Grenade"))
		{
			playerExplosion();
			Destroy(gameObject);
			ScoreManager.AddScore(2);
		}
	}

	void playerExplosion()
	{
		GameObject explosion = (GameObject) Instantiate((explosionGO));
		explosion.transform.position = transform.position;
	}
	
	void playBoltStrike()
	{
		GameObject strike = (GameObject) Instantiate(boltStrikeGO);
		strike.transform.position = transform.position;
	}
}
