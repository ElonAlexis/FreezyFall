using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    static int count;
    public float score;
    public GameObject pauseMenu; 
    public GameObject gameOverMenu;
    public GameObject shop;


    [SerializeField] GameObject watchAdsButton;
    [SerializeField] AdsMAnager ads; 
    
    GameObject GameMusicManager; 
    GameObject SoundEffectsManager; 
    
    
     
   // public float Tokens; 
    float highScore;
    bool isScoring = true;

    public TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI goScoreText = null;
    [SerializeField] TextMeshProUGUI goHighScoreText = null;


    [SerializeField] ParticleSystem confettiParticles = null;
    [SerializeField] ParticleSystem confettiParticles2 = null;



    bool isLevel1 = false;
    bool adIsPlayed;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        //PlayerPrefs.DeleteKey("HighScore");

        highScoreText.text = "HighScore: " + Mathf.Round(PlayerPrefs.GetFloat("HighScore"));
        if(goHighScoreText != null)
        {
            goHighScoreText.text = "" + Mathf.Round(PlayerPrefs.GetFloat("HighScore"));
        }

        GameMusicManager = GameObject.Find("GameMusicManager");
        SoundEffectsManager = GameObject.Find("SoundEffectManager");

    }
    private void Update()
    {

        scoreText.text = "" + Mathf.Round(score);
        if (goScoreText != null)
        {
            goScoreText.text = scoreText.text;
        }

        if (isScoring)
        {
            score += 10 * Time.deltaTime;
        }

        if(adIsPlayed)
        {
            watchAdsButton.SetActive(false);
        }
        else if (!adIsPlayed)
        {
            watchAdsButton.SetActive(true);
        }
    }
    public void Reset()
    {       
        Invoke("LevelRestart", 1.5f);  
    }

    public void LevelRestart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;  
        MusicManager.instance.StopOtherOne();
        MusicManager.instance.GameMusicClip();
        isScoring = true;
        adIsPlayed = false;        
    }

    public void PlayGame()
    {
        isLevel1 = true;
        SceneManager.LoadScene(1);
        MusicManager.instance.StopOtherOne();
        MusicManager.instance.GameMusicClip();
        
    }

    public void Credits()
    {
        SceneManager.LoadScene(2);
        MusicManager.instance.StopOtherOne();
        MusicManager.instance.CreditsClip();
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);  
        Time.timeScale = 1f;   
        MusicManager.instance.StopOtherOne();
        MusicManager.instance.MainMenuClip();         
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; 
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        isScoring = false;
        if(PlayerPrefs.GetFloat("HighScore") < score)
        {
            //SpawnConfetti();
            PlayerPrefs.SetFloat("HighScore", score);
        }      

        Time.timeScale = 0f;
        adIsPlayed = false;
        count = count + 1;
        if(count == 3)
        {
            count = 0;

           // ads.PlayAd();                                                                                 Play ads after losing 3 times
        }
    }

    public void GetHundredCoins()
    {
        ads.PlayRewardedAd(OnRewardedAdSuccess);
        // Give player a reward for watching the ad
        Debug.Log("You gained 100 coins");
        GameDataManager.AddCoins(100);
    }

    void OnRewardedAdSuccess()
    {
        // Restart level after watching ad
        //LevelRestart();

        // Set adIsPlayed to true to stop player from continuously clicking and getting coins
        adIsPlayed = true;
    }

    public void SpawnConfetti()
    {
        confettiParticles.Play();
        confettiParticles2.Play();

    }

}
