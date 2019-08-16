using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{

    public static int clickValue;
    public static int perSecondValue;
    public Player player;
    private void Start()
    {
        clickValue = 1;
        
    }
    public void ClickerButton()
    {
        ScoreManager.score += clickValue;
        ScoreManager.Increase();
        player.AddMonsterForce(player.acceleration);
    }
}
