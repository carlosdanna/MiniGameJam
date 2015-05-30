using UnityEngine;
using System.Collections;

public class Shark_RockBehavior : MonoBehaviour 
{
    float myRadius;

	// Use this for initialization
	void Start () 
    {
        myRadius = GetComponent<CircleCollider2D>().radius;
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<BlavaMovement>().Die();
        }
    }
}
