using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    
    public AudioSource soundFX;
    public AudioSource soundFX2;
    public AudioSource soundFX3; // Wind/Gust Effect



    [SerializeField]
    AudioClip landClip, coinClip, iceBreakClip, gameOverClip, fallClip;

    // Start is called before the first frame update
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
    }

  public void LandClip()
    {
        //if (MusicManager.instance.isPlaying)
        //{
        //    soundFX.clip = landClip;
        //    //soundFX.volume = 0.2f;
        //    soundFX.Play();
        //}
    }
    public void CoinClip()
    {
        if (MusicManager.instance.isPlaying)
        {
            soundFX2.clip = coinClip;
            soundFX2.volume = 1f;
            soundFX2.Play();
        }
    }
    public void IceBreakClip()
    {
        if (MusicManager.instance.isPlaying)
        {
            soundFX2.clip = iceBreakClip;
            soundFX2.volume = 2f;
            soundFX2.Play();
        }
    }
    public void GameOverClip()
    {
        if (MusicManager.instance.isPlaying)
        {
            soundFX.clip = gameOverClip;
            soundFX.Play();
        }
    }
    public void FallClip()
    {
        if(MusicManager.instance.isPlaying)
        {
            soundFX.clip = fallClip;
            soundFX.Play();
            soundFX.volume = 0.1f;
        }        
    }
    public void StopClip()
    {
        soundFX.Stop();
        soundFX2.Stop();
        soundFX3.Stop();

    }
    public void PlayClip()
    {
        soundFX.Play();
        soundFX2.Play();
        soundFX3.Play();


    }



}
