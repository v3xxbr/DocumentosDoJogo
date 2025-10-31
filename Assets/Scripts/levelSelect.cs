using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class levelSelect : MonoBehaviour
{
    [SerializeField]int levelQuant=0;
    public Transform container;
    public GameObject btnPrefab;

    [SerializeField] Transform[] targets;

    // Start is called before the first frame update
    void Start()
    {
        InstanceButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstanceButtons()
    {
        for (int j = 1; j < (levelQuant / 2) + 1; ++j)
        {
            int confid = (j==1) ? 1:0;

            string levelName = "Level" + j;
            GameObject but = Instantiate(btnPrefab, container);
            but.transform.position = targets[j - 1].position;

            if (j == 1)
                EventSystem.current.SetSelectedGameObject(but);

            //PEGA a int que est� contida no prefs
            int status = PlayerPrefs.GetInt(levelName + "Unlocked", confid);

            //verifica se a int retirada em status vale 1
            bool unlocked = (status == 1);

            //Verifica se � interativo com base na vari�vel que checa se o status � 1 ou 0
            but.GetComponent<UnityEngine.UI.Button>().interactable = unlocked;

            //Lambdas guardam vari�veis, n�o valores, assim, caso 'levelName' fosse usado diretamente, por ser um valor vari�vel, a Lambda s� leria o �ltimo
            string currentName = levelName;
            Button btn = but.GetComponent<Button>();
            btn.onClick.AddListener(() => { SceneManager.LoadScene(currentName); });
        }
    }
}
