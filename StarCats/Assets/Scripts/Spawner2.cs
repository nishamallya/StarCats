using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour {

	public GameObject planetA;
	public GameObject speedUp;
	public GameObject healthBoost;
	public GameObject doublePoints;
	public GameObject enemies;
	public GameObject FlipEnemy;
	public GameObject SlowDownEnemy;
	public float randX;
	private float ranY;
	Vector2 whereToSpawn;
	private float spawnRate = 0.61f;
	float nextSpawn = 5.0f;
	private GameObject[] toSpawn;
	private int toSpawnIndex;


	
    
	// Use this for initialization
	void Start () {
		WhatToSpawn();
		toSpawnIndex = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.fixedTime > nextSpawn && Time.timeSinceLevelLoad < 55) //start spawning after countdown, stop spawning 3 seconds before level ends
		{
			
			//element spawns
			nextSpawn = Time.fixedTime + spawnRate;
			randX = Random.Range(-9.4f, 9.4f);
			whereToSpawn = new Vector2(randX,transform.position.y);

			
			
//			int choice = Random.Range(0, 8);
//			GameObject[] planetOptions = new GameObject[] {planetA,planetA, enemies, planetB, planetC, enemies, enemies, planetB};
			Instantiate(toSpawn[toSpawnIndex++], whereToSpawn, Quaternion.identity);
			
			
		}
		
	}
	
	void WhatToSpawn()
	{
		toSpawn = new GameObject[90];
		int choice;
		for (int i = 1; i <= 20; i++)
		{
			if (1 <= i && i <= 5)
			{
				choice = Random.Range(0, 45);
				toSpawn[choice] = FlipEnemy;
				continue;
			}

			if (6 <= i && i <= 10)
			{
				choice = Random.Range(0, 45);
				toSpawn[choice] = SlowDownEnemy;
				continue;
			}

			if (11 <= i && i <= 15)
			{
				choice = Random.Range(45, 90);
				toSpawn[choice] = FlipEnemy;
				continue;
			}

			if (16 <= i && i <= 20)
			{
				choice = Random.Range(45, 90);
				toSpawn[choice] = SlowDownEnemy;
			}
			
		}

		for (int i = 0; i < 3; i++)
		{
			choice = Random.Range(0, 90);
			toSpawn[choice] = planetA; //speedUp; need to change this
		}
		
		for (int i = 0; i < 3; i++)
		{
			choice = Random.Range(0, 90);
			toSpawn[choice] = healthBoost;
		}
		
		for (int i = 0; i < 3; i++)
		{
			choice = Random.Range(0, 90);
			toSpawn[choice] = doublePoints;
		}

		int j = 0;
		while (j < 40)
		{
			choice = Random.Range(0, 90);
			if (toSpawn[choice] == null)
			{
				toSpawn[choice] = enemies;
				j++;
			}
		}

		for (int i = 0; i < 90; i++)
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
