using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forCamera : MonoBehaviour {
    
    public Camera mainCamera;

	private Vector3 diningRoom = new Vector3(29.6f, 15.2f, -10f);
	private Vector3 kitchen = new Vector3(11f, 15.2f, -10f);
	// Use this for initialization
	void Start () 
	{
		mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			mainCamera.transform.position = kitchen;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			mainCamera.transform.position = diningRoom;
		}
	}
}
