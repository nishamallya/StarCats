using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawnerScript : MonoBehaviour
{


	public GameObject planetA;
	public GameObject planetB;
	public GameObject planetC;
	public GameObject enemies;
	public float randX;
	Vector2 whereToSpawn;
	public float spawnRate = 1.5f;
	float nextSpawn = 0.0f;
	
	
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.fixedTime > nextSpawn)
		{
			//element spawns
			nextSpawn = Time.fixedTime + spawnRate;
			whereToSpawn = new Vector2(randX,transform.position.y);
			randX = Random.Range(-8.4f, 8.4f);
			int choice = Random.Range(0, 6);
			GameObject[] planetOptions = new GameObject[] {planetA, planetA, planetB, planetC, enemies, enemies};
			Instantiate(planetOptions[choice], whereToSpawn, Quaternion.identity);
			
			
		}
		
	}
}
