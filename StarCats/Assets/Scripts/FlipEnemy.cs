using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEnemy : MonoBehaviour
{
	public GameObject explosionGo;
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
			
			PlayerController.FlipInput();
			ReminderManager.ReverseControl();
			PlayerController.reverse.SetActive(true);
			

		}

		if (other.gameObject.CompareTag("Trap"))
		{
			if (other.gameObject.GetComponent<Trap>().isSet)
			{
				playExplosion();
				Destroy(gameObject);
				ScoreManager.AddScore(2);
			}
			
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
		GameObject explosion = (GameObject) Instantiate(explosionGo);
		explosion.transform.position = transform.position;
	}
	
	void playBoltStrike()
	{
		GameObject strike = (GameObject) Instantiate(boltStrikeGO);
		strike.transform.position = transform.position;
	}
}
