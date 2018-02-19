using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

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

//	private void OnCollisionEnter2D(Collision2D other)
//	{
//		if (other.gameObject.name == "Player")
//		{
//			ContactPoint2D contact = other.contacts[0];
//			if (Vector2.Dot(contact.normal, Vector2.up) > 0.5)
//			{
//				Destroy(gameObject);
//				if (ScoreManager.storageA > 0)
//				{
//					ScoreManager.AddScore((-1));
//				}
//				/*if (ScoreManager2.storageB > 0)
//				{
//					ScoreManager2.AddScore(-1);
//				}
//				if (ScoreManager3.storageC > 0)
//				{
//					ScoreManager3.AddScore(-1);
//				}
//				*/
//
//			}
//		}
//		if (other.gameObject.GetComponent<BoxCollider2D>()!= null)
//			{
//				Destroy(gameObject);
//				if (Health.healthcount > 0)
//				{
//					Health.AddHealth(-10);
//				}
//				if (ScoreManager.storageA > 0)
//				{
//					ScoreManager.AddScore(-1);
//				}
//			}
//
//		}

	private void OnTriggerEnter2D(Collider2D other)
	{


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

