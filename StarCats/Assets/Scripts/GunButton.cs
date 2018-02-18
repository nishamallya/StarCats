using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class GunButton : MonoBehaviour
{
	public Button btn;
	public static int Gunprice = 100;
	public string Message = "";

	public bool HasGun = false;
	// Use this for initialization
	void Start ()
	{
		btn = GetComponent<Button>();

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
	
}
