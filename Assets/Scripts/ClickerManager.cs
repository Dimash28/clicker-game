using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Collections;

public class ClickerManager : MonoBehaviour
{
    [SerializeField] private CurrencyManager currencyManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private UpgradeManager upgradeManager;

    private int addValue = 1;

    private int autoClickValue = 0;

    private bool autoClickRunning = false;

    private readonly WaitForSeconds oneSecond = new WaitForSeconds(1);

    private void Start()
    {
        uiManager.UpdateUI(currencyManager.GetCoinsAmount());
        upgradeManager.OnUpgradeApplied += UpgradeManager_OnUpgradeApplied;
    }

    private void UpgradeManager_OnUpgradeApplied(object sender, System.EventArgs e)
    {
        uiManager.UpdateUI(currencyManager.GetCoinsAmount());
    }

    public void MakeClick() 
    {
        currencyManager.AddCoin(addValue);
        uiManager.UpdateUI(currencyManager.GetCoinsAmount());
    }

    public void StartAutoClick() 
    {
        if (!autoClickRunning && autoClickValue > 0)
        {
            autoClickRunning = true;
            StartCoroutine(AutoClickCoroutine());
        }
    }

    private IEnumerator AutoClickCoroutine() 
    {
        while (autoClickRunning)
        {
            currencyManager.AddCoin(autoClickValue);
            uiManager.UpdateUI(currencyManager.GetCoinsAmount());
            yield return oneSecond;
        }
    }

    private void StopAutoClick() 
    {
        autoClickRunning = false;
        StopCoroutine(AutoClickCoroutine());
    }

    public int GetAddValue()
    {
        return addValue;
    }

    public int GetAutoClickValue()
    {
        return autoClickValue;
    }

    public void SetAddValue(int value) 
    {
        addValue = value;
    }

    public void SetAutoClickValue(int value)
    {
        autoClickValue = value;
    }

    public void GiveTwoKCoins() 
    {
        currencyManager.AddCoin(2000);
        uiManager.UpdateUI(currencyManager.GetCoinsAmount());
    }

    public void ResetProgress() 
    {
        currencyManager.SetCoinsAmount(0);
        StopAutoClick();
        addValue = 1;
        autoClickValue = 0;
        upgradeManager.ResetUpgrades();
        uiManager.UpdateUI(currencyManager.GetCoinsAmount());
    }
}
