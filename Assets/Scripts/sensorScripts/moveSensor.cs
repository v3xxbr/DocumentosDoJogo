using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class moveSensor : MonoBehaviour
{
    public event Action started;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Rigidbody2D>().velocity.x != 0)
        {
            started.Invoke();
        }
    }
}
