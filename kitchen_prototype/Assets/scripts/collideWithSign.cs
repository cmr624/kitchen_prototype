using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideWithSign : MonoBehaviour
{

	public GameObject bg;

	public GameObject sprite;

	public Boolean TurnOn;
	// Use this for initialization
	void Start ()
	{
		TurnOn = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (TurnOn)
		{
			bg.SetActive(true);
			sprite.SetActive(true);
			Debug.Log("truthiness");
		}
		if (!TurnOn)
		{
			bg.SetActive(false);
			sprite.SetActive(false);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		TurnOn = false;
	}

	private void OnTriggerStay2D(Collider2D coll)
	{
		TurnOn = false;
		
	}

	private void OnTriggerExit2D(Collider2D coll)
	{
		TurnOn = true;
	}
}
