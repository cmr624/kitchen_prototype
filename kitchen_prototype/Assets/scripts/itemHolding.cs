using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemHolding : MonoBehaviour
{
	public bool isHolding;
	public string item;
	public int score;
	// Use this for initialization
	void Start ()
	{
		isHolding = false;
		item = "Not holding anything";
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
