using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [Header("Upgrade Buttons")]
    public GameObject[] perSecondUpgrade;
    public GameObject[] clickValueUpgrade;


    [Header("Upgrade Prices")]
    public int[] perSecondPrices;
    public int[] clickValuePrices;

    [Header("Upgrade Amounts")]
    public int[] perSecondIncrease;
    public int[] clickValueIncrease;


    private void Update()
    {
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

    public void ClickValueUpgrade(int indexRef)
    {
        ScoreManager.score -= clickValuePrices[indexRef];
        Click.clickValue += clickValueIncrease[indexRef];
        clickValuePrices[indexRef] += clickValuePrices[indexRef];
        ScoreManager.Increase();
    }

    public void PerSecondUpgrade(int indexRef)
    {
        ScoreManager.score -= perSecondPrices[indexRef];
        Click.perSecondValue += perSecondIncrease[indexRef];
        perSecondPrices[indexRef] += perSecondPrices[indexRef];
        ScoreManager.Increase();
    }

}
