﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour
{

	public EventSystem eventSystem;
	public GameObject selectedObject;
	public GameObject currentbutton;

	private bool buttonSelected;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)
		{
			eventSystem.SetSelectedGameObject(selectedObject);
			//currentbutton = eventSystem.currentSelectedGameObject;
			buttonSelected = true;
		}
		
	}


	void onDisable()
	{
		buttonSelected = false;
	}
}