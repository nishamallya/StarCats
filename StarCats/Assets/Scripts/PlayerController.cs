using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerController : MonoBehaviour {

    public Transform player;
    public float speed;
	public float maxBound, minBound;
	public Rigidbody2D rb;
	public float thrust;
	public Camera cam;
	public GameObject trap;
	public bool canSetTrap;
	
	

	// Use this for initialization
	void Start ()
	{
		player = GetComponent<Transform>();
		rb = GetComponent<Rigidbody2D>();
		maxBound = cam.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
		minBound = cam.ScreenToWorldPoint(new Vector2(0,0)).x;
		canSetTrap = true;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetKeyDown("return") && canSetTrap == true)
		{
			Vector2 butt = new Vector2(0, 0);
			Instantiate(trap,butt,Quaternion.identity);
			canSetTrap = false;
		}
		
		float horizontal = Input.GetAxis("Horizontal");	
		Vector2 movement = new Vector2(horizontal, 0.0f);
		rb.velocity = movement * speed;

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
}
