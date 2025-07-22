using TMPro;
using UnityEngine;

public class DescriptionWindowManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI priceValue;

    public void UpdateDescriptionUI(UpgradeDataSO upgradeDataSO, int level) 
    {
        description.text = upgradeDataSO.description;
        priceValue.text = upgradeDataSO.upgradeLevelData[level].price.ToString();
    }
}
