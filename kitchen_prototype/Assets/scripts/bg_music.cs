using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_music : MonoBehaviour
{

	public AudioClip Music;
	public AudioSource MusicSource;
	
	// Use this for initialization
	void Start ()
	{
		MusicSource.clip = Music;
		MusicSource.Play();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//MusicSource.Play();
		//Debug.Log("Playing");
	}
}
