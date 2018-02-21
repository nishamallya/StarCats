using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownEnemy : MonoBehaviour {

	void Start () {
		
	}
	
	private void Update()
	{
		
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		/*if (other.gameObject.name == "Player")
		{
		
			Destroy(gameObject);
			if (ScoreManager.storageA > 0)
			{
				ScoreManager.AddScore((-1));
			}
			
			PlayerController.SlowDown();
			ReminderManager.SlowDown();
		}
		
		if (other.gameObject.GetComponent<BoxCollider2D>()!= null)
		{
			Destroy(gameObject);
			if (Health.healthcount > 0)
			{
				Health.AddHealth(-10);
			}
			if (ScoreManager.storageA > 0)
			{
				ScoreManager.AddScore(-1);				}
				
		}
		*/
		
		if (other.gameObject.CompareTag("Wall") || other.gameObject.name == "Player")
		{
			Destroy(gameObject);
			if (Health.healthcount > 0)
			{
				Health.AddHealth(-10);
			}
			if (ScoreManager.storageA > 0)
			{
				ScoreManager.AddScore(-1);
			}
			PlayerController.SlowDown();
			ReminderManager.SlowDown();

		}

		if (other.gameObject.CompareTag("Trap"))
		{
			if (other.gameObject.GetComponent<Trap>().isSet)
			{
				Destroy(gameObject);
			}
			
		}
		
		if (other.gameObject.CompareTag("Bullet"))
		{
			Destroy(gameObject);
			Destroy(other.gameObject);
			
		}
	}
}
