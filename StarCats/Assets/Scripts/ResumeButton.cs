using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{

	public Button btn;

	// Use this for initialization
	void Start () {
		btn.onClick.AddListener(ResumeGame);
		
	}

	private void ResumeGame()
	{
		Time.timeScale = 1;
		GetComponentInParent<PauseMenu>().gameObject.SetActive(false);
	}
}
