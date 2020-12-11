using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Country
{
    private string CName { get; }
    private int CLvLTBU { get; }
    private string CCurrency { get; }
    private string CIsUnlocked { get; set; }

    public Country(string Name, int LvL, string Currency, string Unlocked)
    {
        this.CName = Name;
        this.CLvLTBU = LvL;
        this.CCurrency = Currency;
        this.CIsUnlocked = Unlocked;
    }

    public int CReturnLvlTBU()
    {
        return CLvLTBU;
    }
    public string CReturnCCurency()
    {
        return CCurrency;
    }
    public string CReturnCName()
    {
        return CName;
    }
}
