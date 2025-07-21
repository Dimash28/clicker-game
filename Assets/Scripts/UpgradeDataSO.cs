using UnityEngine;

public enum UpgradeType 
{ 
    MoreCoinsPerClick,
    AutoClick,
    DoubleClick
}

[CreateAssetMenu]
public class UpgradeDataSO : ScriptableObject
{
    public string upgradeName;
    [TextArea] public string description;
    public int cost;
    public UpgradeType type;
    public Sprite icon;
}
