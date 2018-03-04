using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLevel2 : MonoBehaviour {

	private Transform bullet;
	public float speed;

	private Vector3 direction;
	

	// Use this for initialization
	void Start ()
	{

		bullet = GetComponent<Transform>();
		direction = new Vector3(transform.position.x, transform.position.y, 0f);

	}

	void FixedUpdate()
	{
		
		bullet.position += direction / 1.8f * speed;

		if (bullet.position.y >= 6 || bullet.position.y <= -6 || bullet.position.x >= 10 || bullet.position.x <= -10) //destory bullet when it exceeds screen boundaries
		{
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			Destroy(other.gameObject);
			Destroy(gameObject);

			//need to increase score and decrease ammo
		}

	}
}
