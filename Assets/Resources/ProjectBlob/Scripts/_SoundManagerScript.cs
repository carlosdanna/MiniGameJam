using UnityEngine;
using System.Collections;

public class _SoundManagerScript : MonoBehaviour {

    // === Sound Structure
    struct Sound
    {
        public AudioClip m_Audio;
        public SoundID m_ID;
        public SoundType m_Type;
    }

    // === Enums
    public enum SoundID { bSelect = 0, bShoot = 1, bSplat1 = 2, bSplat2 = 3, bSplat3 = 4, bScore = 5, bPlaySelect = 6, bVictory = 7, bGameMusic = 8 };
    public enum SoundType { bMusic, bSFX };

    // === Variables
    ArrayList m_Sounds = new ArrayList();
    bool[] m_SoundSwitches = new bool[2];

    // Use this for initialization
    void Start()
    {
        // === Load all Sounds in the beginning
        Sound sound;
        // == Menu Select
        sound.m_Audio = (AudioClip)Resources.Load("ProjectBlob/Audio/Blob_MenuSelect");
        sound.m_ID = SoundID.bSelect;
        sound.m_Type = SoundType.bSFX;
        m_Sounds.Add(sound);
        // == Shoot
        sound.m_Audio = (AudioClip)Resources.Load("ProjectBlob/Audio/Blob_Shoot");
        sound.m_ID = SoundID.bShoot;
        sound.m_Type = SoundType.bSFX;
        m_Sounds.Add(sound);
        // == Splat 1
        sound.m_Audio = (AudioClip)Resources.Load("ProjectBlob/Audio/Blob_Splat1");
        sound.m_ID = SoundID.bSplat1;
        sound.m_Type = SoundType.bSFX;
        m_Sounds.Add(sound);
        // == Splat 2
        sound.m_Audio = (AudioClip)Resources.Load("ProjectBlob/Audio/Blob_Splat2");
        sound.m_ID = SoundID.bSplat2;
        sound.m_Type = SoundType.bSFX;
        m_Sounds.Add(sound);
        // == Splat 3
        sound.m_Audio = (AudioClip)Resources.Load("ProjectBlob/Audio/Blob_Splat3");
        sound.m_ID = SoundID.bSplat3;
        sound.m_Type = SoundType.bSFX;
        m_Sounds.Add(sound);
        // == Score
        sound.m_Audio = (AudioClip)Resources.Load("ProjectBlob/Audio/Blob_Score");
        sound.m_ID = SoundID.bScore;
        sound.m_Type = SoundType.bSFX;
        m_Sounds.Add(sound);
        // == Play Select
        sound.m_Audio = (AudioClip)Resources.Load("ProjectBlob/Audio/Blob_PlaySelect");
        sound.m_ID = SoundID.bPlaySelect;
        sound.m_Type = SoundType.bSFX;
        m_Sounds.Add(sound);
        // == Victory
        sound.m_Audio = (AudioClip)Resources.Load("ProjectBlob/Audio/Blob_Victory");
        sound.m_ID = SoundID.bVictory;
        sound.m_Type = SoundType.bSFX;
        m_Sounds.Add(sound);
        // == Game Music
        sound.m_Audio = (AudioClip)Resources.Load("ProjectBlob/Audio/Blob_Music");
        sound.m_ID = SoundID.bGameMusic;
        sound.m_Type = SoundType.bMusic;
        m_Sounds.Add(sound);
        // ===
        // === Defaults
        m_SoundSwitches[0] = true;
        m_SoundSwitches[1] = true;
    }

    // ===== Play Sound Functions ===== //
    public void PlayAudio(SoundID _ID)
    {
        foreach (Sound sound in m_Sounds)
        {
            if (sound.m_ID == _ID)
            {
                if (m_SoundSwitches[(int)sound.m_Type]) {
                    GetComponent<AudioSource>().clip = sound.m_Audio;
                    GetComponent<AudioSource>().Play();
                }
                break;
            }
        }
    }
    public void PlayAudio(int _ID)
    {
        foreach (Sound sound in m_Sounds)
        {
            if (sound.m_ID == (SoundID)_ID)
            {
                if (m_SoundSwitches[(int)sound.m_Type])
                {
                    GetComponent<AudioSource>().clip = sound.m_Audio;
                    GetComponent<AudioSource>().Play();
                }
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

    // ===== Accessors ===== //
    public bool IsAudioPlaying(int _ID)
    {
        foreach (Sound sound in m_Sounds)
        {
            if (sound.m_ID == (SoundID)_ID && sound.m_Audio == GetComponent<AudioSource>().isPlaying)
                return true;
        }
        return false;
    }

    public bool IsAudioTypeEnabled(int _ID)
    {
        return m_SoundSwitches[_ID];
    }
    // ===================== //

    // ===== Sound Toggle Functions ===== //
    public void ToggleSoundType(int _type)
    {
        m_SoundSwitches[_type] = !m_SoundSwitches[_type];
    }
    // ================================== //
	
	// Update is called once per frame
	void Update () {
	
	}
}
