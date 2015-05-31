using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwordClash : MonoBehaviour {


	private GameObject swordclash;
	private GameObject red_ninja;
	// Use this for initialization
	void Start () {
		swordclash = GameObject.Find ("SwordClash");
		swordclash.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {


	}
}
