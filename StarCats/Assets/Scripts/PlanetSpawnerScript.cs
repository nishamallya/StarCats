using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawnerScript : MonoBehaviour
{


	public GameObject planetA;
	public GameObject planetB;
	public GameObject planetC;
    float randX;
	Vector2 whereToSpawn;
	public float spawnRate = 2f;
	float nextSpawn = 0.0f;
	
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawn)
		{
			nextSpawn = Time.time + spawnRate;
			randX = Random.Range(-8.4f, 8.4f);
			whereToSpawn = new Vector2(randX,transform.position.y);
			int choice = Random.Range(0, 3);
			GameObject[] planetOptions = new GameObject[] {planetA, planetB, planetC};
			Instantiate(planetOptions[choice], whereToSpawn, Quaternion.identity);

		}
	}
}
