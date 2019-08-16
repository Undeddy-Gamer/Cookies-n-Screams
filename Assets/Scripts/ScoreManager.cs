using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public static float score;
    public static Text scoreDisplay;
    //public float timer;


    private void Start()
    {
        scoreDisplay = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();

        InvokeRepeating("Timer", 1, 0.01f);
    }

    private void Timer()
    {
        score += (float)Click.perSecondValue / 100;
        Increase();

        
    }



    public static void Increase()
    {
        scoreDisplay.text = "Score: " + System.Math.Round(score, 0);
    }
}
