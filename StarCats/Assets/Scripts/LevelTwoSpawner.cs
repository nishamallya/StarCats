using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoSpawner : MonoBehaviour {


	public GameObject planetA;
	public GameObject doublePoints;
	public GameObject enemies;
	public GameObject FlipEnemy;

	public float randX;
	Vector2 whereToSpawn;
	private float spawnRate = 0.6f;
	float nextSpawn = 0f;
	private GameObject[] toSpawn;
	public static int toSpawnIndex;
	
	
    
	// Use this for initialization
	void Start () {
		WhatToSpawn();
		toSpawnIndex = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.fixedTime > nextSpawn && Time.timeSinceLevelLoad < 40 && toSpawnIndex < 76) //start spawning 3s after game starts, stop spawning 3s before game ends
		{
			//element spawns
			nextSpawn = Time.fixedTime + spawnRate;
			randX = Random.Range(-8.4f, 8.4f);
			whereToSpawn = new Vector2(randX,transform.position.y);
			Instantiate(toSpawn[toSpawnIndex++], whereToSpawn, Quaternion.identity);
				
		}
		
	}
	// first level has 45 seconds, there will be 76 objects. 
	void WhatToSpawn()
	{
		toSpawn = new GameObject[76]; 
		int choice;
		
		for (int i = 0; i < 76; i++)
		{
			if (1 <= i && i <= 25)
			{
				choice = Random.Range(0, 75);
				toSpawn[choice] = FlipEnemy;
				continue;
			}

			if (26 <= i && i <= 50)
			{
				choice = Random.Range(0, 75);
				toSpawn[choice] = enemies;
				continue;
			}

			if (51 <= i && i <= 69)
			{
				choice = Random.Range(0, 75);
				toSpawn[choice] = planetA;
			}
			
			if (70 <= i && i <= 75)
			{
				choice = Random.Range(0, 75);
				toSpawn[choice] = doublePoints;
			}
			
		}


		for (int i = 0; i < 76; i++)
		{
			if (toSpawn[i] == null)
			{
				toSpawn[i] = enemies;
			}
		}
		
	}
}
