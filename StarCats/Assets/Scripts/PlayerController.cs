﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Transform player;
    private static float speed;
	public float maxBound, minBound;
	public Rigidbody2D rb;
	public float thrust;
	public Camera cam;
	public GameObject trap;
	public bool canSetTrap;
	private static string inputName;
	private static float initialSpeed;
	public GameObject timerpanel;
	public float countdowntime;
	public int trapButtonCount;
	
	//bullet controller details
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	
	
	
	
	

	// Use this for initialization
	void Start ()

	{
		StartCoroutine(Pause());
		countdowntime = 3;
		Screen.fullScreen = true;
		player = GetComponent<Transform>();
		rb = GetComponent<Rigidbody2D>();
		maxBound = cam.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
		minBound = cam.ScreenToWorldPoint(new Vector2(0,0)).x;
		canSetTrap = true;
		inputName = "Horizontal";
		speed = 15f;
		initialSpeed = speed;
		trapButtonCount = 0;

	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetAxis("Trigger") > 0.9 && Time.fixedTime > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
		
		if (Input.GetButton("CreateTrap") && canSetTrap && TrapCounter.trapCount > 0)
		{
			Vector2 butt = new Vector2(0, 0);
			Instantiate(trap,butt,Quaternion.identity);
			canSetTrap = false;
			TrapCounter.AddTrap(-1);
			trapButtonCount++;

		}

		if (Input.GetButtonUp("CreateTrap"))
		{
			trapButtonCount = 0;
		}

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

	void Update()
	{
		
	}
	
	IEnumerator NormalInput()
	{
		yield return new WaitForSeconds(5);
		inputName = "Horizontal";

	}
	
	public static void FlipInput()
	{
		inputName = "FlippedHorizontal";

	}

	public static void SlowDown()
	{
		speed = initialSpeed * 0.2f;
	}

	IEnumerator NormalSpeed()
	{
		yield return new WaitForSeconds(5);
		speed = initialSpeed;
	}

	public void StartCountDown()
	{
		timerpanel.SetActive(true);
		countdowntime -= Time.realtimeSinceStartup;

	}
	
	private IEnumerator Pause()
	{
		Time.timeScale = 0.00001f;
		timerpanel.SetActive(true);
		float pauseEndTime = Time.realtimeSinceStartup + 3;
		while (Time.realtimeSinceStartup < pauseEndTime)
		{
			yield return 0;
			timerpanel.GetComponentInChildren<Text>().text = Mathf.RoundToInt(pauseEndTime - Time.realtimeSinceStartup).ToString();

		}
		
		timerpanel.SetActive(false);
		Time.timeScale = 1;
	}
}
