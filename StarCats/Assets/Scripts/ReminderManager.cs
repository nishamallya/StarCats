using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ReminderManager : MonoBehaviour {

	private static Text _reminder;
	

	void Start ()
	{
		_reminder = GetComponent<Text>();

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
		gameObject.SetActive(false);
	}
}
