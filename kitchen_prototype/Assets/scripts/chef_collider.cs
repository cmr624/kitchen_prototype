using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chef_collider : MonoBehaviour
{
	private bool grab;
	public string text_string;
	public Text originalText;
	public GameObject text_box;
	public bool triggerSpace;
	
	public GameObject holding;
	public string item;
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
		if (Input.GetKeyDown("e"))
		{
			grab = true;
		}
		else
		{
			grab = false;
		}
		if (Input.GetKeyDown("space"))
		{
			triggerSpace = true;
		}
		else
		{
			triggerSpace = false;
		}
		if (Input.GetKeyDown("i"))
		{
			if (scripty.isHolding)
			{
				text_box.SetActive(true);
				originalText.text = "HOLDING " + scripty.item + " MONEY: $" + scripty.score;
				
			}
			else
			{
				text_box.SetActive(true);
				originalText.text = "Not holding anything." + " MONEY: $" + scripty.score;
			}
		}
		
	}
	private void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player" && triggerSpace)
		{
			Debug.Log("COLLIDING");
			text_box.SetActive(true);
			originalText.text = text_string;
		}
		if (coll.gameObject.tag == "Player" && grab)
		{
			if (scripty.isHolding)
			{
				text_box.SetActive(true);
				originalText.text = "ALREADY HOLDING " + scripty.item;
				
			}
			else
			{
				text_box.SetActive(true);
				originalText.text = "HOLDING " + item;
				scripty.isHolding = true;
				scripty.item = item;
			}
		}
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player" && triggerSpace)
		{
			Debug.Log("COLLIDING");
			text_box.SetActive(true);
			originalText.text = text_string;
		}
		if (coll.gameObject.tag == "Player" && grab)
		{
			if (scripty.isHolding)
			{
				text_box.SetActive(true);
				originalText.text = "ALREADY HOLDING " + scripty.item;
				
			}
			else
			{
				text_box.SetActive(true);
				originalText.text = "HOLDING " + item;
				scripty.isHolding = true;
				scripty.item = item;
			}
		}
	}

	private void OnCollisionExit2D(Collision2D coll)
	{
		if (!scripty.isHolding)
		{
			text_box.SetActive(false);
		}
	}
}
