using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager2 : MonoBehaviour {

	private static int storageB;
	private static Text _BScore;
		
	// Use this for initialization
	internal void Start ()
	{
		_BScore = GetComponent<Text>();
		UpdateScore();
	}

	public static void AddScore (int value)
	{
		storageB += value;
		UpdateScore();
	}

	private static void UpdateScore()
	{
		_BScore.text = "Counter B: " + storageB;

	}
}
