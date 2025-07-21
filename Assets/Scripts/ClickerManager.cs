using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsAmountText;

    private int coinsAmount = 0;

    public void AddCoin()
    {
        coinsAmount++;

        UpdateUI();
    }

    private void UpdateUI()
    {
        coinsAmountText.text = coinsAmount.ToString();
    }
}
