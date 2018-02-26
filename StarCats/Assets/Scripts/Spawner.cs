using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject planetA;

	public GameObject enemies;
	public GameObject FlipEnemy;
	public GameObject SlowDownEnemy;
	public float randX;
	private float ranY;
	Vector2 whereToSpawn;
	public float spawnRate = 0.5f;
	float nextSpawn = 0.0f;
	private GameObject[] toSpawn;
	private int toSpawnIndex;

	private int spawnPos = 1;
	
	
    
	// Use this for initialization
	void Start () {
		WhatToSpawn();
		toSpawnIndex = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.fixedTime > nextSpawn)
		{
			spawnPos = Random.Range(1, 5);
			//Up
			if (spawnPos == 1)
			{
				//element spawns
				nextSpawn = Time.fixedTime + spawnRate;
				randX = Random.Range(-8.4f, 8.4f);
				whereToSpawn = new Vector2(randX,transform.position.y);

			}
			//Down
			if (spawnPos == 2)
			{
				//element spawns
				nextSpawn = Time.fixedTime + spawnRate;
				randX = Random.Range(-8.4f, 8.4f);
				whereToSpawn = new Vector2(randX,-transform.position.y);

			}
			//Left
			if (spawnPos == 3)
			{
				//element spawns
				nextSpawn = Time.fixedTime + spawnRate;
				ranY = Random.Range(-5.8f, 5.8f);
				whereToSpawn = new Vector2(-8.4f,ranY);
			}
			//Right
			if (spawnPos == 4)
			{
				//element spawns
				nextSpawn = Time.fixedTime + spawnRate;
				ranY = Random.Range(-5.8f, 5.8f);
				whereToSpawn = new Vector2(8.4f,ranY);


			}
			
//			int choice = Random.Range(0, 8);
//			GameObject[] planetOptions = new GameObject[] {planetA,planetA, enemies, planetB, planetC, enemies, enemies, planetB};
			Instantiate(toSpawn[toSpawnIndex++], whereToSpawn, Quaternion.identity);
			
			
		}
		
	}
	// first level has 90 seconds, there will be 180 objects. 1 enemy every 5 seconds (18 enemies), 2 flip enemies, 2 slow down enemies.
	void WhatToSpawn()
	{
		toSpawn = new GameObject[180];
		int choice = 0;
		for (int i = 1; i <= 8; i++)
		{
			if (i == 1 || i == 2)
			{
				choice = Random.Range(0, 90);
				toSpawn[choice] = FlipEnemy;
				continue;
			}

			if (i == 3 || i == 4)
			{
				choice = Random.Range(0, 90);
				toSpawn[choice] = SlowDownEnemy;
				continue;
			}

			if (i == 5 || i == 6)
			{
				choice = Random.Range(90, 180);
				toSpawn[choice] = FlipEnemy;
				continue;
			}

			if (i == 7 || i == 8)
			{
				choice = Random.Range(90, 180);
				toSpawn[choice] = SlowDownEnemy;
			}

		}

		int j = 0;
		while (j < 52)
		{
			choice = Random.Range(0, 180);
			if (toSpawn[choice] == null)
			{
				toSpawn[choice] = enemies;
				j++;
			}
		}

		for (int i = 0; i < 180; i++)
		{
			if (toSpawn[i] == null)
			{
				int innerChoice = Random.Range(0, 3);
				GameObject[] planetOptions = new GameObject[] {planetA, planetA, planetA};
				toSpawn[i] = planetOptions[innerChoice];
			}
		}
	}

}
