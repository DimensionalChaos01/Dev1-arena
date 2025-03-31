using UnityEngine.SceneManagement;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    bool gamehasended = false;
    public float restartdelay = 1f;

    public GameObject completelevelUI;

    private void Start()
    {
        completelevelUI.SetActive(false);
    }

    public void completeLevel()
    {
        Debug.Log("Level " + SceneManager.GetActiveScene().name + " complete");
        completelevelUI.SetActive(true);
    }
    public void Endgame()
    {
        if (gamehasended == false)
        {
            gamehasended = true;
            Debug.Log("Game Over");
            Invoke(nameof(Restart), restartdelay);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
