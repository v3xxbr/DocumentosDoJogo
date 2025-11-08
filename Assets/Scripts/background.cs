using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class background : MonoBehaviour
{
    public GameObject[] backgrounds;
    int levelsQuant;
    int n=0;

    [Header("Songs")]
    AudioSource audioSource;
    public AudioClip[] songs;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        if (scene.name == "FinalGame" && audioSource!=null)
            audioSource.Stop();

        if (scene.name.StartsWith("Level")){

            if (audioSource == null || songs == null || songs.Length == 0) return;

            int currentNumLevel;
            if(int.TryParse(scene.name.Replace("Level", ""), out currentNumLevel))
            {
                n = (currentNumLevel - 1) / 5;

                if (audioSource.clip != songs[n] && scene.name != "FinalGame")
                {
                    audioSource.clip = songs[n];
                    audioSource.loop = true;
                    audioSource.Play();
                }

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
        if (backgrounds == null) return;
        //getbuildindex serve para pegar o index da cena só pelo nome
        for (int i = 0; i < backgrounds.Length; ++i)
            if(backgrounds[i]!=null)
                backgrounds[i].SetActive(i == n);
    }
}
