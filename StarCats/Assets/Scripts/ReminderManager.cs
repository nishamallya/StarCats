using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ReminderManager : MonoBehaviour {

	private static Text _reminder;
	//public static GameObject _multiplier;
	
	

	void Start ()
	{
		_reminder = GetComponent<Text>();
		Text[] textobjects = FindObjectsOfType<Text>();
		/*foreach (Text t in textobjects)
		{
			if (t.gameObject.CompareTag("MultiplierEffect"))
			{
				_multiplier = t.gameObject;
			}
		}

		if (_multiplier.active)
		{
			_multiplier.SetActive(false);
		}
		*/





	}
	
	// Update is called once per frame
	void Update () {
		if (_reminder.gameObject.active)
		{
			StartCoroutine(ReminderDisappear());
		}

		/*if (_multiplier.gameObject.activeInHierarchy)
		{
			StartCoroutine(MultiplierDisappear());
		}
		*/
		
		
		
		
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
		
		gameObject.SetActive(false);
		
		
	}
	
	/*IEnumerator MultiplierDisappear()
	{
		yield return new WaitForSeconds(5);
		_multiplier.SetActive(false);
		
	}
	*/
	
	
	public static void HealthBoost()
	{
		_reminder.text = "Health Boost!";
		_reminder.gameObject.SetActive(true);

		
	}
	
	public static void SpeedBoost() //speedup removed
	{
		_reminder.text = "Speed Boost!";
		_reminder.gameObject.SetActive(true);	
	}
	
	
	public static void ScoreBoost()
	{
		_reminder.text = "Score Multiplier!";
		_reminder.gameObject.SetActive(true);
		//_multiplier.SetActive(true);

	}
	
	
}
