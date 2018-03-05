using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour {

	public Button btn;
	// Use this for initialization
	void Start () {
		
		btn.onClick.AddListener(MainMenu);
	}
	
	// Update is called once per frame
	
	private void MainMenu()
	{
		Time.timeScale = 1;
		//GetComponentInParent<PauseMenu>().gameObject.SetActive(false);
		SceneManager.LoadScene("MainMenu");
	}
}
