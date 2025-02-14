using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string _scene;
    public void PlayGame()
    {
        if (_scene.Contains("Level1"))
        {
            SceneManager.LoadSceneAsync("Level1");
        }
        else
        {
            SceneManager.LoadSceneAsync(_scene);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenuFunc()
    {
        SceneManager.LoadSceneAsync("Main menu");
    }

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
            _scene = "Level1";
    }
}
