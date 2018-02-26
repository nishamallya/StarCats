using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{

	public Button btn;
	// Use this for initialization
	void Start () {
		btn = GetComponent<Button>();

		btn.onClick.AddListener(PlayGame);
	}
	
	// Update is called once per frame
	private void PlayGame(){
		if (Timer.Level1Complete)
		{
			SceneManager.LoadScene("Level2");
		}
		
		else 
		SceneManager.LoadScene("scene_001");
		
	}
}
