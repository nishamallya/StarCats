using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRadial : MonoBehaviour
{

	private float radius = 1.8f;
	private float tiltAngle;
	private static float speed = 0.3f;
	private static float initialSpeed;
	private Rigidbody2D rb;
	private static string inputName;
	public GameObject timerpanel;
	public float countdowntime;
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	
	public GameObject radialtrap;
	public bool canSetTrap;
	
	// Use this for initialization
	void Start () {
		StartCoroutine(Pause());
		countdowntime = 3;
		rb = GetComponent<Rigidbody2D>();
		initialSpeed = speed;
		tiltAngle = 0f;
		inputName = "Horizontal";
		canSetTrap = true;
	}
	
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (Input.GetAxis("Trigger") > 0.9 && Time.fixedTime > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
		
		if (Input.GetButtonDown("CreateTrap") && canSetTrap && TrapCounter.trapCount > 0)
		{
			Vector2 butt = new Vector2(0, 0);
			Instantiate(radialtrap,butt,Quaternion.identity);
			StartCoroutine(ActivateTrap());
			TrapCounter.AddTrap(-1);
		}
		
		float horizontal = Input.GetAxis(inputName); //"Horizontal");	
		Vector2 movement = new Vector2(horizontal, 0.0f);
		var angle = ((horizontal * speed / (2 * radius * Mathf.PI))) * 2 * Mathf.PI;
		var toDegree = 360f / (2 * Mathf.PI);
		tiltAngle += angle;
		var xPos = Mathf.Sin(tiltAngle) * radius;
		var yPos = Mathf.Cos(tiltAngle) * radius;
		transform.position = new Vector3(xPos, yPos, 0f);
		transform.Rotate (-Vector3.forward * angle * toDegree);
		
		if (inputName == "FlippedHorizontal")
		{
			StartCoroutine(NormalInput());
		}

		if (speed < initialSpeed)
		{
			StartCoroutine(NormalSpeed());
		}

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
