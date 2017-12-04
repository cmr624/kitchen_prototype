using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	public GameObject holding;
	public GameObject alert;
	private bool isMoving;
	
	//audio
	public AudioClip Effect;
	public AudioSource EffectSource;

	private GameObject[] guests;
	
	// Use this for initialization
	void Start ()
	{
		scripty = holding.GetComponent<itemHolding>();
		animator = this.GetComponent<Animator>();
		EffectSource.clip = Effect;
		EffectSource.Play();
		alert.SetActive(false);
		isMoving = false;
		if (guests == null)
		{
			guests = GameObject.FindGameObjectsWithTag("guest");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		bool doIt = false;
		foreach (GameObject guest in guests)
		{
			Debug.Log(guests);
			if (guest.GetComponent<guest_collided>().done)
			{
				doIt = true;
			}
			else
			{
				doIt = false;
				break;
			}
		}
		if (doIt)
		{
			PlayerPrefs.SetInt("money", scripty.score);
			PlayerPrefs.SetInt("totalMoneyPossible", scripty.totalMoneyPossible);
			PlayerPrefs.SetInt("played", 1);
			SceneManager.LoadScene(0);
		}
		if (Input.GetKey("t"))
		{
			PlayerPrefs.SetInt("money", 60);
			PlayerPrefs.SetInt("totalMoneyPossible", 90);
			PlayerPrefs.SetInt("played", 1);
			SceneManager.LoadScene(0);
		}
		if (Input.GetKey("escape"))
		{
			SceneManager.LoadScene(0);
		}
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
		if (Input.GetKey("w") || Input.GetKey("up"))
		{
			isMoving = true;
			if (currentState != HOLDING)
			{
				changeState(WALK);
				Debug.Log(currentState);
			}
			//Debug.Log("up");
			if (Input.GetKey("d") || Input.GetKey("right"))
			{
				//Debug.Log("up/right");
				rigidbody.velocity = new Vector2(ForceStrength, ForceStrength);
			}
			else if (Input.GetKey("a")|| Input.GetKey("left"))
			{
				//Debug.Log("up/left");
				rigidbody.velocity = new Vector2(-ForceStrength, ForceStrength);
			}
			else
			{
				rigidbody.velocity = new Vector2(0, ForceStrength);
			}

		}
		else if (Input.GetKeyUp("w") || Input.GetKeyUp("up"))
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
		else if (Input.GetKey("s") || Input.GetKey("down"))
		{
			isMoving = true;
			if (currentState != HOLDING)
			{
				changeState(WALK);
				Debug.Log(currentState);
			}
			//Debug.Log("down");
			if (Input.GetKey("d") || Input.GetKey("right"))
			{
				//Debug.Log("down right");
				rigidbody.velocity = new Vector2(ForceStrength, -ForceStrength);
			}
			else if (Input.GetKey("a") || Input.GetKey("left"))
			{
				//Debug.Log("down/left");
				rigidbody.velocity = new Vector2(-ForceStrength, -ForceStrength);
			}
			else
			{
				rigidbody.velocity = new Vector2(0, -ForceStrength);
			}
		}
		else if (Input.GetKeyUp("s") || Input.GetKeyUp("down"))
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
		else if (Input.GetKey("a") || Input.GetKey("left"))
		{
			isMoving = true;
			if (currentState != HOLDING)
			{
				changeState(WALK);
			}
			//Debug.Log("left");
			rigidbody.velocity = new Vector2(-ForceStrength, 0);
			
		}
		else if (Input.GetKeyUp("a") || Input.GetKey("left"))
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
		else if (Input.GetKey("d") || Input.GetKey("down"))
		{
			isMoving = true;
			if (currentState != HOLDING)
			{
				changeState(WALK);
			}
			Debug.Log(currentState);
			rigidbody.velocity = new Vector2(ForceStrength,0);
		}
		else if (Input.GetKeyUp("d") || Input.GetKeyUp("right"))
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
