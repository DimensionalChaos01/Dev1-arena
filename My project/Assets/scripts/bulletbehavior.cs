using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletbehavior : MonoBehaviour
{
    public float onscreendelay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, onscreendelay);
        Debug.Log("a bullet was deleted");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
