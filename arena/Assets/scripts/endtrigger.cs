using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endtrigger : MonoBehaviour
{
    public gamemanager gameManager;
    void OnTriggerEnter ()
    {
        Debug.Log("ending");
        gameManager.completeLevel();
    }
}
