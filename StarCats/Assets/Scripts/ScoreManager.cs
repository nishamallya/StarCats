using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

	private static int storageA;
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

	private static void UpdateScore()
	{
		_AScore.text = "Counter A: " + storageA;

	}
}
