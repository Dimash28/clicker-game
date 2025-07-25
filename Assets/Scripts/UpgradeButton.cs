using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private GameObject soldTemplate;

    [SerializeField] private UpgradeDataSO upgradeDataSO;
    [SerializeField] private DescriptionWindowManager descriptionWindowManager;

    [SerializeField] private int level;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();

        if (button != null && descriptionWindowManager != null && upgradeDataSO != null)
        {
            button.onClick.AddListener(() => descriptionWindowManager.UpdateDescriptionUI(upgradeDataSO,level));
            button.onClick.AddListener(() => descriptionWindowManager.UpdateSelectedUpgradeDataSO(upgradeDataSO, level));
        }
    }
    
    public void ShowSoldTemplate()
    {
        soldTemplate.SetActive(true);
    }
}
