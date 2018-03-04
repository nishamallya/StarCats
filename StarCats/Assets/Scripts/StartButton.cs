using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class StartButton : MonoBehaviour {

	public Button btn;
	
	// Use this for initialization
	void Start () {
		
		btn = GetComponent<Button>();
		btn.onClick.AddListener(PlayGame);
		
		
	}

	private void PlayGame(){
		
			SceneManager.LoadScene("Purchase Menu");
		
	}
	
	
}
