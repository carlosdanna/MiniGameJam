using UnityEngine;
using System.Collections;

public class Shark_Ninja_Throw : MonoBehaviour {



	public GameObject ninjaStarPrefab;
	public int starForce=0;
	//private float cooldownTimer = 1.0f;
	private float deltaTimer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.Space)) {

			ThrowNinjaStar();
		}

	
	}

	public void ThrowNinjaStar()
	{

		GameObject Clone;

		Clone = (Instantiate (ninjaStarPrefab, transform.position+new Vector3(-5,0,0), transform.rotation)) as GameObject;

//		Clone.rigidbody.AddForce (1000, 0, 0);
	//	Clone.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (starForce, 0));
	}

}
