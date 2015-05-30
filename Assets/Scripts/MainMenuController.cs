using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadGame(string gameName)
    {
        Application.LoadLevel(gameName);
    }
}
