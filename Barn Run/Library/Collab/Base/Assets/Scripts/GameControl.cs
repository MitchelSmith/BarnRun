using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public GameObject gameOverText;				// Text when Game is over
    public GameObject gameOverScore;
    
	public Text scoreText;						// "Score" is displayed
    public Text highScoreText;					// "High Score" is displayed
	public Text highScore2Text;					// 2nd Highest Score Display Text
	public Text highScore3Text;					// 3rd Highest Score Display Text

    public Text highScoreNameText;
    public Text highScoreName2Text;
    public Text highScoreName3Text;

    public Text coinText;						// "Coins" is displayed
    public bool gameOver = false;				// Boolean for Game Over
    public float scrollSpeed = -4f;				// Scrolling Speed to negative X direction
    public float skySpeed = -1f;				// Sky Scrolling Speed in negative X direction
    public bool isGrounded;
    public AudioClip hitSomething;				// If Player Collides
    public bool playedSound = false;			// Boolean for Audio
    public static int coins = 0;				// Players Coins
    public InputField inputName;

    private float elapsedSeconds = 0;			// How many seconds passed
    private float elapsedSecondsTotal = 0;		// How many seconds passed TOTAL
    
	private int currentScore = 0;				// Current Score
    private int highScore;						// High Score #1
	private int highScore2;						// High Score #2
    private int highScore3;						// High Score #3

    private string currentScoreName;
    private string highScoreName;
    private string highScoreName2;
    private string highScoreName3;

    /* INITIALIZATION */
    void Start()
    {
		/* GRAB ANY DATA NEEDED TO LOAD AT START TIME */
        highScore = PlayerPrefs.GetInt("High Score");
		highScore2 = PlayerPrefs.GetInt ("High Score 2");
		highScore3 = PlayerPrefs.GetInt ("High Score 3");

        highScoreName = PlayerPrefs.GetString("High Score Name");
        highScoreName2 = PlayerPrefs.GetString("High Score Name 2");
        highScoreName3 = PlayerPrefs.GetString("High Score Name 3");

        GetComponent<AudioSource>().playOnAwake = true;
        GetComponent<AudioSource>().clip = hitSomething;

        coins = 0;

        highScoreText.text = "High Score: " + highScore.ToString();
        highScore2Text.text = "High Score 2: " + highScore2.ToString();
        highScore3Text.text = "High Score 3: " + highScore3.ToString();

        highScoreNameText.text = highScoreName;
        highScoreName2Text.text = highScoreName2;
        highScoreName3Text.text = highScoreName3;
    }
		
	void Awake ()
    {
		if (instance == null)       // Singleton software design pattern
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
	}
	
	/* UPDATES ONCE PER FRAME */
	void Update ()
    {
		if (gameOver == true && Input.GetMouseButtonDown(0))    // Resets to start of the game if tapped after game is lost
        {
		gameOverText.SetActive(true);   
        }

        elapsedSeconds += Time.deltaTime;
        elapsedSecondsTotal += Time.deltaTime;
        if(elapsedSeconds > 5 && elapsedSecondsTotal <= 30)     // Speeds up ground and background as time goes on
        {
            elapsedSeconds = 0;
            scrollSpeed -= 0.25f;
            skySpeed -= 0.25f;
        }
        if(elapsedSeconds > 5 && elapsedSecondsTotal > 30)
        {
            elapsedSeconds = 0;
            scrollSpeed -= 0.45f;
            skySpeed -= 0.45f;
        }

        Coins();
		//ChickenScored();
	}

	/* COINS FUNCTION */
    void Coins()
    {
        if (gameOver)
        {
            return;
        }

        coinText.text = "Coins: " + coins.ToString();
    }

    // Updates the score during the game and saves the high score if it exceeds the original high score
    public void ChickenScored()
    {
        if(gameOver)
        {
            return;
        }

        currentScore++;
        scoreText.text = "Score: " + currentScore.ToString();      //updates score

		if(PlayerPrefs.HasKey("High Score"))
		{
            highScore = PlayerPrefs.GetInt("High Score");
			highScore2 = PlayerPrefs.GetInt ("High Score 2");
			highScore3 = PlayerPrefs.GetInt ("High Score 3");
		}

		// Do we need this else-Statement? Seems to work without it - QN
		else
        {
            highScore = 0;
			highScore2 = 0;
			highScore3 = 0;
        }

        highScoreText.text = "High Score: " + highScore.ToString();
		highScore2Text.text = "High Score 2: " + highScore2.ToString ();
		highScore3Text.text = "High Score 3: " + highScore3.ToString();
    }

    // Activates game over text and plays chicken sound
    public void ChickenDied()
    {
		// If Player Score is greater than old High Score #1
		// Save to highScore and shift previous score down 1
		if(currentScore > highScore)       //saves new high score if greater than the original one
		{
            /* SAVE SCORES */
            gameOverScore.SetActive(true);
			PlayerPrefs.SetInt("High Score", currentScore);
            PlayerPrefs.SetString("High Score Name", currentScoreName);
			PlayerPrefs.SetInt ("High Score 2", highScore);
            PlayerPrefs.SetString("High Score Name 2", highScoreName);
			PlayerPrefs.SetInt ("High Score 3", highScore2);
            PlayerPrefs.SetString("High Score Name 3", highScoreName2);
			PlayerPrefs.Save();
		}

		else if(currentScore > highScore2)
		{
            /* SAVE SCORES */
            gameOverScore.SetActive(true);
            PlayerPrefs.SetInt ("High Score 2", currentScore);
            PlayerPrefs.SetString("High Score Name 2", currentScoreName);
			PlayerPrefs.SetInt ("High Score 3", highScore2);
            PlayerPrefs.SetString("High Score Name 3", highScoreName2);
			PlayerPrefs.Save ();
		} 
			
		else if (currentScore > highScore3)
		{
            /* SAVE SCORES */
            gameOverScore.SetActive(true);
            PlayerPrefs.SetInt ("High Score 3", currentScore);
            PlayerPrefs.SetString("High Score Name 3", currentScoreName);
			PlayerPrefs.Save ();
		}

        gameOverText.SetActive(true);       
        gameOver = true;                
        if(playedSound == false)
        {
            GetComponent<AudioSource>().Play();
            playedSound = true;
        }
    }

    public void OnEntry()
    {
        //highScoreName = GetComponent<InputField>().text;
		//highScoreName = gameOverScore.GetComponentsInChildren<InputField>().Text;
    }
}