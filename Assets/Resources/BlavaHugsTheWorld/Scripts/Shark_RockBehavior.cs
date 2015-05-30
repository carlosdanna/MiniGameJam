using UnityEngine;
using System.Collections;

public class Shark_RockBehavior : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {

	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<BlavaMovement>().Die();
        }
    }
}
