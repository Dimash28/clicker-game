using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private ClickerManager clickerManager;   
    [SerializeField] private UIManager uiManager;
    [SerializeField] private CurrencyManager currencyManager;

    public event EventHandler OnUpgradeApplied;

    [SerializeField] private List<UpgradeDataSO> upgradeDataSOList;

    private UpgradeDataSO selectedUpgradeDataSO;
    private int currentLevelIndex;
    private int upgradeLevel = -1;
    private int currentAutoClickLevel = -1;
    private int currentPowerClickLevel = -1;
    private int currentClickMultiplierLevel = -1;

    private void Start()
    {
        SaveManager.Instance.LoadPowerClickUpgradeLevel(out currentPowerClickLevel);
        SaveManager.Instance.LoadAutoClickUpgradeLevel(out currentAutoClickLevel);
        SaveManager.Instance.LoadClickMultiplierUpgradeLevel(out currentClickMultiplierLevel);

        foreach (UpgradeDataSO upgradeDataSO in upgradeDataSOList) 
        {
            if (upgradeDataSO.type == UpgradeType.MoreCoinsPerClick && currentPowerClickLevel >= 0)
            {
                var levelData = upgradeDataSO.upgradeLevelDataList[currentPowerClickLevel];
                clickerManager.SetAddValue(levelData.value);
            }
            else if (upgradeDataSO.type == UpgradeType.AutoClick && currentAutoClickLevel >= 0)
            {
                var levelData = upgradeDataSO.upgradeLevelDataList[currentAutoClickLevel];
                clickerManager.SetAutoClickValue(levelData.value);
                clickerManager.StartAutoClick();
            }
            else if (upgradeDataSO.type == UpgradeType.ClickMultiplier && currentClickMultiplierLevel >= 0)
            {
                var levelData = upgradeDataSO.upgradeLevelDataList[currentClickMultiplierLevel];
                clickerManager.SetClickMultiplier(levelData.value);
            }
        }
    }

    private void ApplyUpgrade(UpgradeLevelData levelData)
    {
        switch (selectedUpgradeDataSO.type) 
        {
            case UpgradeType.MoreCoinsPerClick:
                clickerManager.SetAddValue(levelData.value);
                currentPowerClickLevel = levelData.levelNumber;

                SaveManager.Instance.SavePowerClickUpgradeLevel(currentPowerClickLevel);
                break;
            case UpgradeType.AutoClick:
                clickerManager.SetAutoClickValue(levelData.value);
                currentAutoClickLevel = levelData.levelNumber;
                clickerManager.StartAutoClick();

                SaveManager.Instance.SaveAutoClickUpgradeLevel(currentAutoClickLevel);
                break;
            case UpgradeType.ClickMultiplier:
                clickerManager.SetClickMultiplier(levelData.value);
                currentClickMultiplierLevel = levelData.levelNumber;

                SaveManager.Instance.SaveClickMultiplierLevel(currentClickMultiplierLevel);
                break;
        }
    }

    public void SelectUpgrade(UpgradeDataSO upgradeDataSO, int level)
    {
        selectedUpgradeDataSO = upgradeDataSO;
        currentLevelIndex = level;
    }

    public void BuyUpgrade()
    {
        var levelData = selectedUpgradeDataSO.upgradeLevelDataList[currentLevelIndex];

        switch (selectedUpgradeDataSO.type)
        {
            case UpgradeType.MoreCoinsPerClick:
                upgradeLevel = currentPowerClickLevel;
                break;
            case UpgradeType.AutoClick:
                upgradeLevel = currentAutoClickLevel;
                break;
            case UpgradeType.ClickMultiplier:
                upgradeLevel = currentClickMultiplierLevel;
                break;
        }

        Debug.Log(upgradeLevel);
        Debug.Log(levelData.levelNumber);
        Debug.Log(levelData.levelNumber - upgradeLevel);

        if (currencyManager.GetCoinsAmount() >= levelData.price && levelData.levelNumber - upgradeLevel == 1)
        {
            currencyManager.SpendCoins(levelData.price);
            OnUpgradeApplied?.Invoke(this, EventArgs.Empty);

            ApplyUpgrade(levelData);
        }
    }

    public void ResetUpgrades() 
    {
        currentAutoClickLevel = -1;
        currentPowerClickLevel = -1;
        currentClickMultiplierLevel = -1;

        SaveManager.Instance.SavePowerClickUpgradeLevel(currentPowerClickLevel);
        SaveManager.Instance.SaveAutoClickUpgradeLevel(currentAutoClickLevel);
        SaveManager.Instance.SaveClickMultiplierLevel(currentClickMultiplierLevel);
    }
}
