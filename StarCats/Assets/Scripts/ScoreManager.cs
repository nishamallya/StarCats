using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

	public static int storageA = 300;
	private static Text _AScore;
	public static int multiplier = 1;


	// Use this for initialization
	internal void Start ()
	{
		_AScore = GetComponent<Text>();
		UpdateScore();

	}

	private void Update()
	{
		if (multiplier != 1)
		{
			StartCoroutine(ResetMultiplier());
		}
	}

	public static void AddScore (int value)
	{
		storageA += value * multiplier;
		UpdateScore();
	}

	public int GetScore()
	{
		return storageA;
	}
	

	public static void UpdateScore()
	{
		_AScore.text = "Points: " + storageA;

	}

	IEnumerator ResetMultiplier()
	{
		//slow.SetActive(true);
		yield return new WaitForSeconds(5);
		multiplier = 1;
		
	}
}
