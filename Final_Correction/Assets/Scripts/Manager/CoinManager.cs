using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinManager : Singleton<CoinManager>
{
    public int Coins { get; set; }

    private readonly string COINS_KEY = "MyGame_MyCoins_DontCheat";

    private void Start()
    {
        LoadCoins();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            AddCoins(1200);
        }
    }

    public void ResetCoins()
    {
        PlayerPrefs.SetInt(COINS_KEY, 0);
    }

    private void LoadCoins()
    {
        Coins = PlayerPrefs.GetInt(COINS_KEY);
    }

    public int CoinsGetter()
    {
        int current_int;
        current_int = PlayerPrefs.GetInt(COINS_KEY);
        return current_int;
    }

    public void AddCoins(int amount)
    {
        Coins += amount;
        PlayerPrefs.SetInt(COINS_KEY, Coins);
    }

    public void RemoveCoins(int amount)
    {
        Coins -= amount;
        PlayerPrefs.SetInt(COINS_KEY, Coins);
    }

}

