using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEnemy : MonoBehaviour
{
	public GameObject explosionGo;

	// Use this for initialization
	void Start () {
		
	}
	
	private void Update()
	{
		
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		/*if (other.gameObject.name == "Player" || other.gameObject.CompareTag("Wall"))
		{
		
			Destroy(gameObject);
			if (ScoreManager.storageA > 0)
			{
				ScoreManager.AddScore((-1));
			}
			if (Health.healthcount > 0)
			{
				Health.AddHealth(-10);
			}
			PlayerController.FlipInput();
			ReminderManager.ReverseControl();

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
			
			PlayerController.FlipInput();
			ReminderManager.ReverseControl();

		}

		if (other.gameObject.CompareTag("Trap"))
		{
			if (other.gameObject.GetComponent<Trap>().isSet)
			{
				playExplosion();
				Destroy(gameObject);
			}
			
		}
		
		if (other.gameObject.CompareTag("Bullet"))
		{
			playExplosion();
			Destroy(gameObject);
			Destroy(other.gameObject);
			
		}
	}

	void playExplosion()
	{
		GameObject explosion = (GameObject) Instantiate(explosionGo);
		explosion.transform.position = transform.position;
	}
}
