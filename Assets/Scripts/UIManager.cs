using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsAmountText;

    public void UpdateUI(int value)
    {
        coinsAmountText.text = value.ToString();
    }
}
