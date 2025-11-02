using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class mainMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject tutorialImage;
    public GameObject creditsImage;

    [Header("Objects")]
    GameObject Biribo;
    public GameObject target;
    public GameObject Lava;

    private void Start()
    {
        gameUI exisUI = FindObjectOfType<gameUI>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (exisUI != null)
        {
            Destroy(exisUI);
        }
    }

    public void Play()
    {
        StartCoroutine(shortCutscene());
    }

    IEnumerator shortCutscene()
    {
        Biribo = GameObject.FindGameObjectWithTag("Player");
        Biribo.GetComponent<Rigidbody2D>().gravityScale = 3;

        yield return new WaitForSeconds(0.9f);
        Destroy(Biribo);

        while(target.transform.position.y - Lava.transform.position.y > 0.1f)
        {
            Lava.transform.position = Vector2.Lerp(Lava.transform.position, target.transform.position, 2f * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("LevelSelection");
    }

    public void Tutorial()
    {
        if(!creditsImage.activeSelf)
            tutorialImage.SetActive(true);
    }

    public void Credits()
    {
        if(!tutorialImage.activeSelf)
            creditsImage.SetActive(true);
    }

    public void Panels()
    {
        tutorialImage.SetActive(false);
        creditsImage.SetActive(false);

        EventSystem ev = EventSystem.current; 
        ev.SetSelectedGameObject(ev.firstSelectedGameObject);
    }

    public void NewGame()
    {
        for (int k = 1; k < levelSelect.levelQuant + 1; ++k)
            PlayerPrefs.DeleteKey("Level"+k+"Unlocked");

        PlayerPrefs.SetInt("Level1Unlocked", 1);
        PlayerPrefs.Save();

        Debug.Log("Progresso Resetado!");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
