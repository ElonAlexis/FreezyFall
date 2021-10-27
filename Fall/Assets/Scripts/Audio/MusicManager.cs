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
    GameObject audioTxt;

    [SerializeField]
     AudioClip menuMusic, gameMusic, creditsMusic, snowyMusic;

    public bool isPlaying;
    public bool hide;


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

        AudioCheckingUpdate();

    }

    public void MainMenuClip()
    {
        soundFX.clip = menuMusic;
        soundFX.Play();
    }
    public void SnowyClip()
    {
        soundFX.clip = snowyMusic;
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
    public void PlayClip()
    {
        soundFX.Play();
    }
    public void PauseClip()
    {
        soundFX.Pause();
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

    void AudioCheckingUpdate()
    {
        prefs = PlayerPrefs.GetInt("AudioState");
        if (prefs == 1)
        {
            TurnOnAllAudio();
            if (hide)
            {
                audioOnButton.enabled = false;
            }
            else
            {
                audioOnButton.enabled = true;
            }

        }
        else if (prefs == 0)
        {
            TurnOffAllAudio();
            if (hide)
            {
                audioOffButton.enabled = false;  
            }
            else
            {
                audioOffButton.enabled = true;
            }
        }
    }
   
}
