using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
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
    AudioSource _menuSfxAudioSource, _menuMusicAudioSource;

    [SerializeField]
    AudioMixer _mixer;

    [SerializeField]
    Slider _musicSlider, _sfxSlider;

    [Range(0f, 1f)]
    [SerializeField] float musicVolume, sfxVolume;
    
    GameObject ON;
    SpriteRenderer audioOnButton;
    
    GameObject OFF; 
    SpriteRenderer audioOffButton;

    
    GameObject audioTxt;

    [SerializeField]
     AudioClip menuMusic, gameMusic, creditsMusic, snowyMusic;

    public bool isPlaying;
    public bool hide;


    public int prefs;

    const string _mixerMusic = "MusicVolume";
    const string _mixerSfx = "SfxVolume";
    
    const string _musicKey = "MusicVolumeKey";
    const string _sfxKey = "SfxVolumeKey";

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

        _musicSlider.onValueChanged.AddListener(SetMusicVolume);
        _sfxSlider.onValueChanged.AddListener(SetSfxVolume);

        LoadSettings();
    }
    void Start()
    {
        PlayerPrefs.SetInt("AudioState", 1);

        _musicSlider.value = PlayerPrefs.GetFloat(_musicKey);
        _sfxSlider.value = PlayerPrefs.GetFloat(_sfxKey);

    }
    void Update()
    {
        ON = GameObject.FindGameObjectWithTag("ScreamON");
        OFF = GameObject.FindGameObjectWithTag("ScreamOFF");
        //audioOnButton = ON.GetComponent<SpriteRenderer>();                                    //////////////////////////////////////// Audio button sprite
        //audioOffButton = OFF.GetComponent<SpriteRenderer>();

        AudioCheckingUpdate();

        //_menuMusicAudioSource.volume = musicVolume;
        //_menuSfxAudioSource.volume = sfxVolume;
        Debug.Log("Here---------" + PlayerPrefs.GetFloat(_sfxKey));
    }

    void SetMusicVolume(float value)
    {
        _mixer.SetFloat(_mixerMusic, Mathf.Log10(value) * 20);
    }

    void SetSfxVolume(float value)
    {
        _mixer.SetFloat(_mixerSfx, Mathf.Log10(value) * 20);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat(_musicKey, _musicSlider.value);
        PlayerPrefs.SetFloat(_sfxKey, _sfxSlider.value);
    }

    public void LoadSettings()
    {
        float musicVolumeValue = PlayerPrefs.GetFloat(_musicKey, 1f);
        float sfxVolumeValue = PlayerPrefs.GetFloat(_sfxKey, 1f);

        _mixer.SetFloat(_musicKey, Mathf.Log10(musicVolumeValue) * 20);
        _mixer.SetFloat(_sfxKey, Mathf.Log10(sfxVolumeValue) * 20);
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
       // audioOnButton.enabled = false;                                                            ///////////////////////////////////////////// More Audio Button stuff
       // audioOffButton.enabled = true;
        musicManagerAudio1.volume = 0;
        musicManagerAudio2.volume = 0;
        isPlaying = false;
     }
    public void TurnOnAllAudio()
    {
        PlayerPrefs.SetInt("AudioState", 1);
       // audioOnButton.enabled = true;                                                             ///////////////////////////////////////////// More Audio Button stuff
       // audioOffButton.enabled = false;
        musicManagerAudio1.volume = 1;
        musicManagerAudio2.volume = 1;
        isPlaying = true;       
    }

    void AudioCheckingUpdate() => prefs = PlayerPrefs.GetInt("AudioState");
   
}
