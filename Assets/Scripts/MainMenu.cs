using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI CoinsText;
    public TextMeshProUGUI ShooperText;

    void Start()
    {
        int savedCoins = PlayerPrefs.GetInt("CoinCount", 0);
        UpdateCoinsText(savedCoins);
        int savedShooper = PlayerPrefs.GetInt("ShooperCount", 0);
        UpdateShooperText(savedShooper);
       
    }

    private void UpdateCoinsText(int coinCount)
    {
        if (CoinsText != null)
        {
            CoinsText.text = $"Coins: {coinCount}";
        }
    }
    private void UpdateShooperText(int shooperCount)
    {
        if (ShooperText != null)
        {
            ShooperText.text = $"plastic: {shooperCount}";
        }
    }
}
