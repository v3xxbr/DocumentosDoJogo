using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class background : MonoBehaviour
{
    public GameObject[] backgrounds;
    [SerializeField]int levelsQuant;
    int n=0;

    // Start is called before the first frame update
    void Start()
    {
        //caso o jogador entre direto pelo LevelSelection
        OnSceneLoad(SceneManager.GetActiveScene(), LoadSceneMode.Single);

        PlayerPrefs.Save();
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    //caso o jogador entre numa fase dinâmicamente (sem o LevelSelection)
    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.StartsWith("Level")){

            int currentNumLevel;
            if(int.TryParse(scene.name.Replace("Level", ""), out currentNumLevel))
            {
                n = (currentNumLevel - 1) / 5;

                if (currentNumLevel >= 6)
                {
                    PlayerPrefs.SetInt("world2Free", 1);
                    PlayerPrefs.Save();
                }
            }
        }

        updatingBackground();
    }
    
    public void updatingBackground()
    {
        //getbuildindex serve para pegar o index da cena só pelo nome
        for (int i = 0; i < backgrounds.Length; ++i)
            if(backgrounds[i]!=null)
                backgrounds[i].SetActive(i == n);
    }
}
