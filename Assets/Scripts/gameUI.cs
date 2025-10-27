using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class gameUI : MonoBehaviour
{
    public static gameUI objectt;
    public Animator animtransition;

    public void Awake()
    {
        if (objectt == null)
        {
            objectt = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
