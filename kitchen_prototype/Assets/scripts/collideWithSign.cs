using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideWithSign : MonoBehaviour
{

	public GameObject bg;

	public GameObject sprite;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		bg.SetActive(false);
		sprite.SetActive(false);
	}

	private void OnTriggerStay2D(Collider2D coll)
	{
		bg.SetActive(false);
		sprite.SetActive(false);

	}

	private void OnTriggerExit2D(Collider2D coll)
	{
		bg.SetActive(true);
		sprite.SetActive(true);
	}
}
