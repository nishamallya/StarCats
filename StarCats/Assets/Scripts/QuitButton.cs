using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour {
	
	public Button btn;
	// Use this for initialization
	void Start () {
		
		btn.onClick.AddListener(QuitGame);
	}
	
	// Update is called once per frame
	
	private void QuitGame()
	{
		EditorApplication.isPlaying = false; //unity editor
		
		Application.Quit(); //standalone
	
	}
}
