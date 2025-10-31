using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class background : MonoBehaviour
{
    public GameObject[] backgrounds;
    private GameObject currentBackground;
    public bool world2=false;
    public static int n=0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        updatingBackground();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if(!world2 && (scene.name == "Level6" || scene.buildIndex > SceneUtility.GetBuildIndexByScenePath("Assets/Scenes/SecondWorld/Level6.unity")))
        {
            world2 = true;
            ++n;
            updatingBackground();
        }
    }

    // Update is called once per frame
    
    public void updatingBackground()
    {
        if (n >= backgrounds.Length)
            return;

        //getbuildindex serve para pegar o index da cena só pelo nome
        for (int i = 0; i < backgrounds.Length; ++i)
         backgrounds[i].SetActive(i == n);
        currentBackground = backgrounds[n];
    }
}
