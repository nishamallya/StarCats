using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GunButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public Button btn;
	public static int Gunprice = 100;
	public string Message = "";
	public GameObject childtext;

	public bool HasGun = false;
	// Use this for initialization
	void Start ()
	{
		btn = GetComponent<Button>();
		childtext.SetActive(false);

		btn.onClick.AddListener(AddGun);
		if (ScoreManager.storageA < Gunprice)
		{
			btn.interactable = false;
		}
	}
	
	
	// Update is called once per frame
	private void AddGun()
	{
		if (HasGun == false)
		{
			ScoreManager.AddScore(-Gunprice);
			btn.interactable = false;
			HasGun = true;

		}
	}

	void Update()
	{
		if (ScoreManager.storageA < Gunprice)
		{
			btn.interactable = false;
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
