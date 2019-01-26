using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHUDController : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.anyKeyDown) LoadMainScene();
    }

    void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}
