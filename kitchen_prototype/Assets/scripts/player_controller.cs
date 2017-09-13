using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
	public Rigidbody2D rigidbody;
	public float ForceStrength;
	public Collider collider;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Moving GameObjects:
		// You can use the Transform component always
		// if it's also a physics object you can use the Rigidbody/Rigidbody2D
		// If you move a physics object's transform, it will ignore physics interactions during the movement
		// Make sure you use the rigidbody to move an object if you want it to have physics interactions during the
		// movement. Make sure not to move it too quickly.

		// Input:
		// Use Input.GetKey() to get a physical key on your keyboard
		// Use Input.GetButton() or Input.GetAxix() to use your buttons/axes defined in the InputManager
		// Remember there's also Input.GetButtonDown() and Input.GetButtonUp()

		// move up
		if (Input.GetKey("w"))
		{
			Debug.Log("up");

//			transform.Translate(new Vector3(0, 1, 0));
//			transform.Translate(Vector2.up * 5);
			//rigidbody.AddForce(Vector2.up * ForceStrength, ForceMode.VelocityChange);
			rigidbody.velocity = new Vector2(0, 10);
		}
		else if (Input.GetKeyUp("w"))
		{
			rigidbody.velocity = new Vector2(0,0);
		}
		// move down
		if (Input.GetKey("s"))
		{
			Debug.Log("down");
//			transform.Translate(Vector2.down * 5);
//			MyRigidbody2D.MovePosition(Vector2.down * ForceStrength);
			//rigidbody.AddForce(Vector2.down * ForceStrength);
			rigidbody.velocity = new Vector2(0,-10);
		}
		else if (Input.GetKeyUp("s"))
		{
			rigidbody.velocity = new Vector2(0,0);
		}
		
		// move left
		if (Input.GetKey("a"))
		{
			Debug.Log("left");
			//rigidbody.AddForce(Vector2.left * ForceStrength);
			rigidbody.velocity = new Vector2(-10, 0);
		}
		else if (Input.GetKeyUp("a"))
		{
			rigidbody.velocity = new Vector2(0,0);
		}
		
		 //move right
		if (Input.GetKey("d"))
		{
			Debug.Log("right");
			//rigidbody.AddForce(Vector2.right * ForceStrength);
			rigidbody.velocity = new Vector2(10,0);
		}
		else if (Input.GetKeyUp("d"))
		{
			rigidbody.velocity = new Vector2(0,0);
		}
		//rigidbody.velocity = new Vector2(0, 0);
		//if ((Input.GetKeyUp("a")) || (Input.GetKeyUp("d")) || (Input.GetKeyUp("w")) || (Input.GetKeyUp("s")))
		//{
		//	Debug.Log("ZERO");
		//	rigidbody.velocity = new Vector2(0,0);
		//}
		if (!Input.anyKey)
		{
			rigidbody.velocity = new Vector2(0,0);
		}
	}
}
