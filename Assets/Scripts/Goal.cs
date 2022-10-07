using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public WinOrLose winLoseScript;
    
    private Barrel[] barrels;

    private Crate[] boxes;

    private bool barrelFell;
    private bool boxesFell;

    // Start is called before the first frame update
    public void Start()
    {
        barrels = FindObjectsOfType<Barrel>();
        boxes = FindObjectsOfType<Crate>();

        barrelFell = false;
        boxesFell = false;

    }

    // Update is called once per frame
    void Update()
    {
        boxesFell = true;
        //checks to see if all boxes have fallen, if so, call BoxFell
        for(int i = 0; i < boxes.Length; i++)
        {
            if(boxes[i].hasFallen == false)
            {
                boxesFell = false;
                break;
            }
        }

        //checks if box counter equals length of beox array, which is total number of boxes in that scene
        //if so, call BoxFell
        if(boxesFell)
        {
            BoxFell();
        }

        for(int i = 0; i < barrels.Length; i++)
        {
            //checks all barrels to see if they have fallen
            if(barrels[i].hasFallen == true)
            {
                barrelFell = true;
                break;
            }
        }

        //checks to see if at least one barrel has fallen, if so, player lose a life
        if(barrelFell)
        {
            BarrelFell();
        }
    }

    //Win Condition: Hit all the boxes off the track to win
    //Is called once all the boxes have fallen off the track
    private void BoxFell()
    {
        if( (winLoseScript.levelCounter <= 5) && !(SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByBuildIndex(0))))
        {
            //if player wins a level, they gain a life back
            WinOrLose.numLives++;
            if(winLoseScript.levelCounter == 6) 
            {
                //once all the levels have been cleared, player has won the game
                winLoseScript.WinGame();
                return;
            } 
            //if we haven't won the game, continue to next level
            winLoseScript.levelCounter++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            winLoseScript.winDevice.myAudio.Play();
        }
    }

    //Lose Condition: If any of the barrels fall off the track the player loses
    //Is called if any of the barrels have fallen off the track
    private void BarrelFell()
    {
        if(WinOrLose.numLives > 0)
        {
            //lose a life, reload that level
            WinOrLose.numLives--;
            winLoseScript.loseDevice.myAudio.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(WinOrLose.numLives == 0)
        {
            //once out of lives, player has lost the game
            winLoseScript.LoseGame();
        }
    }
}
