using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class deathCount : MonoBehaviour
{
    public static bool itsover;
    public TMP_Text text_death;
    public static int deathTimes;

    public void Update()
    {
        if (itsover)
        {
            UpdatingText();
            itsover = false;
        }        
    }
    public void UpdatingText(){
        text_death.text = deathTimes.ToString() + "x";
    }
}
