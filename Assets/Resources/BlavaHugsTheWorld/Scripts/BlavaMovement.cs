using UnityEngine;
using System.Collections;


public class BlavaMovement : MonoBehaviour {
	
	// Use this for initialization
	private int left = -1;
	private int right = 1;
	public float Speed=0f;
	public float fallSpeed=0f;
	public float maxSpeed = 0f;
	public float minSpeed = 0f;
	public float Acceleration = 0f;
	private float Direction=0f;
	private float lastDirection =0f;
	private Vector2 Velocity;
	public Rigidbody2D body;
	
	void Start () {
		body =  GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow))
			Direction = -1;
		else if (Input.GetKey (KeyCode.RightArrow))
			Direction = 1;
		else
			Direction = 0;

		
		if (Direction == lastDirection && Direction == right && Speed < maxSpeed)
			Speed += Acceleration;
		else if (Direction == lastDirection && Direction == left && Speed > minSpeed)
			Speed -= Acceleration;
		
		if (Speed < minSpeed)
			Speed = minSpeed;
		if (Speed > maxSpeed)
			Speed = maxSpeed;
		
		
		
		lastDirection = Direction;
		body.velocity = new Vector2 (Speed, fallSpeed);
	}
	
	void FixedUpdate () {
		
		//	body.velocity = new Vector2 (Direction * Speed, fallSpeed);
	}
}
