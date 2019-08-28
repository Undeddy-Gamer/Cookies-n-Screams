using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public static int clickValue; //The ammount one clikc is worth
    public static int perSecondValue; //How many get added per second
    public Player player; //Refrence to the player script
    private void Start()
    {
        clickValue = 1; //Defualt value for one click
    }
    //Runs on button click
    public void ClickerButton()
    {
        ScoreManager.score += clickValue; //Adds the click value to the main score
        ScoreManager.Increase(); //Increases the value displayed 
        player.AddMonsterForce(player.acceleration); //Adds force to the monster so it moves
    }
}
