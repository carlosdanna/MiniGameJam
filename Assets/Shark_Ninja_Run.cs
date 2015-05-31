using UnityEngine;
using System.Collections;

public class Shark_Ninja_Run : MonoBehaviour {
	// Use this for initialization
	public float Speed = 0f;
	public float Acceleration = 0f;
	public int stepcount = 0;
	public Rigidbody2D body;

	
	void Start () {
		body =  GetComponent<Rigidbody2D> ();
	}
	

		
		// Update is called once per frame
		void Update () {
			
			
			if (Input.GetKey (KeyCode.K) && stepcount % 2 == 1)
				stepcount++;
			else if (Input.GetKey (KeyCode.L) && stepcount % 2 == 0)
				stepcount++;
			
			
			Speed += Acceleration * Time.deltaTime ;
			
			
			
			body.velocity = new Vector2 (Speed, 0);
			
			
		
		if (transform.position.x < -10)
			body.velocity = new Vector2 (0, 0);
		}
		
		


void OnTriggerEnter2D(Collider2D other)
{
	if (other.gameObject.GetComponent<Shark_Ninja_Run_Red>().stepcount < stepcount)
		Destroy (other.gameObject);
}

}
