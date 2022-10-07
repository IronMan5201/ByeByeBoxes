using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTrigger : MonoBehaviour
{
    public WinOrLose winLoseScript;
    
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -50.0f)
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
}
