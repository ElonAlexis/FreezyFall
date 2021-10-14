using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [SerializeField]
        
    private AudioSource soundFX;
    public AudioSource musicManagerAudio1; 
    public AudioSource musicManagerAudio2; 
    public AudioSource otherOne;

    [SerializeField]
    GameObject Audio;
    [SerializeField]
    GameObject ON;
    public SpriteRenderer audioOnButton;
    [SerializeField]
    GameObject OFF; 
    public SpriteRenderer audioOffButton;

    [SerializeField]
     AudioClip menuMusic, gameMusic, creditsMusic, gameOverMusic;

    public bool isPlaying; 


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
        DontDestroyOnLoad(Audio);

        audioOnButton = ON.GetComponent<SpriteRenderer>();
        audioOffButton = OFF.GetComponent<SpriteRenderer>();

        isPlaying = true;
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
    public void GameOverClip()
    {
        soundFX.clip = gameOverMusic;
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
    public void OnButtonPress()
    {
        if(isPlaying)
        {
            TurnOffAllAudio();
        }
        else 
        {
            TurnOnAllAudio();
        }
    }
    public void TurnOffAllAudio()
    {
        audioOnButton.enabled = false;
        audioOffButton.enabled = true;
        musicManagerAudio1.volume = 0;
        musicManagerAudio2.volume = 0;
        SoundManager.instance.StopClip();
        isPlaying = false;
      // SoundManager.instance.soundManagerAudio1.volume = 0;
       //SoundManager.instance.soundManagerAudio2.volume = 0;
     }
    public void TurnOnAllAudio()
    {
        audioOnButton.enabled = true;
        audioOffButton.enabled = false;
        musicManagerAudio1.volume = 1;
        musicManagerAudio2.volume = 1;
        SoundManager.instance.PlayClip();

        isPlaying = true;
        //SoundManager.instance.soundManagerAudio1.volume = 1;
        //SoundManager.instance.soundManagerAudio2.volume = 1;       
    }
}
