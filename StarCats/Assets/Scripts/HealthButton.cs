using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthButton : MonoBehaviour {

	public Button btn;
	public static int Healthprice = 10;

	// Use this for initialization
	void Start ()
	{
		btn = GetComponent<Button>();

		btn.onClick.AddListener(AddHealth);
		if (ScoreManager.storageA < Healthprice | Health.healthcount >= Health.maxhealth)
		{
			btn.interactable = false;
		}
	}
	
	// Update is called once per frame
	private void AddHealth()
	{
		ScoreManager.AddScore(-Healthprice);
		Health.AddHealth(10);
	}

	void Update()
	{
		if (ScoreManager.storageA < Healthprice | Health.healthcount >= Health.maxhealth)
		{
			btn.interactable = false;
		}
	}
}
