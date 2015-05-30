using UnityEngine;
using System.Collections;

public class GraveController : MonoBehaviour {

    public GameObject HuntedthingPrefab;
    
	// Use this for initialization
	void Start () {
	   
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Vector2.zero);
            if (hitInfo)
            {
                Debug.Log(hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.name == gameObject.name)
                {
                    GameObject hunted = Instantiate<GameObject>(HuntedthingPrefab) as GameObject;
                    hunted.transform.position = gameObject.transform.position;
                    if (gameObject.name == "Grave1")
                    {
                        hunted.GetComponent<Rigidbody2D>().AddForce(new Vector2(300, 600), ForceMode2D.Force);
                    }
                    if (gameObject.name == "Grave2")
                    {
                        hunted.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-50.0f,50.0f), 600), ForceMode2D.Force);
                    }
                    if (gameObject.name == "Grave3")
                    {
                        hunted.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300, 600), ForceMode2D.Force);
                    }
                }
            }

        }
    }
}
