using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePurchaseManager : MonoBehaviour
{
    public void RemoveAds()
    {
        if(PlayerPrefs.HasKey("ads") == false)
        {
            PlayerPrefs.SetInt("ads", 0);
        }
    }
    public void Get500Coins()
    {
        GameDataManager.AddCoins(500);
        GameSharedUI.gsui.UpdateCoinsUIText();
    }
    public void Get1000Coins()
    {
        GameDataManager.AddCoins(1000);
        GameSharedUI.gsui.UpdateCoinsUIText();
    }
    public void Get5000Coins()
    {
        GameDataManager.AddCoins(5000);
        GameSharedUI.gsui.UpdateCoinsUIText();
    }
    public void Get10000Coins()
    {
        GameDataManager.AddCoins(10000);
        GameSharedUI.gsui.UpdateCoinsUIText();
    }
}
