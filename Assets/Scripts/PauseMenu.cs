using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject backgroundMusic;

    public GameObject infoDisplay;


    //Resume the game from the pause menu
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        infoDisplay.SetActive(true);
        Time.timeScale = 1f;  //set the scale at which time passes to 1, normal rate
        GameIsPaused = false;
        backgroundMusic.GetComponent<AudioSource>().volume += 0.9f;
    }

    //pause the game when the pause button is clicked
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        infoDisplay.SetActive(false);
        Time.timeScale = 0f;  //set the scale at which time passes to 0, frozen, paused
        GameIsPaused = true;
        backgroundMusic.GetComponent<AudioSource>().volume -= 0.9f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(0);  //loads scene from build settings at index 0, which is our main menu
    }

    public bool isPaused()
    {
        return GameIsPaused;
    }
}
