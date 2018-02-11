using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Transform player;
    public float speed;
	public float maxBound, minBound;
	public Rigidbody2D rb;
	public float thrust;

	// Use this for initialization
	void Start ()
	{
		player = GetComponent<Transform>();
		//rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*
		if (Input.GetKey(KeyCode.RightArrow))
		{
			rb.AddForce(new Vector2(5,0));
		}
		
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			rb.AddForce(new Vector2(-5,0));
		}
		*/
		/*
		

		if (player.position.x < minBound && h < 0)
		{
			h = 0;
		}
		else if (player.position.x > maxBound && h > 0)
		{
			h = 0;
		}
		*/
		float h = Input.GetAxis("Horizontal"); //uses the A&D key
		player.position += Vector3.right * h * speed;

	}
}
