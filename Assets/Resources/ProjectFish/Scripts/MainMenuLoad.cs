using UnityEngine;
using System.Collections;

public class MainMenuLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	public void LoadMainMenu()
	{
		Application.LoadLevel ("MainScene");
	}
}
