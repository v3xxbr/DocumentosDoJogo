using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class background : MonoBehaviour
{
    public GameObject[] backgrounds;
    private GameObject currentBackground;
    public static bool level2=false;
    public static int n=0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        updatingBackground();
    }

    // Update is called once per frame
    
    public void updatingBackground()
    {
        backgrounds[n].SetActive(true);
        currentBackground = backgrounds[n];

        //getbuildindex serve para pegar o index da cena só pelo nome
        if (SceneManager.GetActiveScene().buildIndex > SceneUtility.GetBuildIndexByScenePath("Assets/Scenes/Level6.unity"))
        {
            ++n;
            level2 = true;
        }
    }
}
