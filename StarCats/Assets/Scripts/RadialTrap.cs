using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialTrap : MonoBehaviour {

	public Transform trap;

	public Camera cam;

	public bool isSet;
	public PlayerRadial temp_player;

    private string _moveAxis;
	
	public float trapTime;	
	private bool isBlinking;
	private float radius = 1.8f;
	private float tiltAngle;
	private static float speed = 0.3f;
	private static float initialSpeed;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
	{
		trap = GetComponent<Transform>();
		cam = Camera.main;
		rb = GetComponent<Rigidbody2D>();
		initialSpeed = speed;
		tiltAngle = 0f;
		
		isSet = true; //make false if activate to set
		temp_player = FindObjectOfType<PlayerRadial>();
		trapTime = 10.0f;
		isBlinking = false;

        GetMoveAxis();
	}

	void setPosition()
	{
		//movements
		var pos = trap.position;

		
		float horizontal = Input.GetAxisRaw(_moveAxis) * 0.8f;
		if( horizontal < 0.2f  && horizontal > -0.2f){
			horizontal = 0.0f;
		}
		//"Horizontal");	
		Vector2 movement = new Vector2(horizontal, 0.0f);
		var angle = ((horizontal * speed / (3 * radius * Mathf.PI))) * 2 * Mathf.PI;
		var toDegree = 360f / (2 * Mathf.PI);
		tiltAngle += angle;
		var xPos = Mathf.Sin(tiltAngle) * 1.5f * radius;
		var yPos = Mathf.Cos(tiltAngle) * 1.5f  *radius;
		transform.position = new Vector3(xPos, yPos, 0f);
		transform.Rotate (-Vector3.forward * angle * toDegree);
		
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		
		
		//if (!isSet)
		{
			setPosition();
		}

		//if (Input.GetButtonDown("CreateTrap") && temp_player.canSetTrap == false)
		{
			//isSet = true;
			//trap.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			//StartCoroutine(TrapSetting());
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
				PlayerRadial.canSetTrap = true;
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
