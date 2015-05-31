using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GraveController : MonoBehaviour {

    public GameObject HuntedthingPrefab;
	public GameObject Hunted;
	public bool isActive = true;
	public float timer = 0.0f;
    
	// Use this for initialization
	void Start () {
	   
	}
	
	// Update is called once per frame
    void Update()
    {
		CheckAndSet ();
    }

	void OnMouseDown()
	{

		if (isActive) {
						GameObject hunted = Instantiate<GameObject> (HuntedthingPrefab) as GameObject;
						hunted.transform.position = Hunted.transform.position;
						if (gameObject.name == "Grave1") {
							hunted.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (300, 600), ForceMode2D.Force);
							Hunted.SetActive (false);
							isActive = false;
							timer = 6.0f;
						}
						if (gameObject.name == "Grave2") {
							hunted.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 600), ForceMode2D.Force);
							Hunted.SetActive (false);
							isActive = false;
							timer = 6.0f;
						}
						if (gameObject.name == "Grave3") {
							hunted.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-300, 600), ForceMode2D.Force);
							Hunted.SetActive (false);
							isActive = false;
							timer = 6.0f;
						}
					}
				
		}

	void CheckAndSet()
	{
		if (isActive)
			return;

		timer -= Time.deltaTime;
		if (timer < 0.0f) {
			isActive = true;
			Hunted.SetActive(true);
		}
	}
}
