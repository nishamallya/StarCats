using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

	public float time;
	private Text _TimeRemaining;
		
	// Use this for initialization
	internal void Start ()
	{
		_TimeRemaining = GetComponent<Text>();

	}


	private void FixedUpdate()
	{
		time -= Time.fixedDeltaTime;
		_TimeRemaining.text = "Time Remaining: " + time.ToString("f0");
		
		if (time < 0)
		{
			GameOver();
		}

	}

	public void GameOver()
	{
		SceneManager.LoadScene("Game Over");
	}

}
