using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemHolding : MonoBehaviour
{
	public bool isHolding;
	public string item;
	public int score;

	public GameObject player;
	private Animator animator;
	private const int IDLE = 0;
	private const int WALK = 1;
	private const int HOLDING = 2;
	private int currentState = IDLE;

	public GameObject pizza;
	public GameObject corn;
	public GameObject burger;
	
	// Use this for initialization
	void Start ()
	{
		animator = player.GetComponent<Animator>();
		isHolding = false;
		item = "Not holding anything";
		score = 0;
		DisplayFood("OFF");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//DEVTOOL. COMMENT OUT IN FINAL BUILD. OR DON'T.
		if (Input.GetKeyDown("l"))
		{
			score += 100;
		}
		if (isHolding)
		{
			DisplayFood(item);
			changeState(HOLDING);
			Debug.Log(currentState);
		}
		else
		{
			DisplayFood("OFF");
			changeState(IDLE);
		}
	}
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

	void DisplayFood(string item)
	{
		if (item.Equals("Corn"))
		{
			corn.SetActive(true);
			burger.SetActive(false);
			pizza.SetActive(false);
		}
		else if (item.Equals("Burger"))
		{
			corn.SetActive(false);
			burger.SetActive(true);
			pizza.SetActive(false);
		}
		else if (item.Equals("Pizza"))
		{
			corn.SetActive(false);
			burger.SetActive(false);
			pizza.SetActive(true);
		}
		else if (item.Equals("OFF"))
		{
			corn.SetActive(false);
			burger.SetActive(false);
			pizza.SetActive(false);
		}
	}
}
