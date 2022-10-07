using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    public GameObject FirstPersonCamera;

    // Update is called once per frame
    void Update()
    {

        //if 'C' Key was pressed, change from first person to third person
        if(Input.GetKeyDown(KeyCode.C))
        {
            FirstPersonCamera.GetComponent<Camera>().enabled = !(FirstPersonCamera.GetComponent<Camera>().enabled);
            this.GetComponent<Camera>().enabled = !(this.GetComponent<Camera>().enabled);
        }
    }
}
