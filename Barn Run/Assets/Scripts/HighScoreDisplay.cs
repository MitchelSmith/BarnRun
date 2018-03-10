using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplay : MonoBehaviour {

    public Text highScoreText1;
    public Text highScoreText2;
    public Text highScoreText3;

    private int highScore1;
    private int highScore2;
    private int highScore3;

    // Update is called once per frame
    public void displayScore()
    {
        highScore1 = PlayerPrefs.GetInt("High Score");
        highScore2 = PlayerPrefs.GetInt("High Score 2");
        highScore3 = PlayerPrefs.GetInt("High Score 3");

        highScoreText1.text = "1. " + highScore1.ToString();
        highScoreText2.text = "2. " + highScore2.ToString();
        highScoreText3.text = "3. " + highScore3.ToString();
    }
}
