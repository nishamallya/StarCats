using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLevel2 : MonoBehaviour {

	private Transform grenade;
	public float speed;
	public bool GrenadeTimer;
	private Vector3 direction;

	// Use this for initialization
	void Start ()
	{

		grenade = GetComponent<Transform>();
		StartCoroutine(ActivateGrenade());
		GrenadeTimer = false;
		direction = new Vector3(transform.position.x, transform.position.y, 0f);

	}

	void FixedUpdate()
	{
		grenade.position += direction / 1.8f * speed;
		
		if (grenade.position.y >= 10)
		{
			Destroy(gameObject);
		}
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (GrenadeTimer == false && other.gameObject.CompareTag("Enemy"))
		{
			StartCoroutine(DestructGrenade());
			GrenadeTimer = true;
		}
       
	}

	IEnumerator ActivateGrenade()
	{
		GetComponent<Collider2D>().enabled = false;
		yield return new WaitForSeconds(0.8f);
		GetComponent<Collider2D>().enabled = true;
	}
    
	IEnumerator DestructGrenade()
	{
		yield return new WaitForSeconds(0.2f);
		Destroy(gameObject);
	}
}


