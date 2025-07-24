using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType 
{ 
    MoreCoinsPerClick,
    AutoClick,
    ClickMultiplier
}

[CreateAssetMenu]
public class UpgradeDataSO : ScriptableObject
{
    public string upgradeName;
    [TextArea] public string description;
    public UpgradeType type;
    public List<UpgradeLevelData> upgradeLevelDataList = new List<UpgradeLevelData>();
    public int level;
    public Sprite icon;
}
