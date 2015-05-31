using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Blue_Counter : MonoBehaviour {
	
	private GameObject blue_ninja;
	private GameObject blue_counter;
	private int blue_step_count;
	
	void Start()
	{
		blue_ninja = GameObject.Find("Blue_Ninja");
		blue_counter = GameObject.Find ("Blue_Score");
		blue_step_count = 0;
		
		
	}
	// Use this for initialization
	void FixedUpdate()
	{
		blue_step_count = blue_ninja.GetComponent<Shark_Ninja_Run> ().stepcount;
		blue_counter.GetComponent<Text> ().text = blue_step_count.ToString ();
	}
	
	
	
}
