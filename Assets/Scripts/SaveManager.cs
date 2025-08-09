using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private const string COINS_AMOUNT = "coinsAmount";
    private const string POWER_CLICK_LEVEL = "powerClickLevel";
    private const string AUTO_CLICK_LEVEL = "autoClickLevel";
    private const string CLICK_MULTIPLIER_LEVEL = "clickMultiplierLevel";

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
    }

    public void SaveCoinsAmount(int coinsAmount) 
    {
        PlayerPrefs.SetInt(COINS_AMOUNT, coinsAmount);
        PlayerPrefs.Save();
    }

    public void SavePowerClickUpgradeLevel(int powerClickLevel) 
    {
        PlayerPrefs.SetInt(POWER_CLICK_LEVEL, powerClickLevel);
        PlayerPrefs.Save();
    }

    public void SaveAutoClickUpgradeLevel(int autoClickLevel) 
    {
        PlayerPrefs.SetInt(AUTO_CLICK_LEVEL, autoClickLevel);
        PlayerPrefs.Save();
    }

    public void SaveClickMultiplierLevel(int clickMultiplierLevel) 
    {
        PlayerPrefs.SetInt(CLICK_MULTIPLIER_LEVEL, clickMultiplierLevel);
    }

    public int LoadCoinsAmount() 
    {
        return PlayerPrefs.GetInt(COINS_AMOUNT, 0);
    }

    public void LoadPowerClickUpgradeLevel(out int powerClickLevel) 
    {
        powerClickLevel = PlayerPrefs.GetInt(POWER_CLICK_LEVEL, -1);
    }

    public void LoadAutoClickUpgradeLevel(out int autoClickLevel) 
    {
        autoClickLevel = PlayerPrefs.GetInt(AUTO_CLICK_LEVEL, -1);
    }
    public void LoadClickMultiplierUpgradeLevel(out int clickMultiplierLevel)
    {
        clickMultiplierLevel = PlayerPrefs.GetInt(CLICK_MULTIPLIER_LEVEL, -1);
    }
}
