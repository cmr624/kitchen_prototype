﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class guest_collided : MonoBehaviour
{
	public GameObject text_box;
	public bool triggerSpace;
	public string text_string_0;
	public string text_string_1;
	public string text_string_2;
	public string text_string_3;
	public Text originalText;
	public bool grab;
	
	public GameObject holding;
	public string item;
	private itemHolding scriptyGuest;
	public string thankYouText;
	public string hateYouText;
	public int money;
	public int reduceBy;

	public GameObject alert;
	private int count;

	public AudioClip fail;
	public AudioClip success;
	public AudioClip talk;
	public AudioClip alertSound;
	public AudioSource interactionAudioSource;
	
	
	
	/*
	fail
	success
	talk to patron
	alert
	*/
	
	// Use this for initialization
	void Start ()
	{
		originalText = originalText.GetComponent<Text>();
		scriptyGuest = holding.GetComponent<itemHolding>();
		count = 0;
		//alert.SetActive(false);
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
		alert.SetActive(true);
		if (coll.gameObject.tag == "Player" && triggerSpace)
		{
			Debug.Log("COLLIDING");
			text_box.SetActive(true);
			if (count == 0)
			{
				interactionAudioSource.Stop();
				interactionAudioSource.clip = talk;
				interactionAudioSource.Play();
				originalText.text = text_string_0;
				count += 1;
			}
			else if (count == 1)
			{
				interactionAudioSource.Stop();
				interactionAudioSource.clip = talk;
				interactionAudioSource.Play();
				originalText.text = text_string_1;
				count += 1;
				money = money - reduceBy;
			}
			else if (count == 2)
			{
				interactionAudioSource.Stop();
				interactionAudioSource.clip = talk;
				interactionAudioSource.Play();
				originalText.text = text_string_2;
				count += 1;
				money = money - reduceBy;
			}
			else if (count > 2)
			{
				interactionAudioSource.Stop();
				interactionAudioSource.clip = talk;
				interactionAudioSource.Play();
				originalText.text = text_string_3;
				count += 1;
				money = money - reduceBy;
			}
		}
		if (coll.gameObject.tag == "Player" && grab)
		{
			if (scriptyGuest.isHolding)
			{
				if (item.Equals(scriptyGuest.item))
				{
					interactionAudioSource.Stop();
					interactionAudioSource.clip = success;
					interactionAudioSource.Play();
					text_box.SetActive(true);
					originalText.text = thankYouText + " Earned: $" + money;;
					scriptyGuest.isHolding = false;
					scriptyGuest.item = "";
					scriptyGuest.score += money;
				}
				else
				{
					interactionAudioSource.Stop();
					interactionAudioSource.clip = fail;
					interactionAudioSource.Play();
					text_box.SetActive(true);
					originalText.text = hateYouText;
					money = money - reduceBy;
				}
				
			}
		}
	}

	//on collision enter, change it so that the color of the player indicates you can interact with them. 
	//Then, ON STAY, do all the regular shit... test if they're holding, etc etc.
	void OnCollisionEnter2D(Collision2D coll)
	{
		alert.SetActive(true);
		interactionAudioSource.Stop();
		interactionAudioSource.clip = alertSound;
		interactionAudioSource.Play();
		if (coll.gameObject.tag == "Player" && triggerSpace)
		{
			Debug.Log("COLLIDING");
			text_box.SetActive(true);
			if (count == 0)
			{
				interactionAudioSource.Stop();
				interactionAudioSource.clip = talk;
				interactionAudioSource.Play();
				originalText.text = text_string_0;
				count += 1;
			}
			else if (count == 1)
			{
				interactionAudioSource.Stop();
				interactionAudioSource.clip = talk;
				interactionAudioSource.Play();
				originalText.text = text_string_1;
				count += 1;
				money = money - reduceBy;
			}
			else if (count == 2)
			{
				interactionAudioSource.Stop();
				interactionAudioSource.clip = talk;
				interactionAudioSource.Play();
				originalText.text = text_string_2;
				count += 1;
				money = money - reduceBy;
			}
			else if (count > 2)
			{
				interactionAudioSource.Stop();
				interactionAudioSource.clip = talk;
				interactionAudioSource.Play();
				originalText.text = text_string_3;
				count += 1;
				money = money - reduceBy;
			}
		}
		if (coll.gameObject.tag == "Player" && grab)
		{
			if (scriptyGuest.isHolding)
			{
				if (item.Equals(scriptyGuest.item))
				{
					interactionAudioSource.Stop();
					interactionAudioSource.clip = success;
					interactionAudioSource.Play();
					text_box.SetActive(true);
					originalText.text = thankYouText + " Earned: $" + money;
					scriptyGuest.isHolding = false;
					scriptyGuest.item = "";
					scriptyGuest.score += money;
				}
				else
				{
					interactionAudioSource.Stop();
					interactionAudioSource.clip = fail;
					interactionAudioSource.Play();
					text_box.SetActive(true);
					originalText.text = hateYouText;
					money = money - reduceBy;
				}
				
			}
		}
	}

	private void OnCollisionExit2D(Collision2D coll)
	{
		if (!scriptyGuest.isHolding)
		{
			text_box.SetActive(false);
			alert.SetActive(false);
		}
	}
}
