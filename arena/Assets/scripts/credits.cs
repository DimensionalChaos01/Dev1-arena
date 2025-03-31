using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("01");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("01");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
