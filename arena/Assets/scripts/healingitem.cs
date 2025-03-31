using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healingitem : MonoBehaviour
{
    public gamebehavior gameManager;
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
            Debug.Log("Healed!");
            gameManager.playerhealth += 5;
        }
    }

    private void FixedUpdate()
    {

    }
}
