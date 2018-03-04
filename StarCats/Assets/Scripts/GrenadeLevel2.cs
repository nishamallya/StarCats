using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLevel2 : MonoBehaviour {

	private Transform grenade;
	public float speed;
	private Vector3 direction;
	public Camera cam;
	public GameObject explosionGO;
	public float shake;
	public float shakeamount = 0.3f;
	public float decreaserate = 3;

	// Use this for initialization
	void Start ()
	{

		cam = FindObjectOfType<Camera>();
		shake = 1.2f;
        
		Collider2D[] enemiesOnScreen = Physics2D.OverlapBoxAll(cam.ScreenToWorldPoint(new Vector2(Screen.width/2f, Screen.height/2f)), 
			new Vector2(30, 12), 0); //rough equivalent of screen size
        
		for (int i = 0; i < enemiesOnScreen.Length; i++)
		{
			if (enemiesOnScreen[i].gameObject.CompareTag("Enemy"))
			{
				Destroy(enemiesOnScreen[i].gameObject);
				playExplosion(enemiesOnScreen[i].gameObject);
				ScoreManager.AddScore(2);
                
			}
            
		}

	}

	void FixedUpdate()
	{
		if (shake > 0)
		{
			cam.transform.localPosition = Random.insideUnitCircle * shakeamount;
			shake -= Time.fixedDeltaTime * decreaserate;

		}

		if (shake <= 0)
		{
			Destroy(gameObject);
		}
        
	}

	void playExplosion(GameObject g)
	{
		GameObject explosion = (GameObject) Instantiate(explosionGO);
		explosion.transform.position = g.transform.position;
	}
}


