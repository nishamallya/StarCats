using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapCounter : MonoBehaviour {

	public static int trapCount = 5;
	private static Text _Trap;
	public static int maxtraps = 5;
		
	// Use this for initialization
	internal void Start ()
	{
		_Trap = GetComponent<Text>();
		UpdateTrap();
	}

	public static void AddTrap (int value)
	{
		trapCount += value;
		UpdateTrap();
	}
	

	public static void UpdateTrap()
	{
		_Trap.text = "Traps: " + trapCount;
	}

}
