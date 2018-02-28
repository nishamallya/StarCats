using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GrenadeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public Button btn;
	public static int grenadeprice = 50;
	public GameObject childtext;


	//public bool HasGun = false;
	// Use this for initialization
	void Start ()
	{
		btn = GetComponent<Button>();
		childtext.SetActive(false);

		btn.onClick.AddListener(AddGun);
		if (ScoreManager.storageA < grenadeprice)
		{
			btn.interactable = false;
		}
	}
	
	
	// Update is called once per frame
	private void AddGun()
	{
		if (ScoreManager.storageA >= grenadeprice && GrenadeCounter.gCount < GrenadeCounter.maxgrenades)
		{
			ScoreManager.AddScore(-grenadeprice);
			GrenadeCounter.AddGrenade(1);
		}
	}

	void Update()
	{
		if (ScoreManager.storageA < grenadeprice)
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
