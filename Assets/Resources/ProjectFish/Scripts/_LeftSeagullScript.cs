using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class _LeftSeagullScript : MonoBehaviour {

	public float magnitude = -5.0f;
	public float hSpeed = -0.1f;
	float initialHeight = 0.0f;
	public _SpawnerScript spawner;
	
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
		transform.position = new Vector3((transform.position.x + hSpeed), (-Mathf.Sin (transform.position.x / 6) * magnitude + initialHeight), transform.position.z);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Fish") {
			spawner.scoreNum += 1;
			spawner.score.text = "Score: " + spawner.scoreNum;
			Destroy (other.gameObject);
		}
	}
}
