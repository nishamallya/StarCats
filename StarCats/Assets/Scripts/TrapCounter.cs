using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapCounter : MonoBehaviour {

	public static int trapCount = 0;
	private static Text _Trap;
	public static int maxtraps = 5;
	public string currentscene;
		
	// Use this for initialization
	internal void Start ()
	{
		_Trap = GetComponent<Text>();
		UpdateTrap();
		if ((currentscene == "LevelOne"))
		{
			_Trap.enabled = false;
		}
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
