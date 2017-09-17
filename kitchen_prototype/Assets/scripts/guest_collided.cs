using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guest_collided : MonoBehaviour
{

	private Collision2D collide;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log("collided");
	}
}
