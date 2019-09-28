using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public static float score; //Float containing the score
    public static Text scoreDisplay; //Text desplay of the score

    private void Start()
    {
        //On start find the gameobject with the score and set it into the refrence scoreDisplay
        scoreDisplay = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        //Invoke the void timer every 0.01 seconds
        InvokeRepeating("Timer", 1, 0.01f);
    }

    private void Timer()
    {
        //Add the click persecond value divided by 100 to the score.
        score += (float)Click.perSecondValue / 100;
        //Run void Increase to update the score
        Increase();
    }

    public static void Increase()
    {
        //Set the text on the screen to say 'Screams: ' and the score
        scoreDisplay.text = "Screams: " + System.Math.Round(score, 0);
    }
}
