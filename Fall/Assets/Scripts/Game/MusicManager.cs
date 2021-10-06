using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [SerializeField]
        
    private AudioSource soundFX;
    public AudioSource musicManagerAudio1; 
    public AudioSource musicManagerAudio2; 
    public AudioSource otherOne; 

    public GameObject audioOnButton; 
    public GameObject audioOffButton;
    bool isPlayingAudio; 

    [SerializeField]
     AudioClip menuMusic, gameMusic, creditsMusic; 
     void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        isPlayingAudio = true; 
    }

    public void MainMenuClip()
    {
        soundFX.clip = menuMusic;
        soundFX.Play();
    }
    public void GameMusicClip()
    {
        soundFX.clip = gameMusic;
        soundFX.Play();
    }
     public void CreditsClip()
    {
        soundFX.clip = creditsMusic;
        soundFX.Play();
    }

    public void StopClip()
    {
        soundFX.Stop();
    }
    public void StopOtherOne()
    {
        otherOne.enabled = false;
    }
    
    public void TurnOffAllAudio()
    {
       isPlayingAudio = false;
       musicManagerAudio1.volume = 0;
       musicManagerAudio2.volume = 0;
      // SoundManager.instance.soundManagerAudio1.volume = 0;
       //SoundManager.instance.soundManagerAudio2.volume = 0;
     }
    public void TurnOnAllAudio()
    {
        isPlayingAudio = true;
        musicManagerAudio1.volume = 1;
        musicManagerAudio2.volume = 1;
        //SoundManager.instance.soundManagerAudio1.volume = 1;
        //SoundManager.instance.soundManagerAudio2.volume = 1;       
    }
}
