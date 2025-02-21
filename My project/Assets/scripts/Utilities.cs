using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class Utilities
{

    
    public static int playerDeaths = 0;

    public static string UpdateDeathCount(out int countReference)
    {
        countReference = 1;
        return "Next time you will be at " + countReference + " Deaths!";
    }

    public static void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;

        Debug.Log("Player deaths:" + playerDeaths);
        string message = UpdateDeathCount(out playerDeaths);
        Debug.Log("Player Deaths:" + playerDeaths);
    }

    public static bool RestartLevel(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
        Time.timeScale = 1.0f;

        return true;
    }
}