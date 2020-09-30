using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    public int PlayerCurrentXp { get; set; }
    public int PlayerLvl { get; set; }
    public int MAmmount { get; set; }
    public Player()
    {

    }
    public void EarnXpOnClick(int Xp,Text TextOutput, string OutputText, object Detection)
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
    }
    public void EarnMoneyOnClick(string CCurrency, string CName, string CSymbol, Text TextOutput, object Detection)
    {
        if (Detection.ToString() == CName && Input.GetMouseButtonDown(0))
        {
            MAmmount += 10;
            TextOutput.text = CCurrency + MAmmount.ToString() + CSymbol;
        }
    }
}
