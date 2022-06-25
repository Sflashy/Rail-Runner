using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject levelFailedUI;
    public GameObject levelSuccessUI;
    private int _diamond;
    public TextMeshProUGUI diamondText;
    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void AddDiamond(int amount)
    {
        _diamond += amount;
        diamondText.text = _diamond.ToString();
    }
    
    public void ShowFailedUI()
    {
        levelFailedUI.SetActive(true);
    }
    
    public void ShowSuccessUI()
    {
        levelSuccessUI.SetActive(true);
    }
}