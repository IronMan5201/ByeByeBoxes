using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDevice : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource myAudio;
    private static GameObject instance;
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

        myAudio = gameObject.GetComponent<AudioSource>();
    }
}
