using UnityEngine;
using System.Collections;

public class Shark_DeathBound : MonoBehaviour 
{

    private float victoryTimer;
    private bool weWin = false;
    private Shark_CameraScript player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Shark_CameraScript>();
    }

	// Update is called once per frame
	void Update () 
    {
        if (weWin == true)
        {
            victoryTimer -= Time.deltaTime;

            if (victoryTimer <= 0.0f)
            {
                weWin = false;
                Application.LoadLevel(Application.loadedLevel);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            weWin = true;
            victoryTimer = 3.0f;
            player.Victory();
        }
    }
}
