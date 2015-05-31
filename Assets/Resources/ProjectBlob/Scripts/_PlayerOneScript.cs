using UnityEngine;
using System.Collections;

public class _PlayerOneScript : MonoBehaviour {
    // === Action Keys
    KeyCode LEFT = KeyCode.A;
    KeyCode UP = KeyCode.W;
    KeyCode RIGHT = KeyCode.D;
    KeyCode DOWN = KeyCode.S;
    KeyCode SHOOT = KeyCode.Space;

    // === Variables
    public GameObject blobPrefab;
    float m_fSpeed = 3;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        HandleMovement(Time.deltaTime);
	}

    // Handle Movement
    void HandleMovement(float _delta)
    {
        // === Movement
        Vector3 position = GetComponent<Transform>().position;
        // == Handling Horizontal
        if (Input.GetKey(LEFT))
        {
            position.x -= m_fSpeed * _delta;
        }
        else if (Input.GetKey(RIGHT))
        {
            position.x += m_fSpeed * _delta;
        }
        // == Handling Vertical
        if (Input.GetKey(UP))
        {
            position.y += m_fSpeed * _delta;
        }
        else if (Input.GetKey(DOWN))
        {
            position.y -= m_fSpeed * _delta;
        }
        GetComponent<Transform>().position = position;
        StayInBounds();
        // ===
        // === Shooting
        if (Input.GetKeyDown(SHOOT))
        {
            // Creating the Blob
            GameObject blob = Instantiate<GameObject>(blobPrefab) as GameObject;
            // Setting it's color
            blob.GetComponent<_BlobScript>().color = Color.red;
            // Setting it's initial position
            Rect rect = blob.GetComponent<SpriteRenderer>().sprite.rect;
            position.x -= rect.width / 200; position.y += rect.height / 200;
            position.z = 5;
            blob.transform.position = position;
            blob.GetComponent<_BlobScript>().CenterPosition = position;
            // Playing the Audio
            Camera.main.GetComponent<_SoundManagerScript>().PlayAudio(_SoundManagerScript.SoundID.bShoot);
        }
    }

    // Stay In Bounds
    void StayInBounds()
    {
        // === Checking Bounds
        Vector3 world = Camera.main.ViewportToWorldPoint(Camera.main.transform.position);
        Vector3 position = GetComponent<Transform>().position;
        // == Left / Right Bounds 
        if (position.x < world.x)
            position.x = world.x;
        else if (position.x > -world.x)
            position.x = -world.x;
        // == Upper / Lower Bounds
        if (position.y > -world.y)
            position.y = -world.y;
        else if (position.y < world.y)
            position.y = world.y;
        GetComponent<Transform>().position = position;
    }
}
