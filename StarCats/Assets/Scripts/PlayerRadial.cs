using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRadial : MonoBehaviour
{

	private float radius = 1.8f;
	private float tiltAngle;
	private static float speed = 0.2f;
	private static float initialSpeed;
	private Rigidbody2D rb;
	private static string inputName;
	
	public GameObject shot;
	public Transform shotSpawn;
	public static float fireRate;
	private float nextFire;
	public static float initialFireRate;

    private string _fireAxis;
    private string _nudeAxis;
    private string _trapAxis;

    //new additions
    public static GameObject slow;
    public static GameObject reverse;
    public GameObject grenade;
	
	public GameObject radialtrap;
	public static bool canSetTrap;
	
	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody2D>();
		initialSpeed = 0.2f;
		tiltAngle = 0f;
		inputName = "Horizontal";
		canSetTrap = true;
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
	void FixedUpdate () {
		
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
			Instantiate(radialtrap,butt,Quaternion.identity);
			//StartCoroutine(ActivateTrap());
			TrapCounter.AddTrap(-1);
			canSetTrap = false;
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
	public static void SpeedUp()
	{
		speed = initialSpeed * 1.8f;
		//fireRate = 0.12f;
	}

	public static void SlowDown()
	{
		speed = initialSpeed * 0.2f;

		
	}

	IEnumerator NormalSpeed()
	{
		//slow.SetActive(true);
		yield return new WaitForSeconds(5);
		speed = initialSpeed;
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
