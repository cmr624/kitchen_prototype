﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
	public Rigidbody2D rigidbody;
	public float ForceStrength;
	public float sprint;
	private float default_strength = 5;
	public Collider collider;
	public Animator animator;
	private const int IDLE = 0;
	private const int WALK = 1;
	private const int HOLDING = 2;
	private int currentState = IDLE;
	private itemHolding scripty;
	public GameObject alert;
	private bool isMoving;
	
	//audio
	public AudioClip Effect;
	public AudioSource EffectSource;
	
	// Use this for initialization
	void Start ()
	{
		animator = this.GetComponent<Animator>();
		EffectSource.clip = Effect;
		EffectSource.Play();
		alert.SetActive(false);
		isMoving = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isMoving)
		{
			EffectSource.UnPause();
		}
		else if (!isMoving)
		{
			EffectSource.Pause();
		}
		if (Input.GetKey("left shift"))
		{
			ForceStrength = sprint;
		}
		else
		{
			ForceStrength = default_strength;
		}

		// move up
		if (Input.GetKey("w"))
		{
			isMoving = true;
			if (currentState != HOLDING)
			{
				changeState(WALK);
				Debug.Log(currentState);
			}
			//Debug.Log("up");
			if (Input.GetKey("d"))
			{
				//Debug.Log("up/right");
				rigidbody.velocity = new Vector2(ForceStrength, ForceStrength);
			}
			else if (Input.GetKey("a"))
			{
				//Debug.Log("up/left");
				rigidbody.velocity = new Vector2(-ForceStrength, ForceStrength);
			}
			else
			{
				rigidbody.velocity = new Vector2(0, ForceStrength);
			}

		}
		else if (Input.GetKeyUp("w"))
		{
			isMoving = false;
			//EffectSource.Stop();
			if (currentState != HOLDING)
			{
				changeState(IDLE);
			}
			Debug.Log(currentState);
			rigidbody.velocity = new Vector2(0,0);
		}
		
		// move down
		else if (Input.GetKey("s"))
		{
			isMoving = true;
			if (currentState != HOLDING)
			{
				changeState(WALK);
				Debug.Log(currentState);
			}
			//Debug.Log("down");
			if (Input.GetKey("d"))
			{
				//Debug.Log("down right");
				rigidbody.velocity = new Vector2(ForceStrength, -ForceStrength);
			}
			else if (Input.GetKey("a"))
			{
				//Debug.Log("down/left");
				rigidbody.velocity = new Vector2(-ForceStrength, -ForceStrength);
			}
			else
			{
				rigidbody.velocity = new Vector2(0, -ForceStrength);
			}
		}
		else if (Input.GetKeyUp("s"))
		{
			isMoving = false;
			//EffectSource.Stop();
			if (currentState != HOLDING)
			{
				changeState(IDLE);
			}
			Debug.Log(currentState);
			rigidbody.velocity = new Vector2(0,0);
		}
		
		// move left
		else if (Input.GetKey("a"))
		{
			isMoving = true;
			if (currentState != HOLDING)
			{
				changeState(WALK);
			}
			//Debug.Log("left");
			rigidbody.velocity = new Vector2(-ForceStrength, 0);
			
		}
		else if (Input.GetKeyUp("a"))
		{
			//EffectSource.Stop();
			if (currentState != HOLDING)
			{
				changeState(IDLE);
			}
			Debug.Log(currentState);
			rigidbody.velocity = new Vector2(0,0);
		}
		/*
		//FOR DEMO PURPOSES
		else if (Input.GetKey("p"))
		{
			changeState(HOLDING);
		}
		else if (Input.GetKeyUp("p"))
		{
			changeState(IDLE);
		}*/
		 //move right
		else if (Input.GetKey("d"))
		{
			isMoving = true;
			if (currentState != HOLDING)
			{
				changeState(WALK);
			}
			Debug.Log(currentState);
			rigidbody.velocity = new Vector2(ForceStrength,0);
		}
		else if (Input.GetKeyUp("d"))
		{
			isMoving = false;
			//EffectSource.Stop();
			if (currentState != HOLDING)
			{
				changeState(IDLE);
			}
			Debug.Log(currentState);
			//Debug.Log("up");
			rigidbody.velocity = new Vector2(0,0);
		}
		
		if (!Input.anyKey)
		{
			isMoving = false;
			//EffectSource.Stop();
			if (currentState != HOLDING)
			{
				changeState(IDLE);
			}
			Debug.Log(currentState);
			rigidbody.velocity = new Vector2(0,0);
		}
	}
	
	//adapted from: 
	//http://johnstejskal.com/wp/creating-2d-animation-states-in-unity3d-pt3/
	void changeState(int state)
	{
		if (currentState == state)
		{
			return;
		}
		else if (state == IDLE)
		{
			animator.SetInteger("state", IDLE);
		}
		else if (state == WALK)
		{
			animator.SetInteger("state", WALK);
		}
		else if (state == HOLDING)
		{
			animator.SetInteger("state", HOLDING);
		}
		currentState = state;
	}
}
