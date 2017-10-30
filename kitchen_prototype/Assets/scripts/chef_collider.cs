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
				originalText.text = "ALREADY HOLDING " + scripty.item;
				
			}
			else
			{
				interactionAudioSource.Stop();
				interactionAudioSource.clip = talk;
				interactionAudioSource.Play();
				text_box.SetActive(true);
				originalText.text = "HOLDING " + item;
				scripty.isHolding = true;
				scripty.item = item;
			}
		}
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
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
				originalText.text = "ALREADY HOLDING " + scripty.item;
				
			}
			else
			{
				interactionAudioSource.Stop();
				interactionAudioSource.clip = talk;
				interactionAudioSource.Play();
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
			alert.SetActive(false);
		}
	}
}
