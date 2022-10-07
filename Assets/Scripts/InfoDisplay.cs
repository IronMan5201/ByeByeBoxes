using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InfoDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public WinOrLose game;

    public PauseMenu pause;

    private static int currentLives;
    private static int currentLevel;

    private static int startingScore;

    private bool levelChanged;

    public TextMeshProUGUI livesGUI;
    public TextMeshProUGUI scoreGUI;
    public TextMeshProUGUI levelGUI;

    public void Start()
    {
        currentLives = WinOrLose.numLives;
        currentLevel = game.levelCounter;
        levelChanged = false;
        startingScore = 15000;

        if(currentLevel > 2 && currentLevel < 5)
        {
            startingScore = 25000;
        }
        else if(currentLevel == 5)
        {
            startingScore = 50000;
        }

        livesGUI.text = "Lives:\n" + currentLives.ToString();
        scoreGUI.text = "Level Score:\n" + startingScore.ToString();
        levelGUI.text = "Level:\n" + currentLevel.ToString();

        game = GameObject.FindObjectOfType<WinOrLose>();
        
    }


    // Update is called once per frame
    void Update()
    {
        LivesCounter();
        LevelCounter();
        ScoreCounter();

    }

    public void LivesCounter()
    {
        //if the number of lives has changed, update the text UI
        if(WinOrLose.numLives < currentLives)
        {
            currentLives = WinOrLose.numLives;
            livesGUI.text = "Lives:\n" + currentLives.ToString();
        }
    }

    public void ScoreCounter()
    {
        //if level changed, we passed the level. So we add the score for that level to the total score
        if(levelChanged)
        {
            game.totalScore += game.currentScore;
            levelChanged = false;
        }
        //if we are not paused continue to decrement the starting score
        else if(!pause.isPaused())
        {
            if(startingScore > 0)
            {
                startingScore--;
            }

            game.currentScore = startingScore;
            scoreGUI.text = "Level Score:\n" + game.currentScore.ToString();
        }
    }

    public void LevelCounter()
    {
        //if the level changed, update the text UI
        if(game.levelCounter > currentLevel)
        {
            currentLevel = game.levelCounter;
            levelGUI.text = "Level:\n" + currentLevel.ToString();
            levelChanged = true;
        }
    }


}
