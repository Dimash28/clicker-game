using System;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    private int coinsAmount;

    private void Awake()
    {
        coinsAmount = SaveManager.Instance.LoadCoinsAmount();
    }

    public void AddCoin(int value)
    {
        coinsAmount += value;
        SaveManager.Instance.SaveCoinsAmount(coinsAmount);
    }

    public int GetCoinsAmount() 
    {
        return coinsAmount;
    }

    public void SpendCoins(int value) 
    {
        if (coinsAmount >= value) 
        {
            coinsAmount -= value;
            SaveManager.Instance.SaveCoinsAmount(coinsAmount);
        }
    }

    public void SetCoinsAmount(int value) 
    {
        coinsAmount = value;
        SaveManager.Instance.SaveCoinsAmount(coinsAmount);
    }
}
