using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartIntroOne : MonoBehaviour {

	public Button btn;
	// Use this for initialization
	void Start () {
		
		btn.onClick.AddListener(LoadMenu);
	}
	
	// Update is called once per frame
	
	private void LoadMenu()
	{
		SceneManager.LoadScene("Purchase Menu");
	
	}
}
