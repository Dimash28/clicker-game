using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionWindowManager : MonoBehaviour
{
    [SerializeField] private UpgradeManager upgradeManager;

    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI priceValue;

    public void UpdateDescriptionUI(UpgradeDataSO upgradeDataSO, int level) 
    {
        description.text = upgradeDataSO.description;
        priceValue.text = upgradeDataSO.upgradeLevelDataList[level].price.ToString();
    }

    public void UpdateSelectedUpgradeDataSO(UpgradeDataSO upgradeDataSO, int level) 
    {
        upgradeManager.SelectUpgrade(upgradeDataSO, level);
    }
}
