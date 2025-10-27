using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseMenuobj;
    public GameObject optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startPause(InputAction.CallbackContext value)
    {
        if (!pauseMenuobj.activeSelf)
        {
            pauseMenuobj.SetActive(true);
            Time.timeScale = 0f;
        }

        else
        {
            pauseMenuobj.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Continue()
    {
        pauseMenuobj.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Options()
    {
        if (!optionsMenu.activeSelf)
        {
            optionsMenu.SetActive(true);
        }

        else
        {
            optionsMenu.SetActive(false);
        }
    }

    public void MainManu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
