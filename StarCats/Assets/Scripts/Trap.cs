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

    private string _moveAxis;

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
		isSet = true; //make false if click to activate
		temp_player = FindObjectOfType<PlayerController>();
		trapTime = 10.0f;
		isBlinking = false;

        GetMoveAxis();
    }

	void setPosition()
	{
		//movements
		var pos = trap.position;

		float x = Input.GetAxisRaw(_moveAxis)*0.8f;
		
		if( x < 0.2f  && x > -0.2f){
			x = 0.0f;
        }
		
		pos = pos + (new Vector3(x, 0.0f,0.0f));
		trap.position = pos;
	

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
		
		setPosition();
		isSet = true;


		//if (isSet)
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
				PlayerController.canSetTrap = true;
			}
		}
	}

	public void Blink()
	{
		GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;


	}

    void GetMoveAxis()
    {
        if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor) _moveAxis = "RightJoystickHorizontal";
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer) _moveAxis = "TrapMovement";
    }


}
