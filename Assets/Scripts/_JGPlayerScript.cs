using UnityEngine;
using System.Collections;

public class _JGPlayerScript : MonoBehaviour {
	public GameObject arrowManager;
	new public string name;
	public string key;
	public float speed = 0.1f;
	public float dropSpeed = 0.02f;
	bool isAlive = true;
	float velocity;
	public AudioSource arrowHit;
	public AudioSource death;
	// Use this for initialization
	void Start () {
		velocity = -dropSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		velocity = -dropSpeed;
		if (isAlive) 
		{
			if (transform.position.y < 4.3f) 
			{
				switch (key) 
				{
				case "Q":
					if (Input.GetKeyDown (KeyCode.Q))
						velocity = speed;
					break;
				case "T":
					if (Input.GetKeyDown (KeyCode.T))
						velocity = speed;
					break;
				case "I":
					if (Input.GetKeyDown (KeyCode.I))
						velocity = speed;
					break;
				case "7":
					if (Input.GetKeyDown (KeyCode.Keypad7))
						velocity = speed;
					break;
				}
			}
		}

		if (transform.position.y < -3.55F || !isAlive)

			velocity = -dropSpeed * 5.0f;

		transform.position = new Vector3 (transform.position.x, transform.position.y + velocity, transform.position.z);
		if (transform.position.y < -5.0f && isAlive) {
			death.Play();
		}

		if (transform.position.y < -5.0f) {
			isAlive = false;
			arrowManager.GetComponent<ArrowManager>().RemovePlayer(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Arrow") {
			isAlive = false;
			Destroy(col.gameObject);
			arrowHit.Play();
			death.Play();
		}
	}
}
