using UnityEngine;
using System.Collections;

public class _BlobScript : MonoBehaviour {
    // === Variables
    float m_fSpeed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 scale = transform.localScale;
        scale.x -= 0.5f * Time.deltaTime;
        scale.y -= 0.5f * Time.deltaTime;
        transform.localScale = scale;
        if (scale.x <= .25)
            Splatter();
	}

    // Splatter Function
    void Splatter()
    {
        DestroyObject(gameObject);
        
    }
}
