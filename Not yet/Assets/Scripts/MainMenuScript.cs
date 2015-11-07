using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public void Play()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void Exit()
	{
		Application.Quit();
	}
}
