using UnityEngine;
using System.Collections;

public class Shark_Ninja_Star : MonoBehaviour {

	public float Speed = -.4f;
	public float LifeTimer = 1.0f;
	private float LifeBegin = 0.0f;
	// Use this for initialization
	void Start () {
		LifeBegin = Time.time;
	//8	this.gameObject.transform.position = GetComponent<GameObject>("
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		gameObject.transform.position += Speed * gameObject.transform.position;

		if (Time.time - LifeBegin >= LifeTimer) {
			Destroy(this.gameObject);
		}
	}

}
