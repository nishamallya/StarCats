using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager3 : MonoBehaviour {

	private static int storageC;
	private static Text _CScore;
		
	// Use this for initialization
	internal void Start ()
	{
		_CScore = GetComponent<Text>();
		UpdateScore();
	}

	public static void AddScore (int value)
	{
		storageC += value;
		UpdateScore();
	}

	private static void UpdateScore()
	{
		_CScore.text = "Fire: " + storageC;

	}
}
