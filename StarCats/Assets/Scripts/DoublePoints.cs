using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePoints : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.name == "Player")
		{
			Destroy(gameObject);
			ScoreManager.multiplier = 2;
			ReminderManager.ScoreBoost();

		}

		
		
		if (other.gameObject.CompareTag("Wall"))
		{
			Destroy(gameObject);
		}
		
	}
}
