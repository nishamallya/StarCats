using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class Trap : MonoBehaviour
{

	public Transform trap;
	private Vector2 startPos;
	public float speed;
	public float maxBound, minBound;
	public Camera cam;
	public float topBound;
	public float bottomBound;
	public bool isSet;
	public PlayerController temp_player;
	public float trapTime;	
	private bool isBlinking;

	// Use this for initialization
	void Start ()
	{
		trap = GetComponent<Transform>();
		startPos = trap.position;
		cam = Camera.main;
		maxBound = cam.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
		minBound = cam.ScreenToWorldPoint(new Vector2(0,0)).x;
		topBound = cam.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
		bottomBound = cam.ScreenToWorldPoint(new Vector2(0, 0)).y;
		//opacity
		//trap.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
		isSet = false;
		temp_player = FindObjectOfType<PlayerController>();
		trapTime = 10.0f;
		isBlinking = false;


	}

	void setPosition()
	{
		//movements
		var pos = trap.position;
		/*if (Input.GetButton("TrapLeft") && pos.x > minBound)
		{
			pos = pos - (new Vector3(0.5f, 0.0f,0.0f));
			trap.position = pos;
		}
		if (Input.GetButton("TrapRight") && pos.x < maxBound)
		{
			pos = pos + (new Vector3(0.5f, 0.0f,0.0f));
			trap.position = pos;
		}
		*/
		float x = Input.GetAxisRaw("RightJoystickHorizontal");
		
		if( x < 0.1f  && x > -0.1f){
			x = 0.0f;
        }
		
		pos = pos + (new Vector3(x, 0.0f,0.0f));
		trap.position = pos;
	
		/*
		float horizontal = Input.GetAxis("RightJoystickHorizontal");
		float vert = Input.GetAxis("RightJoystickVertical");
		Vector3 movement = new Vector3(horizontal, vert, 0.0f);
		trap.position = trap.position + ((float) 0.2 * movement);
		*/
		
		//looping behavior, +-1 added to accomodate width of player object
		if (pos.x < minBound + 1) 
		{
			pos.x = maxBound - 1;
		}
		if (pos.x > maxBound -1)
		{
			pos.x = minBound + 1;
		}
		if (pos.y < bottomBound + 1)
		{
			pos.y = topBound - 1;
		}
		if (pos.y > topBound - 1)
		{
			pos.y = bottomBound + 1;
		}	
	
		trap.position = pos;
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		
		
		if (!isSet)
		{
			setPosition();
		}

		if (Input.GetButtonDown("CreateTrap") && temp_player.canSetTrap == false)
		{
			isSet = true;
			//trap.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			StartCoroutine(TrapSetting());
		}
		

		if (isSet)
		{
			trapTime -= Time.fixedDeltaTime;

			if (trapTime < 3 & !isBlinking)
			{
				InvokeRepeating("Blink", 0.0f, 0.15f);
				isBlinking = true;
			}

			if (trapTime < 0)
			{
				Destroy(gameObject);
			}
		}
	}

	IEnumerator TrapSetting()
	{
		yield return new WaitForSeconds(0.5f);
		temp_player.canSetTrap = true;


	}
	public void Blink()
	{
		//GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;


	}

	
}
