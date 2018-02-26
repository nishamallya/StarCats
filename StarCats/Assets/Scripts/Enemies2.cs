using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies2 : MonoBehaviour {

	private float speed = 0.05f;

	private Vector3 direction;
	private float distance;

	// Use this for initialization
	void Start () {
		direction = new Vector3(transform.position.x, transform.position.y, 0f);
		distance = Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.y, 2));
	}
	
	void Update () {
		transform.position -= direction / distance * speed;

		if (Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.y, 2)) < 1.5f)
		{
			Destroy(gameObject);
			if (Health.healthcount > 0)
			{
				Health.AddHealth(-10);
			}
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.name == "Player")
		{
			Destroy(gameObject);
			if (Health.healthcount > 0)
			{
				Health.AddHealth(-10);
			}
			

		}

		if (other.gameObject.CompareTag("Trap"))
		{
			if (other.gameObject.GetComponent<RadialTrap>().isSet)
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
