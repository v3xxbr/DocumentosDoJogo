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
        if (objectt != null && objectt != this)
        {
            Destroy(gameObject);
            return;
        }

        objectt = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void createUI(GameObject h)
    {
        if (objectt != null)
            return;
        
        //verifica se realmente não há na cena
        objectt = FindObjectOfType<gameUI>();

        if (objectt != null)
        {
            DontDestroyOnLoad(objectt);
            return;
        }

        GameObject obj = Instantiate(h);
        objectt = obj.GetComponent<gameUI>();
        DontDestroyOnLoad(obj);
    }
}
