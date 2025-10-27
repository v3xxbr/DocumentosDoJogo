using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour
{
    int initialIndex, finalIndex;
    public static bool[] unlockedLevels;

    GameObject[] Button;
    GameObject summbutton;
    GameObject[] Container;

    public static bool isUnlocked;

    // Start is called before the first frame update
    void Start()
    {
        CreatingButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatingButtons()
    {
        int v = finalIndex - initialIndex;
        Button = new GameObject[v];
        Container = new GameObject[v];

        for (int c = initialIndex; c < finalIndex; ++c)
        {
            if (unlockedLevels[c] && Button[c] == null)
            {
                Button[c] = Instantiate(summbutton, Container[c].transform.position, Quaternion.identity);
            }
        }
    }

    public void EnterLevel()
    {
        
    }
}
