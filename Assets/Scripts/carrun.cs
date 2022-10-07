using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrun : MonoBehaviour
{
    public float horizontalInput = 0;
    public float verticalInput = 0;

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * 100.0f, Space.World);

        //if Left shift is pressed, increase speed
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 50.0f;
        }
        else
        {
            speed = 20.0f;
        }
    }
}
