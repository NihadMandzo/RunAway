using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PauseScript : MonoBehaviour
{
   public static bool GameIsPaused = false;
   public GameObject menu;
   public GameObject Player;
   public GameObject userCanvas;
   

   private void Start()
   {
      menu.SetActive(false);
   }

   public void Update()
   {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
         if (GameIsPaused)
         {
            Resume();
         }
         else
         {
            Pause();
         }
      }
   }

   public void Pause()
   {
      Cursor.lockState = CursorLockMode.None;
      menu.SetActive(true);
      Time.timeScale = 1f;
      GameIsPaused = true;
      Player.SetActive(false);
      userCanvas.SetActive(false);
      
   }

   public void Resume()
   {
      Debug.Log("hahahahah");
      menu.SetActive(false);
      Time.timeScale = 1f;
      GameIsPaused = false;
      Cursor.lockState = CursorLockMode.Locked;
      Player.SetActive(true);
      userCanvas.SetActive(true);
   }

   public void MainMenu()
   {
      SceneManager.LoadSceneAsync("Main menu");
   }

   public void Exit()
   {
      Application.Quit();
   }
}
