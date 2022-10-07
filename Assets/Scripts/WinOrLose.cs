using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinOrLose : MonoBehaviour
{
    // Start is called before the first frame update
    public bool gameEnded = false;
    public WinDevice winDevice;
    public LoseDevice loseDevice;
    public AmbienceDevice ambienceDevice;

    public Goal goal;

    public InfoDisplay info;

    private static GameObject instance;

    //Counts the number of levels a player has finished, game has 5 levels
    public int levelCounter = 1;
    public static int numLives = 3;

    public int currentScore;
    public int totalScore;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if(instance == null)
        {
            instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }

        winDevice = GameObject.FindObjectOfType<WinDevice>();
        loseDevice = GameObject.FindObjectOfType<LoseDevice>();
        ambienceDevice = GameObject.FindObjectOfType<AmbienceDevice>();
        goal = GameObject.FindObjectOfType<Goal>();
        info = GameObject.FindObjectOfType<InfoDisplay>();

        //if the current scene is not win or lose screen, call goal and start functions to reset for another level
        if( !SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByBuildIndex(6)) && !SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByBuildIndex(7)))
        {
            goal.Start();
            info.Start();
        }

        currentScore = 0;
        totalScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //continue to check for ambience device and infoDisplay if we dont have them assigned
        if(ambienceDevice == null)
        {
            ambienceDevice = GameObject.FindObjectOfType<AmbienceDevice>();
        }

        if(info == null)
        {
            info = GameObject.FindObjectOfType<InfoDisplay>();
        }

        //if we are on the main menu, reset the game information for new game
        if(SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByBuildIndex(0)))
        {
            levelCounter = 1;
            numLives = 3;
            gameEnded = false;
            currentScore = 0;
            totalScore = 0;
        }
    }


    //called when all levels have been passed and loads the WinScene
    public void WinGame()
    {
        if(gameEnded == false)
        {
            Debug.Log("You Win!");
            winDevice.myAudio.Play();
            gameEnded = true;
            //load win scene and menu to play again etc.
            SceneManager.LoadScene(6);
        }
    }

    //called when player has ran out of lives and has lost. Loads the LoseScene
    public void LoseGame()
    {
        if(gameEnded == false)
        {
            Debug.Log("You Lose!");
            loseDevice.myAudio.Play();
            gameEnded = true;
            //load lose scene and menu to play again etc.
            SceneManager.LoadScene(7);
        }
    }
}
