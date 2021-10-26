using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSharedUI : MonoBehaviour
{
    #region  SingletonClass: GameSharedUI  
    public static GameSharedUI instance; 

    void Awake()
    {
        if(instance == null)
        {
            instance = this; 
        }
    }

    #endregion

    [SerializeField] TMP_Text[] coinsUIText;

    public static GameSharedUI gsui;

    void Start()
    {
        gsui = this;
        UpdateCoinsUIText();
    }

    void Update()
    {
       
    }

    public void UpdateCoinsUIText()
    {
        for (int i = 0; i < coinsUIText.Length; i++)
        {
            SetCoinsText(coinsUIText[i], GameDataManager.GetCoins());
        }
    }
    void SetCoinsText(TMP_Text textMesh, int value)
    {
        if(value >= 1000)
        {
            textMesh.text = string.Format("{0}.{1}K", (value/1000), GetFirstDigitFromNumber(value%1000));
        }
        else
        {
            textMesh.text = value.ToString();

        }

        int GetFirstDigitFromNumber(int num)
        {
            return int.Parse(num.ToString() [0].ToString());
        }
    }


}
