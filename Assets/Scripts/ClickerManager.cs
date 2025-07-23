using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class ClickerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsAmountText;

    private UpgradeDataSO selectedUpgradeDataSO;

    private int currentLevel;

    private int addValue = 1;

    private int coinsAmount = 0;

    public void AddCoin()
    {
        coinsAmount += addValue;

        UpdateUI();
    }

    public void BuyUpgrade() 
    {
        if (coinsAmount >= selectedUpgradeDataSO.upgradeLevelData[currentLevel].price
            && selectedUpgradeDataSO.type == UpgradeType.MoreCoinsPerClick
            && selectedUpgradeDataSO.upgradeLevelData[currentLevel].isSold == false) 
        {
            coinsAmount -= selectedUpgradeDataSO.upgradeLevelData[currentLevel].price;
            UpdateUI();
            addValue = selectedUpgradeDataSO.upgradeLevelData[currentLevel].value;
            selectedUpgradeDataSO.upgradeLevelData[currentLevel].isSold = true;
        }
    }

    private void UpdateUI()
    {
        coinsAmountText.text = coinsAmount.ToString();
    }

    public void SetSelectedUpgradeDataSO(UpgradeDataSO upgradeDataSO) 
    {
        selectedUpgradeDataSO = upgradeDataSO;
    }

    public void SetCurrentUpgradeLevel(int level) 
    {
        currentLevel = level;
    }
}
