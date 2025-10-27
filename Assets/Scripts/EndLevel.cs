using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    int currentMoment;
    [SerializeField]float transitionTime = 1f;

    void Start()
    {
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
        Animator anim = gameUI.objectt.animtransition;
        anim.SetBool("start", true);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(m);
        anim.SetBool("start", false);
    }
}
