using UnityEngine;
using System.Collections;

public class _JGPlayerScript : MonoBehaviour {
	public string key;
	public float speed = 0.1f;
	public float dropSpeed = 0.02f;
	float velocity;
	// Use this for initialization
	void Start () {
		velocity = -dropSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		velocity = -dropSpeed;
		switch (key) {
		case "Q":
			if(Input.GetKeyDown(KeyCode.Q))
				velocity = speed;
			break;
		case "T":
			if(Input.GetKeyDown(KeyCode.T))
				velocity = speed;
			break;
		case "I":
			if(Input.GetKeyDown(KeyCode.I))
				velocity = speed;
			break;
		case "7":
			if(Input.GetKeyDown(KeyCode.Keypad7))
				velocity = speed;
			break;
		}

		transform.position = new Vector3 (transform.position.x, transform.position.y + velocity, transform.position.z);
	}
}
