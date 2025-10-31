using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.EventSystems;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseMenuobj;
    public GameObject optionsMenu;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startPause(InputAction.CallbackContext value)
    {
        if (!value.performed) return;
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        if (!pauseMenuobj.activeSelf)
        {
            pauseMenuobj.SetActive(true);
            Time.timeScale = 0f;
            player.GetComponent<PlayerInput>().actions.Disable();
        }

        else
        {
            pauseMenuobj.SetActive(false);
            Time.timeScale = 1f;
            player.GetComponent<PlayerInput>().actions.Enable();
        }
    }

    public void Continue()
    {
        pauseMenuobj.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponent<PlayerInput>().actions.Enable();
    }

    public void Options()
    {
        optionsMenu.SetActive(!optionsMenu.activeSelf);
    }

    public void MainManu()
    {
        gameUI canvasUI = GameObject.FindObjectOfType<gameUI>();
        Destroy(canvasUI.gameObject);

        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
