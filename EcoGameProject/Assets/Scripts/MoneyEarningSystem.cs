using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MoneyEarningSystem : MonoBehaviour
{
    //RegionInfo bg = new RegionInfo("bg-BG");
    //--------------------------------------------------------------SerializeFields
    [SerializeField]
    Text MoneyText;
    [SerializeField]
    Text SVMoneyText;
    //--------------------------------------------------------------Variables
    public int MoneyPLNAmount;
    public GameObject[] CurrencySymbolsAssets;
    public string[] CurrencySymbols;
    //--------------------------------------------------------------Class Objects
    public Money MoneyPLNClass = new Money();
    public Currency Currency = new Currency();
    //--------------------------------------------------------------Class instance
    public static MoneyEarningSystem instance;
    //--------------------------------------------------------------Sets up an instacne of GameObject and Destroy when we close program
    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    public void Start()
    {
        Currency.CCreateSymbol(0, "pl-PL", CurrencySymbols);
        Currency.CCreateSymbol(1, "cs-CZ", CurrencySymbols);
        Currency.CCreateSymbol(2, "sk-SK", CurrencySymbols);
        //CurrencySymbols[0] = bg.CurrencySymbol.ToString();
        MoneyText.text = "Money:" + MoneyPLNAmount.ToString();
        SVMoneyText.text = "PLN:" + MoneyPLNAmount.ToString();
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    public void EarnPLNOnClick()
    {
        GamePlay.GamePlayInstance.Player.EarnMoneyOnClick(GamePlay.GamePlayInstance.Poland.CReturnCCurency(), GamePlay.GamePlayInstance.Poland.CReturnCName(), "zł", MoneyText, MapClickedDetection.mapClickedDetectionInstance.Detection());
    }
}
