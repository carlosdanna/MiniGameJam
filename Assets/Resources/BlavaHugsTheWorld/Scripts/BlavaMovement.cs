using UnityEngine;
using System.Collections;


public class BlavaMovement : MonoBehaviour {
	
	// Use this for initialization
	private int left = -1;
	private int right = 1;
	public float Speed = 0f;
	public float fallSpeed = 0f;
	public float maxSpeed = 0f;
	public float minSpeed = 0f;
	public float Acceleration = 0f;
	private float Direction = 0f;
	private float lastDirection = 0f;
    //private Vector2 Velocity;
	public Rigidbody2D body;

    private bool m_bGoTime = false;
	
	void Start () 
    {
		body =  GetComponent<Rigidbody2D> ();
        GetComponent<TrailRenderer>().sortingOrder = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (!m_bGoTime)
            return;

        if ( Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale > 0)
                GameObject.Find("Canvas").GetComponent<Shark_Menu>().Pause();
            else
                GameObject.Find("Canvas").GetComponent<Shark_Menu>().Resume();
        }

		if (Input.GetAxis("Horizontal") < 0)
			Direction = -1;
		else if (Input.GetAxis("Horizontal") > 0)
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

    public void GoTime(bool isGoTime)
    {
        m_bGoTime = isGoTime;
    }

    public void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void KillRigid()
    {
        Destroy(body);
    }
}
