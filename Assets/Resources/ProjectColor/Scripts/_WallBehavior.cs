using UnityEngine;
using System.Collections;

public class _WallBehavior : MonoBehaviour {
    // === Variables
    float m_fRotateSpeed = 30;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, 1), m_fRotateSpeed * Time.deltaTime);
	}
}
