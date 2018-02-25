using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

	public static int healthcount;
	private static Text _Health;
	public static Slider HealthSlider;
	public static int maxhealth = 200;
		
	// Use this for initialization
	internal void Start ()
	{
		_Health = GetComponent<Text>();
		HealthSlider = FindObjectOfType<Slider>();
		healthcount = 200;
		UpdateHealth();
	}

	public static void AddHealth (int value)
	{
		healthcount += value;
		UpdateHealth();
	}
	

	public static void UpdateHealth()
	{
		//_Health.text = "Health: " + healthcount;
		HealthSlider.value = healthcount;

	}
	
	private void FixedUpdate()
	{
		
		if (healthcount <= 0)
		{
			GameOver();
		}

	}

	public void GameOver()
	{
		SceneManager.LoadScene("Game Over");
	}
}
