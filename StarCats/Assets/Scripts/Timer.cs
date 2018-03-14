using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

	public float time;
	private Text _TimeRemaining;
	public static bool Level1Complete = false;
	public GameObject levelcomplete;
	public GameObject PauseMenu;
	public GameObject timerpanel;
	public float countdowntime;

    private string _pauseAxis;
		
	// Use this for initialization
	internal void Start ()
	{
		_TimeRemaining = GetComponent<Text>();
		levelcomplete.SetActive(false);
		PauseMenu.SetActive(false);
		countdowntime = 3;
		StartCoroutine(Pause());

        GetPauseAxis();
	}


	private void FixedUpdate()
	{

		if (time >= 0)
		{
			time -= Time.fixedDeltaTime;
			_TimeRemaining.text = "Time: " + time.ToString("f0");
		}

		if (time <= 0)
		{
			
			levelcomplete.SetActive(true);
			/*if (Level1Complete == false)
			{
				Level1Complete = true;
				StartCoroutine(Level1Screen());
			}
			else
			{
				StartCoroutine(Level2Screen());
			}*/
				
		}
		
		
	}

	private void Update()
	{
		if (Input.GetButtonDown(_pauseAxis) && timerpanel.activeSelf == false) 
		{
			if (PauseMenu.activeSelf)
			{
				PauseMenu.SetActive(false);
				Time.timeScale = 1f;
			}
			else
			{
				PauseMenu.SetActive(true);
				Time.timeScale = 0.0001f;
			}
		}
	}
	public void GameOver()
	{
		SceneManager.LoadScene("Game Over");
	}

	IEnumerator Level1Screen()
	{

		levelcomplete.SetActive(true);
		yield return new WaitForSeconds(1.5f);
		//Time.timeScale = 1;
		SceneManager.LoadScene("Purchase Menu");
	}



	IEnumerator Level2Screen()
	{
		levelcomplete.SetActive(true);
		yield return new WaitForSecondsRealtime(1.5f);
		//Time.timeScale = 1;
		SceneManager.LoadScene("Game Over");
	}

	private IEnumerator Pause()
	{
		Time.timeScale = 0.00001f;
		timerpanel.SetActive(true);
		float pauseEndTime = Time.realtimeSinceStartup + 3;
		while (Time.realtimeSinceStartup < pauseEndTime)
		{
			yield return 0;
			timerpanel.GetComponentInChildren<Text>().text = Mathf.RoundToInt(pauseEndTime - Time.realtimeSinceStartup).ToString();

		}
		
		timerpanel.SetActive(false);
		Time.timeScale = 1;
	}

    void GetPauseAxis()
    {
        if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor) _pauseAxis = "Start";
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer) _pauseAxis = "WindowsPause";
    }




}
