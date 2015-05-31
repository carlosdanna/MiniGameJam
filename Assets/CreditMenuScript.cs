using UnityEngine;
using System.Collections;

public class CreditMenuScript : MonoBehaviour {

	public GameObject main_menu;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.Escape)) {
			main_menu.SetActive(true);
			this.gameObject.SetActive(false);
		}
	}
}
