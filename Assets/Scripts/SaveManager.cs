using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
    }

    public void SaveCoinsAmount(int coinsAmount) 
    {
        PlayerPrefs.SetInt("coinsAmount", coinsAmount);
        PlayerPrefs.Save();
    }

    public void SavePowerClickUpgradeLevel(int powerClickLevel) 
    {
        PlayerPrefs.SetInt("powerClickLevel", powerClickLevel);
        PlayerPrefs.Save();
    }

    public void SaveAutoClickUpgradeLevel(int autoClickLevel) 
    {
        PlayerPrefs.SetInt("autoClickLevel", autoClickLevel);
        PlayerPrefs.Save();
    }

    public int LoadCoinsAmount() 
    {
        return PlayerPrefs.GetInt("coinsAmount", 0);
    }

    public void LoadPowerClickUpgradeLevel(out int powerClickLevel) 
    {
        powerClickLevel = PlayerPrefs.GetInt("powerClickLevel", -1);
    }

    public void LoadAutoClickUpgradeLevel(out int autoClickLevel) 
    {
        autoClickLevel = PlayerPrefs.GetInt("autoClickLevel", -1);
    }
}
