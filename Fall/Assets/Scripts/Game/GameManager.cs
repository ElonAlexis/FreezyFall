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

    [SerializeField] GameObject postProcessing;
    BlizzardEffect blizzardEffectScript;


    [SerializeField] GameObject watchAdsButton;
    [SerializeField] GameObject playerScoreText = null;
    [SerializeField] GameObject newHighScoreText = null;
    [SerializeField] GameObject _highScoreTextSpriteHolder = null;
    [SerializeField] Sprite[] _gameOverHighScoreTextImage;

    //[SerializeField] AdsMAnager ads; 

    GameObject GameMusicManager; 
    GameObject SoundEffectsManager; 
    
    
     
   // public float Tokens; 
    float highScore;
    bool isScoring = true;

    public TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI goScoreText = null;
    [SerializeField] TextMeshProUGUI goHighScoreScoreText = null;
    [SerializeField] TextMeshProUGUI goHighScoreText = null;
    [SerializeField] TextMeshProUGUI newHighScoreTextText = null;


    [SerializeField] ParticleSystem confettiParticles = null;
    [SerializeField] ParticleSystem confettiParticles2 = null;
    [SerializeField] ParticleSystem confettiParticles3 = null;
    [SerializeField] ParticleSystem confettiParticles4 = null;



    //bool isLevel1 = false;
    bool adIsPlayed;
    public bool gameOver;

    // Start is called before the first frame update
    void Awake()
    {

        if(instance == null)
        {
            instance = this;
        }

        gameOver = false;

        //PlayerPrefs.DeleteAll();                                                                     // Delete all player prefs 
        //PlayerPrefs.DeleteKey("HighScore");                                                       // Delete current Highscore 

        highScoreText.text = "HighScore: " + Mathf.Round(PlayerPrefs.GetFloat("HighScore"));
        if(goHighScoreScoreText != null)
        {
            goHighScoreScoreText.text = "" + Mathf.Round(PlayerPrefs.GetFloat("HighScore"));
        }

        GameMusicManager = GameObject.Find("GameMusicManager");
        SoundEffectsManager = GameObject.Find("SoundEffectManager");
        _highScoreTextSpriteHolder.GetComponent<Image>().sprite = _gameOverHighScoreTextImage[0]; //Set Highscore Image Text at game over

        blizzardEffectScript = postProcessing.GetComponentInParent<BlizzardEffect>(); 
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
        //isLevel1 = true;
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
        adIsPlayed = false;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        MusicManager.instance.PlayClip();
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        MusicManager.instance.PauseClip();
        
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverMenu.SetActive(true);
        isScoring = false;        
               
        if(PlayerPrefs.GetFloat("HighScore") < score)
        {
            SoundManager.instance.NewHighScoreClip();
            //goHighScoreText.text = "LastHighScore: ";
            _highScoreTextSpriteHolder.GetComponent<Image>().sprite = _gameOverHighScoreTextImage[1];
            SpawnConfetti();
            PlayerPrefs.SetFloat("HighScore", score);
            newHighScoreText.SetActive(true);
            playerScoreText.SetActive(false);
            newHighScoreTextText.text = goScoreText.text;
        } 
        else
        {
            SoundManager.instance.GameOverClip();
        }

        Time.timeScale = 0f;
        count = count + 1;
        MusicManager.instance.StopOtherOne();
        MusicManager.instance.SnowyClip();
        if(PlayerPrefs.HasKey("ads") == false)
        {
            if (count == 3)
            {
                count = 0;
              //  ads.PlayAd();                                                                                // Play ads after losing 3 times
            }
        }            
    }

    public void GetHundredCoins()
    {
     //   ads.PlayRewardedAd(OnRewardedAdSuccess);
        // Give player a reward for watching the ad
        Debug.Log("You gained 500 coins");
        GameDataManager.AddCoins(500);
    }

    void OnRewardedAdSuccess()
    {
        // Set adIsPlayed to true to stop player from continuously clicking and getting coins
        adIsPlayed = true;
    }

    public void SpawnConfetti()
    {
        confettiParticles.Play();
        confettiParticles2.Play();
        confettiParticles3.Play();
        confettiParticles4.Play();

    }

}
