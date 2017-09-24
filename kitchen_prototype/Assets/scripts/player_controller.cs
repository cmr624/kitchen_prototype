using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
	public Rigidbody2D rigidbody;
	public float ForceStrength;
	public float sprint;
	private float default_strength = 5;
	public Collider collider;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
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
			Debug.Log("up");
			if (Input.GetKey("d"))
			{
				Debug.Log("up/right");
				rigidbody.velocity = new Vector2(ForceStrength, ForceStrength);
			}
			else if (Input.GetKey("a"))
			{
				Debug.Log("up/left");
				rigidbody.velocity = new Vector2(-ForceStrength, ForceStrength);
			}
			else
			{
				rigidbody.velocity = new Vector2(0, ForceStrength);
			}

		}
		else if (Input.GetKeyUp("w"))
		{
			rigidbody.velocity = new Vector2(0,0);
		}
		
		// move down
		else if (Input.GetKey("s"))
		{
			Debug.Log("down");
			if (Input.GetKey("d"))
			{
				Debug.Log("down right");
				rigidbody.velocity = new Vector2(ForceStrength, -ForceStrength);
			}
			else if (Input.GetKey("a"))
			{
				Debug.Log("down/left");
				rigidbody.velocity = new Vector2(-ForceStrength, -ForceStrength);
			}
			else
			{
				rigidbody.velocity = new Vector2(0, -ForceStrength);
			}
		}
		else if (Input.GetKeyUp("s"))
		{
			rigidbody.velocity = new Vector2(0,0);
		}
		
		// move left
		else if (Input.GetKey("a"))
		{
			Debug.Log("left");
			rigidbody.velocity = new Vector2(-ForceStrength, 0);
			
		}
		else if (Input.GetKeyUp("a"))
		{
			rigidbody.velocity = new Vector2(0,0);
		}
		
		 //move right
		else if (Input.GetKey("d"))
		{
			Debug.Log("right");
			rigidbody.velocity = new Vector2(ForceStrength,0);
		}
		else if (Input.GetKeyUp("d"))
		{
			Debug.Log("up");
			rigidbody.velocity = new Vector2(0,0);
		}
		
		if (!Input.anyKey)
		{
			rigidbody.velocity = new Vector2(0,0);
		}
	}
}
