using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hasFallen;
    public void Start()
    {
        hasFallen = false;
    }

    // Update is called once per frame
    void Update()
    {
        //checks the barrel to see if it fell off the track
        //if so, mark hasFallen to true
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
