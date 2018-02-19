﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

	public static int healthcount = 80;
	private static Text _Health;
	public static int maxhealth = 100;
		
	// Use this for initialization
	internal void Start ()
	{
		_Health = GetComponent<Text>();
		UpdateHealth();
	}

	public static void AddHealth (int value)
	{
		healthcount += value;
		UpdateHealth();
	}
	

	public static void UpdateHealth()
	{
		_Health.text = "Health: " + healthcount;

	}
	
	private void FixedUpdate()
	{
		
		if (healthcount <= 0)
		{
			GameOver();
		}

	}

	public void GameOver()
	{
		SceneManager.LoadScene("Game Over");
	}
}
