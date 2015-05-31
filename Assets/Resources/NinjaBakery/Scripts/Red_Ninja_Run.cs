using UnityEngine;
using System.Collections;
public class Red_Ninja_Run : MonoBehaviour {
	// Use this for initialization
	public float Speed = 0f;
	public float Acceleration = 0f;
	public int stepcount = 0;
	public Rigidbody2D body;
	public GameObject slash_trigger;
	private bool is_winner =false;
	public GameObject w_key;
	public GameObject e_key;
	private bool is_playing=false;
	
	
	public void Initialize () {
		body =  GetComponent<Rigidbody2D> ();
		e_key.SetActive (false);
		is_playing = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (!is_winner) {
			if (!is_playing)
				return;
			if (Input.GetKeyDown (KeyCode.W) && stepcount % 2 == 0) {
				stepcount++;
				w_key.SetActive (false);
				e_key.SetActive (true);

			} else if (Input.GetKeyUp (KeyCode.E) && stepcount % 2 == 1) {
				stepcount++;
				w_key.SetActive (true);
				e_key.SetActive (false);

			}
		}
		
		
		Speed += Acceleration * Time.deltaTime ;
		
		
		
		body.velocity = new Vector2 (Speed, 0);
		
		if (transform.position.x > 10) {
			body.velocity = new Vector2 (0, 0);
			slash_trigger.SetActive(false);
			if(!is_winner)
				GetComponent<Animator>().SetBool("isDead",true);
		}
		
		
	}
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		slash_trigger.SetActive (true);
		slash_trigger.GetComponent<AudioSource> ().Play ();
		if (other.gameObject.GetComponent<Blue_Ninja_run> ().stepcount > stepcount) {
			is_winner = false;
		}
		else
				is_winner=true;

	}

	public void Reset()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public void DeathSound()
	{
		GetComponent<AudioSource> ().Play ();
	}
	
}