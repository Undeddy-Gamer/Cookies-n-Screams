using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{

    public static int clickValue;
    public static int perSecondValue;

    private void Start()
    {
        clickValue = 1;
        
    }

    public void ClickerButton()
    {
        ScoreManager.score += clickValue;
        ScoreManager.Increase();
    }

    

}
