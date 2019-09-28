using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    //Refrences to the buttons
    [Header("Upgrade Buttons")]
    public GameObject[] perSecondUpgrade;
    public GameObject[] clickValueUpgrade;

    //Prices to upgrade clicks and persecond values
    [Header("Upgrade Prices")]
    public int[] perSecondPrices;
    public int[] clickValuePrices;

    //How much each upgrade adds when they are bought
    [Header("Upgrade Amounts")]
    public int[] perSecondIncrease;
    public int[] clickValueIncrease;


    private void Update()
    {
        //For every per second upgrade that can be bought go and check to see if the score is greater than the cost of the upgrade
        for (int i = 0; i < perSecondUpgrade.Length; i++)
        {
            if (ScoreManager.score >= perSecondPrices[i])
            {
                perSecondUpgrade[i].SetActive(true);
            }
            else
            {
                perSecondUpgrade[i].SetActive(false);
            }

        }
        //For every click value upgrade that can be bought go and check to see if the score is greater than the cost of the upgrade
        for (int i = 0; i < clickValueUpgrade.Length; i++)
        {
            if (ScoreManager.score >= clickValuePrices[i])
            {
                clickValueUpgrade[i].SetActive(true);
            }
            else
            {
                clickValueUpgrade[i].SetActive(false);
            }

        }
    }

    //Run on click value upgrade bought
    public void ClickValueUpgrade(int indexRef)
    {
        //Minus the cost from the score
        ScoreManager.score -= clickValuePrices[indexRef];
        //Increases the click value
        Click.clickValue += clickValueIncrease[indexRef];
        //Increases the price of the click value
        clickValuePrices[indexRef] += clickValuePrices[indexRef];
        //Updates the desplayed score
        ScoreManager.Increase();
    }

    //Run on per second score upgrade bought
    public void PerSecondUpgrade(int indexRef)
    {
        //Minus the cost from the score
        ScoreManager.score -= perSecondPrices[indexRef];
        //Increases the per second value
        Click.perSecondValue += perSecondIncrease[indexRef];
        //Increases the price of the per second value
        perSecondPrices[indexRef] += perSecondPrices[indexRef];
        ScoreManager.Increase();
    }

}
