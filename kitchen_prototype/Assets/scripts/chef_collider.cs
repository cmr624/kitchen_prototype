using System;
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
	public GameObject alert;
	
	public AudioClip talk;
	public AudioClip alertSound;
	public AudioSource interactionAudioSource;
	private Boolean triggered;
	
	// Use this for initialization
	void Start ()
	{
		originalText = originalText.GetComponent<Text>();
		scripty = holding.GetComponent<itemHolding>();
		//alert.SetActive(fa);
	}
	
	// Update is called once per frame
	void Update () 
	{
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

	private void OnTriggerStay2D(Collider2D coll)
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
		alert.SetActive(true);
		if (coll.gameObject.tag == "Player" && triggerSpace)
		{
			interactionAudioSource.Stop();
			interactionAudioSource.clip = talk;
			interactionAudioSource.Play();
			Debug.Log("COLLIDING");
			text_box.SetActive(true);
			originalText.text = text_string;
		}
		if (coll.gameObject.tag == "Player" && grab)
		{
			if (scripty.isHolding)
			{
				interactionAudioSource.Stop();
				interactionAudioSource.clip = talk;
				interactionAudioSource.Play();
				text_box.SetActive(true);
				originalText.text = "Already Holding " + scripty.item;

			}
			else
			{
				interactionAudioSource.Stop();
				interactionAudioSource.clip = talk;
				interactionAudioSource.Play();
				text_box.SetActive(true);
				originalText.text = "Holding " + item;
				scripty.isHolding = true;
				scripty.item = item;
			}
		}
	}

	
	void OnTriggerEnter2D(Collider2D coll)
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
		alert.SetActive(true);
		interactionAudioSource.Stop();
		interactionAudioSource.clip = alertSound;
		interactionAudioSource.Play();
		if (coll.gameObject.tag == "Player" && triggerSpace)
		{
			interactionAudioSource.Stop();
			interactionAudioSource.clip = talk;
			interactionAudioSource.Play();
			Debug.Log("COLLIDING");
			text_box.SetActive(true);
			originalText.text = text_string;
			
		}
		if (coll.gameObject.tag == "Player" && grab)
		{
			if (scripty.isHolding)
			{
				interactionAudioSource.Stop();
				interactionAudioSource.clip = talk;
				interactionAudioSource.Play();
				text_box.SetActive(true);
				originalText.text = "Already Holding " + scripty.item;
				
			}
			else
			{
				interactionAudioSource.Stop();
				interactionAudioSource.clip = talk;
				interactionAudioSource.Play();
				text_box.SetActive(true);
				originalText.text = "Holding " + item;
				scripty.isHolding = true;
				scripty.item = item;
			}
		}
	}

	private void OnTriggerExit2D(Collider2D coll)
	{
		triggered = false;
		alert.SetActive(false);
		if (!scripty.isHolding)
		{
			text_box.SetActive(false);
		}
	}
}
