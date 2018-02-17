using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

	public static int storageA = 500;
	private static Text _AScore;
		
	// Use this for initialization
	internal void Start ()
	{
		_AScore = GetComponent<Text>();
		UpdateScore();
	}

	public static void AddScore (int value)
	{
		storageA += value;
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
}
