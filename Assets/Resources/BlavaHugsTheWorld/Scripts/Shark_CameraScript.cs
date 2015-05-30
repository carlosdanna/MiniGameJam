using UnityEngine;
using System.Collections;

public class Shark_CameraScript : MonoBehaviour {


    // Variables
    private float m_fZoomTimer;
    private int m_nState;
    public GameObject player = null;
    private Vector3 m_v3ZoomOrigin;
    private Vector3 playerStartVolcano;
    private Vector3 playerStartDescent;
    private Shark_Blava_SoundCycle soundSystem;

    public float m_fZoomTimeLength = 2.0f;
    public float m_fZoomOutSize = 5.0f;
    public float m_fZoomInSize = 1.0f;
    // States
    // 0 - Player locked
    // 1 - Player unlocked
    // 2 - Zooming to player
    // 3 - Player win!


	// Use this for initialization
	void Start ()
    {
        m_nState = 1;
        m_fZoomTimer = 0.0f;
        playerStartVolcano = player.transform.position;
        playerStartDescent = new Vector3(playerStartVolcano.x, playerStartVolcano.y + 3.5f, playerStartVolcano.z);
        soundSystem = GetComponent<Shark_Blava_SoundCycle>();
	}
	
	// Update is called once per frame
	void Update () {


        switch ( m_nState )
        {
            case 0: // Player locked
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y -3.25f , -10.0f);

                if (Input.GetKeyDown(KeyCode.O))
                {
                    player.GetComponent<Animator>().SetInteger("m_nAnimatorState", 2);
                    player.GetComponent<Animator>().StopPlayback();
                    player.GetComponent<Animator>().Play("HurtBoulderState");
                }

                if (Input.GetKeyDown(KeyCode.P))
                {
                    player.GetComponent<Animator>().SetInteger("m_nAnimatorState", 3);
                    player.GetComponent<Animator>().StopPlayback();
                    player.GetComponent<Animator>().Play("HurtHoleState");
                }

                break;
            case 1: // Player unlocked
                break;
            case 2: // Zoom to player
                float ratio = (m_fZoomTimeLength - m_fZoomTimer) / m_fZoomTimeLength;
                transform.position = Lerp(m_v3ZoomOrigin, new Vector3(player.transform.position.x, player.transform.position.y - 3.25f, -10.0f), ratio);
                GetComponent<Camera>().orthographicSize = Lerp(m_fZoomOutSize, m_fZoomInSize, ratio);
                player.transform.position = Lerp(playerStartVolcano, playerStartDescent, ratio);
                m_fZoomTimer -= Time.deltaTime;
                if (m_fZoomTimer <= 0.0f)
                {
                    m_nState = 0;
                    transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 3.25f, -10.0f);
                    GetComponent<Camera>().orthographicSize = m_fZoomInSize;
                    player.GetComponent<Animator>().SetInteger("m_nAnimatorState", 1);
                    player.GetComponent<Animator>().StopPlayback();
                    player.GetComponent<Animator>().Play("MoveState");
                    player.GetComponent<BlavaMovement>().GoTime(true);
                    player.GetComponent<SpriteRenderer>().sortingOrder = 3;
                    soundSystem.Play();
                }
                break;
            case 3: // Player win!
                player.GetComponent<BlavaMovement>().GoTime(false);
                player.GetComponent<BlavaMovement>().Speed = 0.0f;
                player.GetComponent<BlavaMovement>().KillRigid();
                player.GetComponent<Animator>().SetInteger("m_nAnimatorState", 4);
                player.GetComponent<Animator>().StopPlayback();
                player.GetComponent<Animator>().Play("WinState");
                m_nState = 1;
                soundSystem.Win();
                break;
        }
	
	}


    void ResetPosition()
    {

    }

    public void ZoomToPlayer()
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

    public void Victory()
    {
        m_nState = 3;
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
