using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public Vector2 turn;
    public float jumpspeed;
    public float movespeed = 10f;

    public float vinput;
    public float hinput;

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

        vinput = Input.GetAxis("vertical") * movespeed;

        hinput = Input.GetAxis("horizontal") * movespeed;

        this.transform.Translate(Vector3.forward * vinput * Time.deltaTime);

        this.transform.Translate(Vector3.left * hinput * Time.deltaTime);

        turn.x += Input.GetAxis("Mouse X");
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
