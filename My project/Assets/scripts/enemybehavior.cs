using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "player")
        {
            Debug.Log("player detected - ATTACK!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "player")
        {
            Debug.Log("player out of range - Resume Patrol");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
