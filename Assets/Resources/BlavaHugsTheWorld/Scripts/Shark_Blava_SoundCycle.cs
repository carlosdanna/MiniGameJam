using UnityEngine;
using System.Collections;

public class Shark_Blava_SoundCycle : MonoBehaviour {

    private AudioSource[] lava_sizzle = new AudioSource[6];
    private bool isOn = false;
    private float noSkipTimer;
    private int noSkipNextIndex;

	// Use this for initialization
	void Start () {
        lava_sizzle = GetComponents<AudioSource>();

        noSkipNextIndex = Random.Range(0, 6);
        noSkipTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

        if (!isOn)
            return;

        noSkipTimer -= Time.deltaTime;
        if ( noSkipTimer <= 0.05f )
        {
            lava_sizzle[noSkipNextIndex].Play();
            noSkipTimer = lava_sizzle[noSkipNextIndex].clip.length;
            noSkipNextIndex = Random.Range(0, 6);
        }
	}

    public void Play()
    {
        isOn = true;
    }

    public void Stop()
    {
        isOn = false;
        for (int i = 0; i < 6; ++i)
        {
            if (lava_sizzle[i].isPlaying)
            {
                lava_sizzle[i].Stop();
                return;
            }
        }
    }
}
