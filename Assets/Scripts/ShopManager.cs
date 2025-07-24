using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject descriptionWindow;

    private void Awake()
    {
        HideShopPanel();
        HideDescriptionWindow();
    }

    public void ShowShopPanel() 
    {
        shopPanel.SetActive(true);
    }

    public void HideShopPanel()
    {
        shopPanel.SetActive(false);
    }

    public void ShowDescriptionWindow()
    {
        descriptionWindow.SetActive(true);
    }

    public void HideDescriptionWindow()
    {
        descriptionWindow.SetActive(false);
    }
}
