using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TrapButton : MonoBehaviour {

	public Button btn;
	public static int Trapprice = 50;
	//public GameObject childtext;
	// Use this for initialization
	void Start ()
	{
		btn = GetComponent<Button>();
	

		
		btn.onClick.AddListener(AddTrap);
		if (ScoreManager.storageA < Trapprice)
		{
			btn.interactable = false;
		}
	}
	
	// Update is called once per frame
	private void AddTrap()
	{
		if (ScoreManager.storageA >= Trapprice && TrapCounter.trapCount < TrapCounter.maxtraps)
		{
			ScoreManager.AddScore(-Trapprice);
			TrapCounter.AddTrap(1);
		}
		
	}

	void Update()
	{
		
		if (ScoreManager.storageA < Trapprice || TrapCounter.trapCount >= TrapCounter.maxtraps)
		{
			//btn.interactable = false;
		}
	}
	

}
