using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Boundary : MonoBehaviour {

	public EdgeCollider2D edge;

	private static Vector4 _bounds;
	public UnityEngine.Camera cam;

	public List<Vector2> points = new List<Vector2>(); //coordinates for corners of screen

	private void Awake() //initialize boundary on screen
	{
		edge = GetComponent<EdgeCollider2D>();
		points.Add(cam.ScreenToWorldPoint(new Vector2(0, -100))); 		
		points.Add(cam.ScreenToWorldPoint(new Vector2(0,Screen.height + 100)));		// +- 100 pixels past camera height 
		points.Add(cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height + 100)));		
		points.Add(cam.ScreenToWorldPoint(new Vector2(Screen.width, -100)));		
		points.Add(cam.ScreenToWorldPoint(new Vector2(0, -100)));
		edge.points = points.ToArray();
		
		
	}


}
