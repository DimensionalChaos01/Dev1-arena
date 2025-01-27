using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itembehavior : MonoBehaviour
{
    public gamebehavior gamemanager;

    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<gamebehavior>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "player")
        {
            Destroy(this.transform.parent.gameObject);
            gamemanager.Items += 1;
        }
    }
    // Start is called before the first frame update
}
