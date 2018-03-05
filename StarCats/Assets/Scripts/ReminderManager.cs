using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ReminderManager : MonoBehaviour {

	private static Text _reminder;
	public static GameObject _multiplier;
	public static GameObject _boost;
	
	

	void Start ()
	{
		_reminder = GetComponent<Text>();
		Text[] textobjects = FindObjectsOfType<Text>();
		foreach (Text t in textobjects)
		{
			if (t.gameObject.CompareTag("MultiplierEffect"))
			{
				_multiplier = t.gameObject;
			}
			
			if (t.gameObject.CompareTag("Boost"))
			{
				_boost = t.gameObject;
			}
		}

		_multiplier.SetActive(false);
		_boost.SetActive(false);


	}
	
	// Update is called once per frame
	void Update () {
		if (_reminder.gameObject.active)
		{
			StartCoroutine(ReminderDisappear());
		}
	}

	public static void ReverseControl()
	{
		_reminder.text = "Reverse Control!";
		_reminder.gameObject.SetActive(true);

		
	}

	public static void SlowDown()
	{
		_reminder.text = "Slowed Down!";
		_reminder.gameObject.SetActive(true);

	}

	IEnumerator ReminderDisappear()
	{
		yield return new WaitForSeconds(2);
		

		if (_multiplier.activeSelf)
		{
			_multiplier.SetActive(false);
		}
		
		if (_boost.activeSelf)
		{
			_boost.SetActive(false);
		}
		
		
		gameObject.SetActive(false);
		
		
		
	}
	
	public static void HealthBoost()
	{
		_reminder.text = "Health Boost!";
		_reminder.gameObject.SetActive(true);

		
	}
	
	public static void SpeedBoost()
	{
		_reminder.text = "Speed Boost!";
		_reminder.gameObject.SetActive(true);	
		_boost.SetActive(true);
	}
	
	public static void ScoreBoost()
	{
		_reminder.text = "Score Multiplier!";
		_reminder.gameObject.SetActive(true);
		_multiplier.SetActive(true);
	}
	
	
}
