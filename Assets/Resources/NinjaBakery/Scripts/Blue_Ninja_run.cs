using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Blue_Ninja_run : MonoBehaviour {
	public float Speed = 0f;
	public float Acceleration = 0f;
	public int stepcount = 0;
	public Rigidbody2D body;
	private bool is_winner=false;
	public GameObject sword_slash;
	public GameObject k_key;
	public GameObject l_key;
	private bool is_playing = false;

	
	public void Initialize () {
		body =  GetComponent<Rigidbody2D> ();
		l_key.SetActive (false);
		is_playing = true;
	}
	
	
	
	// Update is called once per frame
	void Update () {
		
		if (!is_playing)
			return;

	if (!is_winner) {
			if (Input.GetKeyDown (KeyCode.K) && stepcount % 2 == 0)
			{
				stepcount++;
				k_key.SetActive(true);
				l_key.SetActive (false);

			}
			else if (Input.GetKeyDown (KeyCode.L) && stepcount % 2 == 1)
			{
			
				stepcount++;
				k_key.SetActive(false);
				l_key.SetActive (true);
			}
		}
		
		Speed += Acceleration * Time.deltaTime ;
		
		
		
		body.velocity = new Vector2 (Speed, 0);
		
		
		
		if (transform.position.x < -10) {
			body.velocity = new Vector2 (0, 0);
			sword_slash.SetActive(false);
			if(!is_winner)
				GetComponent<Animator>().SetBool("isDead",true);
		}
	}
	
	
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.GetComponent<Red_Ninja_Run> ().stepcount > stepcount) {

			is_winner = false;
		} else
			is_winner = true;
	}

	public void Reset()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	
}