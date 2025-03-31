using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapCamera : MonoBehaviour
{
    public Transform player;
    public Camera playercam;
    public bool rotatewithplayer = true;

    // Start is called before the first frame update
    void Start()
    {
        SetPosition();

        SetRotation();
    }

    void LateUpdate()
    {
        if (player != null)
        {
            SetPosition();
            
            if (rotatewithplayer && playercam)
            {
                SetRotation();
            }
        }
    }

    private void SetRotation()
    {
        transform.rotation = Quaternion.Euler(90.0f, playercam.transform.eulerAngles.y, 0.0f);
    }

    private void SetPosition()
    {
        var newPos = player.position;
        newPos.y = transform.position.y;

        transform.position = newPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
