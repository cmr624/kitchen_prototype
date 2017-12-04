using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forCamera : MonoBehaviour 
{
    
    public Camera mainCamera;
	public string name;
	public int cost;
	public AudioClip kitchenSoundEffect;
	public AudioClip diningRoomSoundEffect;
	public AudioSource SoundEffectSource;

	//original location
	private Vector3 diningRoom = new Vector3(29.6f, 15.2f, -10f);
	private Vector3 e_diningRoom = new Vector3(50.21f, 15.2f, -10f);
	private Vector3 n_diningRoom = new Vector3(27.98f, 25f, -10f);
	private Vector3 s_diningRoom = new Vector3(28.67f, 5.34f, -10f);
	private Vector3 kitchen = new Vector3(11f, 15.2f, -10f);
	private Vector3 n_kitchen = new Vector3(11.52f, 24.8f, -10f);
	private Vector3 s_kitchen = new Vector3(11.52f, 5.13f, -10f);
	
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
			if (name.Equals("kitchen"))
			{
				SoundEffectSource.Stop();
				Debug.Log(name);
				SoundEffectSource.clip = kitchenSoundEffect;
				SoundEffectSource.Play();
				mainCamera.transform.position = kitchen;
			}
			else if (name.Equals("dining_room"))
			{
				SoundEffectSource.Stop();
				SoundEffectSource.clip = diningRoomSoundEffect;
				SoundEffectSource.Play();
				Debug.Log(name);
				mainCamera.transform.position = diningRoom;
			}
		}
	}
	private void OnTriggerExit(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			if (name.Equals("kitchen"))
			{
				SoundEffectSource.Stop();
				Debug.Log(name);
				SoundEffectSource.clip = diningRoomSoundEffect;
				SoundEffectSource.Play();
				mainCamera.transform.position = diningRoom;
			}
			else if (name.Equals("dining_room"))
			{
				SoundEffectSource.Stop();
				SoundEffectSource.clip = kitchenSoundEffect;
				SoundEffectSource.Play();
				Debug.Log(name);
				mainCamera.transform.position = kitchen;
			}
		}
	}
}
