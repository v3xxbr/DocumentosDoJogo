using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class button : MonoBehaviour
{
    public event Action pressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            pressed.Invoke();
        }
    }
}
