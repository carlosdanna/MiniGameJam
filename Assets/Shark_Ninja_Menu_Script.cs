using UnityEngine;
using System.Collections;

public class Shark_Ninja_Menu_Script : MonoBehaviour {

	public GameObject red_ninja;
	public GameObject blue_ninja;
	public GameObject credits_panel;
	// Use this for initialization
	void Start () {
		credits_panel.SetActive (false);

	}
	
	public void StartGame()
	{
		GameObject.Find ("Main Camera").GetComponent<Ninja_BGM_Toggle> ().PlayLevel ();
		GameObject.Find ("MainMenuPanel").SetActive (false);	
		blue_ninja.GetComponent<Blue_Ninja_run> ().Initialize ();
		red_ninja.GetComponent<Red_Ninja_Run> ().Initialize ();
	}

	public void QuitGame()
	{
		Application.LoadLevel ("MainScene");
		GameObject.Find ("Main Camera").GetComponent<Ninja_BGM_Toggle> ().PlayMenu ();
		
	}

	public void Credits()
	{
		credits_panel.SetActive (true);
		GameObject.Find ("MainMenuPanel").SetActive (false);
	}



}
