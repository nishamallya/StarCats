using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.CompareTag("Player")){

			Destroy(gameObject);
			Health.AddHealth(50);
			ReminderManager.HealthBoost();

		}

		
		
		if (other.gameObject.CompareTag("Wall"))
		{
			Destroy(gameObject);
		}
		
	}
}
