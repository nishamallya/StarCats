using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneSpawner : MonoBehaviour {
	
	public GameObject coin;
	public GameObject enemies;
	public float randX;
	Vector2 whereToSpawn;
	private float spawnRate = 0.9f;
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
		if (Time.fixedTime > nextSpawn && Time.timeSinceLevelLoad < 26 && toSpawnIndex < 45) //start spawning 3s after game starts, stop spawning 3s before game ends
		{
			//element spawns
			nextSpawn = Time.fixedTime + spawnRate;
			randX = Random.Range(-8.4f, 8.4f);
			whereToSpawn = new Vector2(randX,transform.position.y);

//			int choice = Random.Range(0, 8);
//			GameObject[] planetOptions = new GameObject[] {planetA,planetA, enemies, planetB, planetC, enemies, enemies, planetB};
			Instantiate(toSpawn[toSpawnIndex++], whereToSpawn, Quaternion.identity);
			
			
		}
		
	}
	// first level has 30 seconds, there will be 40 objects. 25 enemies 15 coins 
	void WhatToSpawn()
	{
		toSpawn = new GameObject[40];
		int choice;
		for (int i = 0; i < 40; i++)
		{
			if (0 <= i && i <= 25)
			{
				choice = Random.Range(0, 39);
				toSpawn[choice] = enemies;
				continue;
			}

			if (26 <= i && i <= 39)
			{
				choice = Random.Range(0, 39);
				toSpawn[choice] = coin;
				continue;
			}			
		}

		for (int i = 0; i < 39; i++)
		{
			if (toSpawn[i] == null)
			{
				//int innerChoice = Random.Range(0, 3);
				//GameObject[] planetOptions = new GameObject[] {planetA, planetA, planetA};
				toSpawn[i] = enemies;
			}
		}
		
	}
}
