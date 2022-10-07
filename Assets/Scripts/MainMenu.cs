using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //When play button is clicked on main menu, it loads scene in build index 1 which is the first level
        SceneManager.LoadScene(1);
    }

    public void StartMenu()
    {
        //when a button calls this on click, go to main menu, which is build index 0
        SceneManager.LoadScene(0);
    }
}
