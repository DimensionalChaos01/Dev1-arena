using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itembehavior : MonoBehaviour
{
    public gamebehavior gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager") .GetComponent<gamebehavior>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Item registered!");
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Item collected!");
            gameManager.Items += 1;
        }
    }
}
