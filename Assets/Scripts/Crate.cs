using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public bool hasFallen;
    // Start is called before the first frame update
    public void Start()
    {
        hasFallen = false;
    }

    // Update is called once per frame
    void Update()
    {
        //checks the box to see if it fell off the track
        //if so, call private BoxFell function to increase number of fallen boxes
        if(transform.position.y < -10.0f)
        {
            hasFallen = true;
        }
        else
        {
            hasFallen = false;
        }
    }
}
