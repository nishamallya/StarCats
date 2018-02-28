using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HealthButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public Button btn;
	public static int Healthprice = 10;
	public GameObject childtext;

	// Use this for initialization
	void Start ()
	{
		btn = GetComponent<Button>();
		childtext.SetActive(false);

		btn.onClick.AddListener(AddHealth);
		if (ScoreManager.storageA < Healthprice | Health.healthcount >= Health.maxhealth)
		{
			btn.interactable = false;
		}
	}
	
	// Update is called once per frame
	private void AddHealth()
	{
		if (ScoreManager.storageA >= Healthprice && Health.healthcount < Health.maxhealth)
		{
			ScoreManager.AddScore(-Healthprice);
			Health.AddHealth(10);
		}
		
		
	}

	void Update()
	{
		if (ScoreManager.storageA < Healthprice | Health.healthcount >= Health.maxhealth)
		{
			//btn.interactable = false;
		}
	}
	
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (btn.interactable)
		{
			childtext.SetActive(true);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		childtext.SetActive(false);
	}
}
