using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHUDController : MonoBehaviour
{
    
    private Button startGameButton;

    void Start()
    {
        startGameButton = transform.Find("StartGameButton").GetComponent<Button>();
        startGameButton.onClick.AddListener(LoadMainScene);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.JoystickButton0)) LoadMainScene();
    }

    void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}
