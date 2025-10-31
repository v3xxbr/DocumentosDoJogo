using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class gameUI : MonoBehaviour
{
    public static gameUI objectt;
    public Animator animtransition;
    GameObject pauseMenu;

    public void Awake()
    {
        if (objectt != null && objectt != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        objectt = this;
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
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            Hide();
        }
    }

    public void Hide()
    {
        background bg = FindObjectOfType<background>();

        foreach (Transform childElements in gameObject.transform)
        {
            childElements.gameObject.SetActive(false);
        }
    }
}
