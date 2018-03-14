﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Transform player;
    private static float speed;
	public float maxBound, minBound;
	public Rigidbody2D rb;
	public float thrust;
	public Camera cam;
	public GameObject trap;
	public static bool canSetTrap;
	private static string inputName;
	private static float initialSpeed;
	private static float initialFireRate;

    private string _fireAxis;
    private string _nudeAxis;
    private string _trapAxis;

    public static GameObject slow;
	public static GameObject reverse;

	//bullet controller details
	public GameObject shot; //bullet
	public GameObject grenade;
	public Transform shotSpawn;
	public static float fireRate;
	private float nextFire;
	
	
	
	
	

	// Use this for initialization
	void Start ()

	{

		Screen.fullScreen = true;
		player = GetComponent<Transform>();
		rb = GetComponent<Rigidbody2D>();
		maxBound = cam.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
		minBound = cam.ScreenToWorldPoint(new Vector2(0,0)).x;
		canSetTrap = true;
		inputName = "Horizontal";
		speed = 15f;
		initialSpeed = speed;
		fireRate = 0.2f;
		initialFireRate = fireRate;
		reverse = GameObject.FindGameObjectWithTag("ReverseEffect");
		slow = GameObject.FindGameObjectWithTag("SlowEffect");
		DeactivateEffects();

        GetFireAxis();
        GetNudeAxis();
        GetTrapAxis();





    }

	static void DeactivateEffects()
	{
		slow.SetActive(false);
		reverse.SetActive(false);
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetAxis(_fireAxis) > 0.9 && Time.fixedTime > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			
		}
		
		if (Input.GetAxis(_nudeAxis) > 0.9 && Time.fixedTime > nextFire && GrenadeCounter.gCount > 0)
		{
			nextFire = Time.time + fireRate;
			Instantiate(grenade, shotSpawn.position, shotSpawn.rotation);
			GrenadeCounter.AddGrenade(-1);
			
		}
		
		if (Input.GetButtonDown(_trapAxis) && canSetTrap && TrapCounter.trapCount > 0)
		{
			Vector2 butt = new Vector2(0, 0);
			Instantiate(trap,butt,Quaternion.identity);
			//StartCoroutine(ActivateTrap());
			TrapCounter.AddTrap(-1);
			canSetTrap = false;
		}
		

		/*if (Input.GetButtonDown("CreateTrap"))
		{
			if (trapclick % 2 != 0 && canSetTrap && TrapCounter.trapCount > 0)
			{
				Vector2 bt = new Vector2(0, 0);
				Instantiate(trap, bt, Quaternion.identity);
				canSetTrap = false;
				TrapCounter.AddTrap(-1);
				trapclick++;

			}
			else trapclick++;
			*/


		

		float horizontal = Input.GetAxis(inputName); //"Horizontal");	
		Vector2 movement = new Vector2(horizontal, 0.0f);
		rb.velocity = movement * speed;

		if (inputName == "FlippedHorizontal")
		{
			StartCoroutine(NormalInput());
			
		}

		if (speed < initialSpeed)
		{
			StartCoroutine(NormalSpeed());
		}
		
		var pos = rb.position;
		//rb.position = new Vector2(Mathf.Clamp(rb.position.x, minBound, maxBound), rb.position.y);

		/*if (Input.GetKey(KeyCode.RightArrow))
		{
			rb.AddForce(new Vector2(5,0));
		}
		
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			rb.AddForce(new Vector2(-5,0));
		}
		
		*/
		if (pos.x < minBound + 1) //looping behavior, +-1 added to accomodate width of player object
		{
			pos.x = maxBound - 1;
		}
		if (pos.x > maxBound -1)
		{
			pos.x = minBound + 1;
		}

		rb.position = pos;
		
		//float h = Input.GetAxis("Horizontal"); //uses the A&D key
		//player.position += Vector3.right * h * speed;
		
		

	}

	IEnumerator ActivateTrap()
	{
		yield return new WaitForSeconds(0.5f);
		canSetTrap = false;
	}
	
	
	
	IEnumerator NormalInput()
	{
		yield return new WaitForSeconds(5);
		inputName = "Horizontal";
		reverse.SetActive(false);		

	}
	
	public static void FlipInput()
	{
		inputName = "FlippedHorizontal";


	}

	public static void SlowDown()
	{
		speed = initialSpeed * 0.2f;
		fireRate = initialFireRate;

	}
	
	
	public static void SpeedUp()
	{
		speed = initialSpeed * 1.8f;
		fireRate = 0.12f;
	}

	IEnumerator NormalSpeed()
	{
		yield return new WaitForSeconds(5);
		speed = initialSpeed;
		fireRate = initialFireRate;
		slow.SetActive(false);
	}

    void GetFireAxis()
    {
        if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor) _fireAxis = "Trigger";
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer) _fireAxis = "WindowsFire";
    }

    void GetNudeAxis()
    {
        if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor) _nudeAxis = "LeftTrigger";
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer) _nudeAxis = "WindowsNude";
    }

    void GetTrapAxis()
    {
        if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor) _trapAxis = "CreateTrap";
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer) _trapAxis = "WindowsTrap";
    }
}
