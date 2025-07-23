using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionWindowManager : MonoBehaviour
{
    [SerializeField] private ClickerManager clickerManager;

    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI priceValue;

    public void UpdateDescriptionUI(UpgradeDataSO upgradeDataSO, int level) 
    {
        description.text = upgradeDataSO.description;
        priceValue.text = upgradeDataSO.upgradeLevelData[level].price.ToString();
    }

    public void UpdateSelectedUpgradeDataSO(UpgradeDataSO upgradeDataSO, int level) 
    {
        clickerManager.SetSelectedUpgradeDataSO(upgradeDataSO);
        clickerManager.SetCurrentUpgradeLevel(level);
    }
}
