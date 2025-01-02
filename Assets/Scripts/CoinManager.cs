using System;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; } 

    public TMP_Text CoinText;
    public int CoinCount { get; private set; } 

    public event Action<int> OnCoinCountChanged; 

    private const string CoinKey = "CoinCount"; 

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;
    }

    void Start()
    {
        LoadCoinData(); 
        UpdateCoinUI();
    }

    public void AddCoins(int amount)
    {
        CoinCount += amount;
        SaveCoinData(); 
        OnCoinCountChanged?.Invoke(CoinCount);
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        if (CoinText != null)
        {
            CoinText.text = CoinCount.ToString();
        }
    }

    private void SaveCoinData()
    {
        PlayerPrefs.SetInt(CoinKey, CoinCount);
        PlayerPrefs.Save();
    }

    private void LoadCoinData()
    {
        CoinCount = PlayerPrefs.GetInt(CoinKey, 0); 
    }
}
