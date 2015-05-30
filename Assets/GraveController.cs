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
                
                GameObject hunted = Instantiate<GameObject>(HuntedthingPrefab) as GameObject;
                hunted.GetComponent<Rigidbody2D>().AddForce(new Vector2(300, 900), ForceMode2D.Force);
                // Here you can check hitInfo to see which collider has been hit, and act appropriately.
            }

        }
    }
}
