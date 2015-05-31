using UnityEngine;
using System.Collections;

public class _BlobScript : MonoBehaviour {
    // === Variables
    public Vector3 CenterPosition;
    public GameObject splatterPrefab;
    public Color color;
    float m_fSpeed = 10f;
    float m_fMaxHeight = 1.25f;
    bool m_bFalling = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        // === Taking care of scale
        Vector3 scale = transform.localScale;
        scale.x -= m_fSpeed * Time.deltaTime;
        scale.y -= m_fSpeed * Time.deltaTime;
        transform.localScale = scale;
        if (scale.x <= 7f)
            GetComponent<Animator>().SetTrigger("Splatter");
        // ===
        // === Taking care of Position
        Vector3 position = transform.position;
        // == Updating the height
        if (position.y < CenterPosition.y + m_fMaxHeight && !m_bFalling)
        {
            position.y += 4f * Time.deltaTime;
        }
        else
        {
            position.y -= 4f * Time.deltaTime;
            m_bFalling = true;
        }
        // == Keeping it centered
        position.x -= .15f * Time.deltaTime;
        transform.position = position;
        // ===
	}

    // Splatter Function
    void Splatter()
    {
        // Destroy the Blob
        DestroyObject(gameObject);
        // Spawn the Splatter
        GameObject splatter = Instantiate<GameObject>(splatterPrefab) as GameObject;
        splatter.GetComponent<SpriteRenderer>().color = color;
        Vector3 position = transform.position;
        position.z = 9f;
        splatter.transform.position = position;
        // Playing the Audio
        _SoundManagerScript.SoundID splatterID = (_SoundManagerScript.SoundID)Random.Range(2, 5);
        Camera.main.GetComponent<_SoundManagerScript>().PlayAudio(splatterID);
    }
}
