using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Red_Counter : MonoBehaviour {

	private GameObject red_ninja;
	private GameObject red_counter;
	private int red_step_count;

	void Start()
	{
		red_ninja = GameObject.Find("Red_Ninja");
		red_counter = GameObject.Find ("Red_Score");
		red_step_count = 0;


	}
	// Use this for initialization
	void FixedUpdate()
	{
		red_step_count = red_ninja.GetComponent<Shark_Ninja_Run_Red> ().stepcount;
		red_counter.GetComponent<Text> ().text = red_step_count.ToString ();
	}



}
