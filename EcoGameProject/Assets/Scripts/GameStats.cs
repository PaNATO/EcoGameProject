using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{
    public static GameStats GameStatsInstance;
    public void Awake()
    {
        if (GameStatsInstance == null)
            GameStatsInstance = this;
        else
            Destroy(gameObject);
    }
    GameObject GeneralStatsPolandObject;
    GameObject CitiesNamesObject;
    GameObject CitiesStatsPolandObject;
    [SerializeField] Transform StatsPanel;
    [SerializeField] Transform StatsScrollView;
    [SerializeField] Text CompaniesAmmount;
    [SerializeField] Text CompaniesBought;
    public void OpenStats()
    {
        StatsPanel.gameObject.SetActive(true);
    }
    public void CloseStats()
    {
        StatsPanel.gameObject.SetActive(false);
    }
    public void CountryNamesBind()
    {
        CitiesNamesObject = StatsScrollView.GetChild(0).GetChild(1).gameObject;
        CitiesNamesObject.transform.GetComponent<Text>().text = "Poland";
        //CitiesNamesObject.transform.GetChild(0).GetComponent<Text>().text = CountryRelatives.CountryRelativesInstance.c
    }
    public void CitiesProgress()
    {
        //Progres in cities and progress bar!!
        CitiesStatsPolandObject = StatsScrollView.GetChild(0).GetChild(2).gameObject;
    }
    public void NegativeMoneyCheck()
    {
        if(GamePlay.GamePlayInstance.Player.MAmmountPoland < 0)
        {
            GamePlay.GamePlayInstance.Player.PlayerBiggestDebtPoland = GamePlay.GamePlayInstance.Player.MAmmountPoland;
        }
    }
    public void PolandStats()
    {
        NegativeMoneyCheck();
        GeneralStatsPolandObject = StatsScrollView.GetChild(0).GetChild(4).gameObject;
        GeneralStatsPolandObject.transform.GetChild(5).GetComponent<Text>().text = GamePlay.GamePlayInstance.Player.PlayerTotalEarningPoland.ToString("N0") + "zł";
        GeneralStatsPolandObject.transform.GetChild(6).GetComponent<Text>().text = GamePlay.GamePlayInstance.Player.PlayerBiggestDebtPoland.ToString("N0") + "zł";
        GeneralStatsPolandObject.transform.GetChild(7).GetComponent<Text>().text = GamePlay.GamePlayInstance.Player.PlayerClicksCountPoland.ToString("N0");
        GeneralStatsPolandObject.transform.GetChild(8).GetComponent<Text>().text = GamePlay.GamePlayInstance.Player.PlayerBiggestFeePoland.ToString("N0") + "zł";
        GeneralStatsPolandObject.transform.GetChild(9).GetComponent<Text>().text = GamePlay.GamePlayInstance.Player.PlayerMostExpCompanyPoland.ToString("N0") + "zł";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountryNamesBind();
        PolandStats();
        CompaniesAmmount.text = GamePlay.GamePlayInstance.Player.CompaniesAmmount.ToString();
        CompaniesBought.text = GamePlay.GamePlayInstance.Player.CompaniesBought.ToString()+"/";
    }
}
