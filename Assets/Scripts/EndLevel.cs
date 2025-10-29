using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    int currentMoment;
    [SerializeField] GameObject UIprefab; 
    [SerializeField] float transitionTime = 1f;

    void Start()
    {
        gameUI.createUI(UIprefab);
        currentMoment = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(loadNewLevel(currentMoment + 1));
        }
    }

    IEnumerator loadNewLevel(int m)
    {
        background currentbg = FindObjectOfType<background>();

        Animator anim = gameUI.objectt.animtransition;

        anim.SetBool("start", true);
        yield return new WaitForSeconds(transitionTime);

        if (background.level2 == false)
            currentbg.GetComponent<background>().updatingBackground();

        SceneManager.LoadScene(m);
        anim.SetBool("start", false);
    }
}
