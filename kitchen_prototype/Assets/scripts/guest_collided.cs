using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class guest_collided : MonoBehaviour
{
	public GameObject text_box;
	public bool triggerSpace;
	public string text_string;
	public Text originalText;
	public bool grab;
	
	public GameObject holding;
	public string item;
	private itemHolding scriptyGuest;
	public string thankYouText;
	public string hateYouText;
	public int money;
	
	// Use this for initialization
	void Start ()
	{
		originalText = originalText.GetComponent<Text>();
		scriptyGuest = holding.GetComponent<itemHolding>();
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
		if (Input.GetKeyDown("e"))
		{
			grab = true;
		}
		else
		{
			grab = false;
		}
		if (Input.GetKeyDown("i"))
		{
			if (scriptyGuest.isHolding)
			{
				text_box.SetActive(true);
				originalText.text = "HOLDING " + scriptyGuest.item+ " MONEY: $" + scriptyGuest.score;
			}
			else
			{
				text_box.SetActive(true);
				originalText.text = "Not holding anything." + " MONEY: $" + scriptyGuest.score;
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
			if (scriptyGuest.isHolding)
			{
				if (item.Equals(scriptyGuest.item))
				{
					text_box.SetActive(true);
					originalText.text = thankYouText;
					scriptyGuest.isHolding = false;
					scriptyGuest.item = "";
					scriptyGuest.score += money;
				}
				else
				{
					text_box.SetActive(true);
					originalText.text = hateYouText;
				}
				
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
			if (scriptyGuest.isHolding)
			{
				if (item.Equals(scriptyGuest.item))
				{
					text_box.SetActive(true);
					originalText.text = thankYouText;
					scriptyGuest.isHolding = false;
					scriptyGuest.item = "";
					scriptyGuest.score += money;
				}
				else
				{
					text_box.SetActive(true);
					originalText.text = hateYouText;
				}
				
			}
		}
	}

	private void OnCollisionExit2D(Collision2D coll)
	{
		if (!scriptyGuest.isHolding)
		{
			text_box.SetActive(false);
		}
	}
}
