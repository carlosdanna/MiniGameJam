using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KillDepth : MonoBehaviour {
	public GameObject game;
	public Canvas GameOver;
	public Text score;
	public GameObject spawner;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Fish") {
			//Destroy (other.gameObject);
			//if(spawner.GetComponent<_SpawnerScript>().currentSeagull != null)
			//{
			//	Destroy(spawner.GetComponent<_SpawnerScript>().currentSeagull);
			//	spawner.GetComponent<_SpawnerScript>().currentSeagull = null;
			//	spawner.GetComponent<_SpawnerScript>().betweenTimer = 0.0f;
			//	spawner.GetComponent<_SpawnerScript>().seagullInFlight = false;
			//	spawner.GetComponent<_SpawnerScript>().scoreNum = 0;
			//}
			//menu.SetActive(true);
			//game.SetActive(false);
			GameOver.gameObject.SetActive(true);
			game.SetActive(false);
			score.text = "Score: " + spawner.GetComponent<_SpawnerScript>().scoreNum;

		}
	}
}
