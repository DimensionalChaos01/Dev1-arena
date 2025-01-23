using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public Vector2 turn;
    public float jumpspeed;

    private float yspeed;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * 0.25f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * 0.25f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * 0.25f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 0.25f);
        }

        yspeed += Physics.gravity.y * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            yspeed = jumpspeed;
        }

        turn.x += Input.GetAxis("Mouse X");
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
