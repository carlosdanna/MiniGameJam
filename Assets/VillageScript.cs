using UnityEngine;
using System.Collections;

public class VillageScript : MonoBehaviour 
{
    private float victoryTimer;
    private bool weWin = false;
    private Shark_CameraScript player;
    private bool panicking = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Shark_CameraScript>();
    }


    void Update()
    {
        if ( weWin == true )
        {
            victoryTimer -= Time.deltaTime;

            if ( victoryTimer <= 0.0f )
            {
                weWin = false;
                Application.LoadLevel(Application.loadedLevel);
            }
        }

        if ((GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).magnitude < 5.0f)
        {
            GetComponent<Animator>().SetBool("isPanicking", true);
            panicking = true;
        }
        else
            GetComponent<Animator>().SetBool("isPanicking", false);

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<Animator>().SetBool("isDying", true);
            weWin = true;
            victoryTimer = 3.0f;
            player.Victory();
        }
    }

    public bool IsPanicking()
    {
        return panicking;
    }
}
