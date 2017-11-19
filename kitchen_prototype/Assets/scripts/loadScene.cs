using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour {

	public void LoadTheScene(int index)
	{
		SceneManager.LoadScene(index);
	}
}
