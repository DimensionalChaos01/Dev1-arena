using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUi;
    public bool isPaused = false;

    // Update is called once per frame
    void Update()
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

            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
        }
    }

    public void Resume()
    {
        Debug.Log("Resume button clicked!");
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        // Hide and lock the cursor when resuming the game
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Reload()
    {
        Debug.Log("Reloading Scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Startgame()
    {
        Debug.Log("Loading Level 1...");
        SceneManager.LoadScene("Level 1");
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    void Pause()
    {
        PauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        // Unlock and show the cursor when the game is paused
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
