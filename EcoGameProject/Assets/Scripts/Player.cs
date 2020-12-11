using UnityEngine;
using UnityEngine.UI;

public class Player
{
    [SerializeField]
    public long PlayerNextLvlXp { get; set; }
    public long PlayerClickXp { get; set; }
    public long PlayerClickXpTemp { get; set; }
    public long PlayerLvl { get; set; }
    public long MAmmountPoland { get; set; }
    public long MAmmountCzechia { get; set; }
    public long MAmmountSlovakia { get; set; }
    public long PlayerClickEarningPoland { get; set; }
    public long PlayerCompanyEarningPoland { get; set; }
    public long PlayerFeePoland { get; set; }
    //Statistics Section
    public long PlayerTotalEarningPoland { get; set; }
    public long PlayerClicksCountPoland { get; set; }
    public long PlayerBiggestDebtPoland { get; set; }
    public long PlayerBiggestFeePoland { get; set; }
    public long PlayerMostExpCompanyPoland { get; set; }
    public int CompaniesAmmount { get; set; }
    public int CompaniesBought { get; set; }
    //Functionality Section
    public Player(
        long NextLvlXp,
        long ClickXp,
        long ClickXpTemp,
        long Lvl,
        long MAmmountPol,
        long MAmmountCzech,
        long MAmmountSlov,
        long ClickEarningPol,
        long CompEarnPol,
        long FeePoland,
        long TotalEarnPol,
        long ClicksCouPol,
        long BiggDebtPol,
        long BiggFeePol,
        int CompBougtPol)
    {
        this.PlayerNextLvlXp = NextLvlXp;
        this.PlayerClickXp = ClickXp;
        this.PlayerClickXpTemp = ClickXpTemp; 
        this.PlayerLvl = Lvl;
        this.MAmmountPoland = MAmmountPol;
        this.MAmmountCzechia = MAmmountCzech;
        this.MAmmountSlovakia = MAmmountSlov;
        this.PlayerClickEarningPoland = ClickEarningPol;
        this.PlayerCompanyEarningPoland = CompEarnPol;
        this.PlayerFeePoland = FeePoland;
        this.PlayerTotalEarningPoland = TotalEarnPol;
        this.PlayerClicksCountPoland = ClicksCouPol;
        this.PlayerBiggestDebtPoland = BiggDebtPol;
        this.PlayerBiggestFeePoland = BiggFeePol;
        this.CompaniesBought = CompBougtPol;
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
    public void EarnZlOnClick(string CName, string CSymbol, Text TextOutput, object Detection, int LvL)
    {
        if (Detection.ToString() == CName && Input.GetMouseButtonDown(0) && PlayerLvl >= LvL)
        {
            MAmmountPoland += PlayerClickEarningPoland;
            PlayerTotalEarningPoland += PlayerClickEarningPoland;
            TextOutput.text = MAmmountPoland.ToString() + CSymbol;
            GamePlay.GamePlayInstance.Player.PlayerClicksCountPoland += 1;
        }
    }
    public void EarnKoronaOnClick(string CName, string CSymbol, Text TextOutput, object Detection, int LvL)
    {
        if (Detection.ToString() == CName && Input.GetMouseButtonDown(0) && PlayerLvl >= LvL)
        {
            MAmmountCzechia += 10;
            TextOutput.text = MAmmountCzechia.ToString() + CSymbol;
        }
    }
}
