using UnityEngine;
using System.Collections;

public class Shark_CameraScript : MonoBehaviour {


    // Variables
    private float m_fZoomTimer;
    private int m_nState;
    public GameObject player = null;
    private Vector3 m_v3ZoomOrigin;

    public float m_fZoomTimeLength = 2.0f;
    public float m_fZoomOutSize = 5.0f;
    public float m_fZoomInSize = 1.0f;
    // States
    // 0 - Player locked
    // 1 - Player unlocked
    // 2 - Zooming to player


	// Use this for initialization
	void Start ()
    {
        m_nState = 1;
        m_fZoomTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {


        switch ( m_nState )
        {
            case 0: // Player locked
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y , -10.0f);
                break;
            case 1: // Player unlocked
                if (Input.GetKeyDown(KeyCode.T))
                    ZoomToPlayer();
                break;
            case 2: // Zoom to player
                transform.position = Lerp(m_v3ZoomOrigin, new Vector3(player.transform.position.x, player.transform.position.y, -10.0f), (m_fZoomTimeLength - m_fZoomTimer) / m_fZoomTimeLength);
                GetComponent<Camera>().orthographicSize = Lerp(m_fZoomOutSize, m_fZoomInSize, (m_fZoomTimeLength - m_fZoomTimer) / m_fZoomTimeLength);
                m_fZoomTimer -= Time.deltaTime;
                if (m_fZoomTimer <= 0.0f)
                {
                    m_nState = 0;
                    transform.position = player.transform.position;
                    GetComponent<Camera>().orthographicSize = m_fZoomInSize;
                }
                break;
        }
	
	}


    void ResetPosition()
    {

    }

    void ZoomToPlayer()
    {
        m_fZoomTimer = m_fZoomTimeLength;
        m_v3ZoomOrigin = transform.position;
        m_nState = 2;
    }

    void LockToPlayer()
    {
        m_nState = 0;
    }

    void UnlockFromPlayer()
    {
        m_nState = 1;
    }

    Vector3 Lerp(Vector3 src, Vector3 dest, float ratio)
    {
        return ((dest - src) * ratio + src);
    }

    float Lerp(float src, float dest, float ratio)
    {
        return ((dest - src) * ratio + src);
    }
}
