using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class levelSelect : MonoBehaviour
{
    public static int levelQuant=10;
    public Transform world1cont, world2cont;

    bool isWorld1=true;

    public Button changeWorldBtn;
    public GameObject btnPrefab;

    [SerializeField] Transform[] targets;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Preparing());
    }

    IEnumerator Preparing()
    {
        yield return new WaitForEndOfFrame();
        InstanceButtons();
    }

    // Update is called once per frame

    void InstanceButtons()
    {
        if (btnPrefab == null) return;

        for (int j = 1; j < levelQuant+1; ++j)
        {
            int confid = (j==1) ? 1:0;
            string levelName = "Level" + j;

            Transform container = j >= 6 ? world2cont : world1cont;
            GameObject but = Instantiate(btnPrefab, container);

            if (j<targets.Length+1)
                but.GetComponent<RectTransform>().anchoredPosition = targets[j-1].GetComponent<RectTransform>().anchoredPosition;
            else
                but.GetComponent<RectTransform>().anchoredPosition = targets[j-6].GetComponent<RectTransform>().anchoredPosition;

            if (j == 1)
                EventSystem.current.SetSelectedGameObject(but);

            //PEGA a int que está contida no prefs e verifica se a int retirada vale 1
            bool unlocked = (PlayerPrefs.GetInt(levelName + "Unlocked", confid) == 1);

            //Verifica se é interativo com base na variável que checa se o status é 1 ou 0
            but.GetComponent<UnityEngine.UI.Button>().interactable = unlocked;

            //Lambdas guardam variáveis, não valores, assim, caso 'levelName' fosse usado diretamente, por ser um valor variável, a Lambda só leria o último
            string currentName = levelName;
            Button btn = but.GetComponent<Button>();
            btn.onClick.AddListener(delegate { LoadLevel(currentName); });
        }
    }

    void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ChangeWorld()
    {
       isWorld1 = !isWorld1;

        world1cont.gameObject.SetActive(isWorld1);
        world2cont.gameObject.SetActive(!isWorld1);
    }
}
