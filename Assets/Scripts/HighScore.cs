using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{

    public InfoDisplay info;

    public WinOrLose game;

    public int playerScore;
    public int highScore = 0;

    public TextMeshProUGUI playerScoreGUI;

    public TextMeshProUGUI highScoreGUI;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindObjectOfType<WinOrLose>();

        playerScore = game.totalScore;
        highScore = PlayerPrefs.GetInt("highScore", highScore);

        playerScoreGUI.text = "Your Score:\n" + playerScore.ToString();

        highScoreGUI.text = "Highscore:\n" + highScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(playerScore > highScore)
        {
            highScore = playerScore;
            highScoreGUI.text = "Highscore:\n" + highScore.ToString();
            PlayerPrefs.SetInt("highScore", highScore);
        }
    }
}
