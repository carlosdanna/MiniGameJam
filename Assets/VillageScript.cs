using UnityEngine;
using System.Collections;

public class VillageScript : MonoBehaviour 
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
