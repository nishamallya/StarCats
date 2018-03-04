using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReplayButton : MonoBehaviour {

	public Button btn;
	// Use this for initialization
	void Start () {
		btn = GetComponent<Button>();

		btn.onClick.AddListener(RestartGame);
	}
	
	// Update is called once per frame
	private void RestartGame()
	{
		TrapCounter.trapCount = 0;
		Health.healthcount = 200;
		ScoreManager.storageA = 300;
		SceneManager.LoadScene("Purchase Menu");
		Timer.Level1Complete = false;

	}
}
