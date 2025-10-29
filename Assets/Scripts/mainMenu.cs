using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class mainMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject tutorialImage;
    public GameObject creditsImage;

    [Header("Objects")]
    GameObject Biribo;
    public GameObject target;
    public GameObject Lava;

    public void Play()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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

        yield return new WaitForSeconds(2.1f);
        //SceneManager.LoadScene(1);
        SceneManager.LoadScene(2);
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
        if (tutorialImage.activeSelf || creditsImage.activeSelf)
        {
            tutorialImage.SetActive(false);
            creditsImage.SetActive(false);
        }
        else
        {
            tutorialImage.SetActive(true);
            creditsImage.SetActive(true);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
