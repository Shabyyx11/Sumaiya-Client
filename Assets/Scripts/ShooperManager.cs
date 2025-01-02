using System;
using UnityEngine;
using TMPro;

public class ShooperManager : MonoBehaviour
{
   public static ShooperManager Instance { get; private set; } 

    public TMP_Text ShooperText;
    public int ShooperCount { get; private set; } 

    public event Action<int> OnShooperCountChanged; 

    private const string ShooperKey = "ShooperKey"; 

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
        LoadshooperData(); 
        UpdateShooperUI();
    }

    public void AddShoopers(int amount)
    {
        ShooperCount += amount;
        SaveShooperData(); 
        OnShooperCountChanged?.Invoke(ShooperCount);
        UpdateShooperUI();
    }

    private void UpdateShooperUI()
    {
        if (ShooperText != null)
        {
            ShooperText.text = ShooperCount.ToString();
        }
    }

    private void SaveShooperData()
    {
        PlayerPrefs.SetInt(ShooperKey, ShooperCount);
        PlayerPrefs.Save();
    }

    private void LoadshooperData()
    {
        ShooperCount = PlayerPrefs.GetInt(ShooperKey, 0); 
    }
}
