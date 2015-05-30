using UnityEngine;
using System.Collections;

public class _SoundManagerScript : MonoBehaviour {

    // === Sound Structure
    struct Sound
    {
        public AudioClip m_Audio;
        public SoundID m_ID;
    }

    // === Enums
    public enum SoundID { bSelect = 0, bShoot = 1, bSplat1 = 2, bSplat2 = 3, bSplat3 = 4, bVictory = 5 };

    // === Variables
    ArrayList m_Sounds = new ArrayList();

    // Use this for initialization
    void Start()
    {
        // === Load all Sounds in the beginning
        Sound sound;
        // == Menu Select
        sound.m_Audio = (AudioClip)Resources.Load("ProjectBlob/Audio/Blob_MenuSelect");
        sound.m_ID = SoundID.bSelect;
        m_Sounds.Add(sound);
        // == Shoot
        sound.m_Audio = (AudioClip)Resources.Load("ProjectBlob/Audio/Blob_Shoot");
        sound.m_ID = SoundID.bShoot;
        m_Sounds.Add(sound);
        // == Splat 1
        sound.m_Audio = (AudioClip)Resources.Load("ProjectBlob/Audio/Blob_Splat1");
        sound.m_ID = SoundID.bSplat1;
        m_Sounds.Add(sound);
        // == Splat 2
        sound.m_Audio = (AudioClip)Resources.Load("ProjectBlob/Audio/Blob_Splat2");
        sound.m_ID = SoundID.bSplat2;
        m_Sounds.Add(sound);
        // == Splat 3
        sound.m_Audio = (AudioClip)Resources.Load("ProjectBlob/Audio/Blob_Splat3");
        sound.m_ID = SoundID.bSplat3;
        m_Sounds.Add(sound);
        // == Victory
        sound.m_Audio = (AudioClip)Resources.Load("ProjectBlob/Audio/Blob_Score");
        sound.m_ID = SoundID.bVictory;
        m_Sounds.Add(sound);
        // ===
    }

    // ===== Play Sound Functions ===== //
    public void PlayAudio(SoundID _ID)
    {
        foreach (Sound sound in m_Sounds)
        {
            if (sound.m_ID == _ID)
            {
                GetComponent<AudioSource>().clip = sound.m_Audio;
                GetComponent<AudioSource>().Play();
                break;
            }
        }
    }

    // Only here so buttons can play the sound directly w/o scripting
    public void PlaySelectSFX()
    {
        PlayAudio(SoundID.bSelect);
    }
    // ================================ //
	
	// Update is called once per frame
	void Update () {
	
	}
}
