using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmbienceDevice : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource myAudio;
    public WinOrLose game;
    private static GameObject instance;
    private int thisLevel;
    void Start()
    {
        thisLevel = game.levelCounter;

        DontDestroyOnLoad(gameObject);
        if(instance == null)
        {
            instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }

        myAudio = gameObject.GetComponent<AudioSource>();
        game = GameObject.FindObjectOfType<WinOrLose>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the scene has changed to the next level, destroy the background music, so it can change
        if( (game.levelCounter > thisLevel) || (WinOrLose.numLives == 0))
        {
            Destroy(gameObject);
        }

        //if the active scene is the main menu, destroy the background music, so it can become the menu music
        if(SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByBuildIndex(0)))
        {
            Destroy(gameObject);
        }

    }
}
