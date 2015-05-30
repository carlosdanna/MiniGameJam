using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class _SeagullScript : MonoBehaviour {

	public float magnitude = 5.0f;
	public float hSpeed = 0.1f;
	float initialHeight = 0.0f;
	// Use this for initialization
	void Start () {
		initialHeight = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		Swoop ();
	}

	void Swoop()
	{
		transform.position = new Vector3((transform.position.x + hSpeed), (-Mathf.Sin (transform.position.x / 6) * magnitude + initialHeight), 0);
	}
}
