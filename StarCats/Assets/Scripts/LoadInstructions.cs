using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadInstructions : MonoBehaviour {

	
	public Button btn;
	// Use this for initialization
	void Start () {
		btn = GetComponent<Button>();

		btn.onClick.AddListener(RestartGame);
	}
	
	// Update is called once per frame
	private void RestartGame()
	{
	
		SceneManager.LoadScene("Instructions");


	}
}
