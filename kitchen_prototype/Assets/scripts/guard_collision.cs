using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;

public class guard_collision : MonoBehaviour
{
	public int cost;
	public Collider2D colliderToChange;
	private bool triggerSpace;
	public GameObject text_box;
	public Text originalText;
	public GameObject holding;
	private itemHolding scripty;
	
	// Use this for initialization
	void Start () 
	{
		originalText = originalText.GetComponent<Text>();
		scripty = holding.GetComponent<itemHolding>();
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
			if (scripty.score >= cost)
			{
				text_box.SetActive(true);
				originalText.text = "UNLOCKED! Proceed.";
				colliderToChange.isTrigger = true;
				scripty.score = scripty.score - cost;
			}
			else
			{
				text_box.SetActive(true);
				originalText.text = "Not enough money to unlock. Requre: $" + cost;
			}
		}
	}
}

//transform.Collider2D.isTrigger = false;