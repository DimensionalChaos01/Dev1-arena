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
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("!");
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Jetpack Equiped!");
            gameManager.jetpack += 1;
            playermove.jetpack += 1;
        }
    }

    private void FixedUpdate()
    {

    }
}