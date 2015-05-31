using UnityEngine;
using System.Collections;

public class Shark_Blava_BGMCycler : MonoBehaviour {

    private AudioSource[] bgm_tracks = new AudioSource[2];


	// Use this for initialization
	void Start () {
        bgm_tracks = GetComponents<AudioSource>();
	}
	

    public void PlaySong(string songName)
    {
        if (songName == "music" && !bgm_tracks[0].isPlaying)
        {
            bgm_tracks[1].Stop();
            bgm_tracks[0].Play();
        }
        else if (songName == "ambient")
        {
            bgm_tracks[0].Stop();
            bgm_tracks[1].Play();
        }
    }
}
