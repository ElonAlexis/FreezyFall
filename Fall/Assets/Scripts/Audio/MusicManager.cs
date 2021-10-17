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
    
    GameObject ON;
    SpriteRenderer audioOnButton;
    
    GameObject OFF; 
    SpriteRenderer audioOffButton;

    [SerializeField]
     AudioClip menuMusic, gameMusic, creditsMusic, gameOverMusic;

    public bool isPlaying;

    public int prefs;


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
        //DontDestroyOnLoad(Audio);
        isPlaying = true;
    }
    void Start()
    {
        PlayerPrefs.SetInt("AudioState", 1);
    }
    void Update()
    {
        ON = GameObject.FindGameObjectWithTag("ScreamON");
        OFF = GameObject.FindGameObjectWithTag("ScreamOFF");
        audioOnButton = ON.GetComponent<SpriteRenderer>();
        audioOffButton = OFF.GetComponent<SpriteRenderer>();

        prefs = PlayerPrefs.GetInt("AudioState");
        if (prefs == 1)
        {
            TurnOnAllAudio();
        }
        else
        {
            TurnOffAllAudio();
        }
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
            SoundManager.instance.StopClip();

        }
        else 
        {
            TurnOnAllAudio();
            SoundManager.instance.PlayClip();

        }
    }
    public void TurnOffAllAudio()
    {
        PlayerPrefs.SetInt("AudioState", 0);
        audioOnButton.enabled = false;
        audioOffButton.enabled = true;
        musicManagerAudio1.volume = 0;
        musicManagerAudio2.volume = 0;
        isPlaying = false;
     }
    public void TurnOnAllAudio()
    {
        PlayerPrefs.SetInt("AudioState", 1);
        audioOnButton.enabled = true;
        audioOffButton.enabled = false;
        musicManagerAudio1.volume = 1;
        musicManagerAudio2.volume = 1;
        isPlaying = true;       
    }
}
