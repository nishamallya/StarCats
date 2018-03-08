using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInputPower : MonoBehaviour {

	public EventSystem eventSystem;
	public GameObject selectedObject;

	private bool buttonSelected;
	// Use this for initialization
	void Start () {
		eventSystem = EventSystem.current;
		eventSystem.SetSelectedGameObject(null);
		eventSystem.SetSelectedGameObject(selectedObject);
	}
	
	// Update is called once per frame
	void Update () {

		
		if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)
		{
			eventSystem.SetSelectedGameObject(selectedObject);
			buttonSelected = true;
		}
		
	}
	
	private void OnEnable()
	{
		eventSystem.SetSelectedGameObject(null);
		eventSystem.SetSelectedGameObject(selectedObject);
	}



	public void onDisable()
	{
		buttonSelected = false;
	}
}
