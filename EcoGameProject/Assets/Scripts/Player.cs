using System;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    [SerializeField]
    public int PlayerPrestige { get; set; }
    public float PlayerNextLvlXp { get; set; }
    public float PlayerNextLvlXpStart { get; set; }
    public float PlayerClickXp { get; set; }
    public float PlayerClickXpTemp { get; set; }
    public long PlayerLvl { get; set; }
    //Player Money In Countries
    public long MAmmountPoland { get; set; }
    public long MAmmountCzechia { get; set; }
    public long MAmmountSlovakia { get; set; }
    public long PlayerClickEarningPoland { get; set; }
    public long PlayerClickEarningCzechRep { get; set; }
    public long PlayerClickEarningSlovakia { get; set; }
    public long PlayerCompanyEarningPoland { get; set; }
    public long PlayerFeePoland { get; set; }
    //Statistics Section
    public long PlayerTotalEarningPoland { get; set; }
    public long PlayerTotalEarningCzech { get; set; }
    public long PlayerTotalEarningSlovakia { get; set; }
    public long PlayerClicksCountPoland { get; set; }
    public long PlayerClicksCountCzech { get; set; }
    public long PlayerClicksCountSlovakia { get; set; }
    public long PlayerBiggestDebtPoland { get; set; }
    public long PlayerBiggestFeePoland { get; set; }
    public long PlayerMostExpCompanyPoland { get; set; }
    public int CompaniesAmmount { get; set; }
    public int CompaniesBought { get; set; }
    //Functionality Section
    public Player()
    {
        this.PlayerPrestige = 0;
        this.PlayerNextLvlXp = 25;
        this.PlayerNextLvlXpStart = 25;
        this.PlayerClickXp = 0;
        this.PlayerClickXpTemp = 100000000; 
        this.PlayerLvl = 1;
        //Money countries
        this.MAmmountPoland = 0;
        this.MAmmountCzechia = 0;
        this.MAmmountSlovakia = 0;
        //Clicks Earn Country
        this.PlayerClickEarningPoland = 1;
        this.PlayerClickEarningCzechRep = 1;
        this.PlayerClickEarningSlovakia = 1;
        //Company Earn Country
        this.PlayerCompanyEarningPoland = 0;
        //Countries Fees
        this.PlayerFeePoland = 0;
        //Stats Earnings Countries
        this.PlayerTotalEarningPoland = 0;
        this.PlayerTotalEarningCzech = 0;
        this.PlayerTotalEarningSlovakia = 0;
        //Stats Clicks Counter
        this.PlayerClicksCountPoland = 0;
        this.PlayerClicksCountCzech = 0;
        this.PlayerClicksCountSlovakia = 0;
        //Stats Debts Countires
        this.PlayerBiggestDebtPoland = 0;
        this.PlayerBiggestFeePoland = 0;
        this.CompaniesBought = 0;
    }
    /*public void EarnXpOnClick(int Xp,Text TextOutput, string OutputText, object Detection)
    {
        if (Detection.ToString() != "" && Input.GetMouseButtonDown(0))
        {
            Xp += 10;
            TextOutput.text = OutputText + Xp.ToString();
        }
    }
    public void LvlUpCheck(int Xp, int ReqiuredXp, int PlayerLvl, Text PlayerXpText, Text PlayerLvlText)
    {
        if(Xp >= ReqiuredXp)
        {
            Xp -= ReqiuredXp;
            PlayerLvl += 1;
            PlayerXpText.text = Xp.ToString();
            PlayerLvlText.text = PlayerLvl.ToString();
        }    
    }*/
    public void EarnZlOnClick(string CName, string CSymbol, Text TextOutput, object Detection, object Country)
    {
        if (Detection.ToString() == CName && Input.GetMouseButtonDown(0) && PlayerPrestige >= Convert.ToInt32(Country))
        {
            MAmmountPoland += PlayerClickEarningPoland;
            PlayerTotalEarningPoland += PlayerClickEarningPoland;
            TextOutput.text = MAmmountPoland.ToString() + CSymbol;
            GamePlay.GamePlayInstance.Player.PlayerClicksCountPoland += 1;
        }
    }
    public void EarnKoronaOnClick(string CName, string CSymbol, Text TextOutput, object Detection, object Country)
    {
        if (Detection.ToString() == CName && Input.GetMouseButtonDown(0) && PlayerPrestige >= Convert.ToInt32(Country))
        {
            MAmmountCzechia += PlayerClickEarningCzechRep;
            PlayerTotalEarningCzech += PlayerClickEarningCzechRep;
            TextOutput.text = MAmmountCzechia.ToString() + CSymbol;
            GamePlay.GamePlayInstance.Player.PlayerClicksCountCzech += 1;
        }
    }
    public void EarnSlovEuroOnClick(string CName, string CSymbol, Text TextOutput, object Detection, object Country)
    {
        if (Detection.ToString() == CName && Input.GetMouseButtonDown(0) && PlayerPrestige >= Convert.ToInt32(Country))
        {
            MAmmountSlovakia += PlayerClickEarningSlovakia;
            PlayerTotalEarningSlovakia += PlayerClickEarningSlovakia;
            TextOutput.text = MAmmountSlovakia.ToString() + CSymbol;
            GamePlay.GamePlayInstance.Player.PlayerClicksCountSlovakia += 1;
        }
    }
}
