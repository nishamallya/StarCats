using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetA : MonoBehaviour {
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.name == "Player")
		{

			Destroy(gameObject);
			ScoreManager.AddScore(10);
		}	
		
		if (other.gameObject.CompareTag("Wall"))
		{
			Destroy(gameObject);
		}
		
	}
}
