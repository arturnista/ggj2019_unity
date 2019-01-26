using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testecontrole : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("0"))
        //{
        //    Debug.Log("aaaaaah funfou");
        //}
        if (Input.GetKey("joystick button 0"))
        {
            Debug.Log(Input.GetAxis("DpadHorizontal"));
        };
        

    }
}
