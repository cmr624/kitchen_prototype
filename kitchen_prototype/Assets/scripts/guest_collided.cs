using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guest_collided : MonoBehaviour
{
	public GameObject text_box;
	public bool triggerSpace;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("space"))
		{
			triggerSpace = true;
		}
		else
		{
			triggerSpace = false;
		}
	}

	private void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player" && triggerSpace)
		{
			Debug.Log("COLLIDING");
			text_box.SetActive(true);
		}
	}

	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player" && triggerSpace)
		{
			Debug.Log("COLLIDING");
			text_box.SetActive(true);
		}
	}

	private void OnCollisionExit2D(Collision2D coll)
	{
		text_box.SetActive(false);
	}
}
