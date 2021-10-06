using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX;
    [SerializeField]
    private AudioSource soundFX2;


    [SerializeField]
    AudioClip landClip, coinClip, iceBreakClip, gameOverClip, fallClip;

    //public AudioSource soundManagerAudio1; 
    //public AudioSource soundManagerAudio2; 




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
        soundFX.clip = landClip;
        soundFX.volume = 0.2f;
        soundFX.Play();

    }
    public void CoinClip()
    {
        soundFX2.clip = coinClip;
        soundFX2.volume = 1f;
        soundFX2.Play();
    }
    public void IceBreakClip()
    {
        soundFX.clip = iceBreakClip;
        soundFX.Play();
    }
    public void GameOverClip()
    {
        soundFX.clip = gameOverClip;
        soundFX.Play();
    }
    public void FallClip()
    {
        soundFX.clip = fallClip;
        soundFX.Play();
        soundFX.volume = 0.1f;
    }
    public void StopClip()
    {
        soundFX.Stop();
    }


}
