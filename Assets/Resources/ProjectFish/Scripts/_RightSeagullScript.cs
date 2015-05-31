using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class _RightSeagullScript : MonoBehaviour {

	public float magnitude = 5.0f;
	float hSpeed = 0.15f;
	public float originalZRot = 0.0f;
	float initialHeight = 0.0f;
	public _SpawnerScript spawner;
	public GameObject child;

	// Use this for initialization
	void Start () {
		initialHeight = transform.position.y;
		transform.Rotate (new Vector3(0.0f, 0.0f, 1.0f), -50.0f);
		originalZRot = transform.rotation.eulerAngles.z;
		Color color = child.GetComponent<SpriteRenderer> ().color;
		child.GetComponent<SpriteRenderer> ().color = new Color(color.r, color.g, color.b, spawner.reaperAlpha);
	}
	
	// Update is called once per frame
	void Update () {
		Swoop ();
	}

	void Swoop()
	{
		transform.position = new Vector3((transform.position.x + hSpeed), (-Mathf.Sin (transform.position.x / 6) * magnitude + initialHeight), transform.position.z);
		transform.Rotate (new Vector3(0.0f, 0.0f, 1.0f), 32.0f * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Fish") {
			spawner.scoreNum += 1;
			spawner.score.text = "Score: " + spawner.scoreNum;
			Destroy (other.gameObject);
			spawner.reaperAlpha += 0.2f;
			Color color = child.GetComponent<SpriteRenderer> ().color;
			child.GetComponent<SpriteRenderer> ().color = new Color(color.r, color.g, color.b, spawner.reaperAlpha);
		}
	}
}
