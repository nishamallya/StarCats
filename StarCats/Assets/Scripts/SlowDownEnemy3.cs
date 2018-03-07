using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownEnemy3 : MonoBehaviour {
	
	public GameObject explosionGO;
	public GameObject boltStrikeGO;

	private float speed = 0.045f;

	private Vector3 direction;
	private float distance;

	// Use this for initialization
	void Start () {
		direction = new Vector3(transform.position.x, transform.position.y + 11f, 0f);
		distance = Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.y + 11f, 2));
	}
	
	void Update () {
		transform.position -= direction / distance * speed;

		if (Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.y + 11f, 2)) < 8.25f)
		{
			playBoltStrike();
			Destroy(gameObject);
			if (Health.healthcount > 0)
			{
				Health.AddHealth(-10);
				PlayerSector.SlowDown();
				ReminderManager.SlowDown();
			}
			
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.name == "Player")
		{
			playBoltStrike();
			Destroy(gameObject);
			if (Health.healthcount > 0)
			{
				Health.AddHealth(-10);
				PlayerSector.SlowDown();
				ReminderManager.SlowDown();
				PlayerSector.slow.SetActive(true);
			}
			

		}

		if (other.gameObject.CompareTag("Trap"))
		{
			//if (other.gameObject.GetComponent<RadialTrap>().isSet)
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
		GameObject explosion = (GameObject) Instantiate(explosionGO);
		explosion.transform.position = transform.position;
	}
	
	void playBoltStrike()
	{
		GameObject strike = (GameObject) Instantiate(boltStrikeGO);
		strike.transform.position = transform.position;
	}
}
