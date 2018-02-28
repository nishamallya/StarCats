﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

	public float time;
	private Text _TimeRemaining;
	public static bool Level1Complete = false;
	public GameObject levelcomplete;
		
	// Use this for initialization
	internal void Start ()
	{
		_TimeRemaining = GetComponent<Text>();
		levelcomplete.SetActive(false);

	}


	private void FixedUpdate()
	{
		time -= Time.fixedDeltaTime;
		_TimeRemaining.text = "Time Remaining: " + time.ToString("f0");

		if (time <= 0)
		{
			if (Level1Complete == false)
			{
				//SceneManager.LoadScene("Purchase Menu");
				Time.timeScale = 0.00001f;
				StartCoroutine(Level1Screen());

			}
			else
			{
				GameOver();
			}
			
		
			
		}
		

	}

	public void GameOver()
	{
		SceneManager.LoadScene("Game Over");
	}

	IEnumerator Level1Screen()
	{
		levelcomplete.SetActive(true);
		yield return new WaitForSecondsRealtime(2);
		Level1Complete = true;
		Time.timeScale = 1;
		SceneManager.LoadScene("Purchase Menu");
		
	}

	IEnumerator Level2Screen()
	{
		levelcomplete.SetActive(true);
		yield return new WaitForSecondsRealtime(2);
		Time.timeScale = 1;
		SceneManager.LoadScene("Game Over");
	}

}
