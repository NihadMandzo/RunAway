using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMEnu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("heheheh");
        SceneManager.LoadSceneAsync("ZombieTesting");
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
  
}
