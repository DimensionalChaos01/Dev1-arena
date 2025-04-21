using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jetpackitem : MonoBehaviour
{
    public gamebehavior gameManager;
    public playermove playermove;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gamebehavior>();
        if (gameManager != null)
        {
            Debug.Log("gameManager successfully assigned.");
        }
        else
        {
            Debug.LogError("Failed to find GameManager or gamebehavior component.");
        }

        GameObject playerObject = GameObject.Find("Player");
        if (playerObject != null)
        {
            playermove = playerObject.GetComponent<playermove>();
            if (playermove != null)
            {
                Debug.Log("playermove successfully assigned.");
            }
            else
            {
                Debug.LogError("Failed to find playermove component on Player GameObject.");
            }
        }
        else
        {
            Debug.LogError("Failed to find Player GameObject.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("D");
        if (collision.gameObject.name == "Player")
        {
            GetComponent<AudioSource>().Play();
            Destroy(this.transform.gameObject);
            Debug.Log("Jetpack Equipped!");

            if (gameManager != null)
            {
                gameManager.jetpack += 1;
            }
            else
            {
                Debug.LogError("gameManager reference is null! Cannot update jetpack.");
            }

            if (playermove != null)
            {
                playermove.jetpack += 1;
            }
            else
            {
                Debug.LogError("playermove reference is null! Cannot update jetpack.");
            }
        }
    }

    private void FixedUpdate()
    {

    }
}