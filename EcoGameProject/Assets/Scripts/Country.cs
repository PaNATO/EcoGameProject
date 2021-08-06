using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Country
{
    private string CName { get; }
    private int CPresTBU { get; }
    private string CCurrency { get; }
    private string CIsUnlocked { get; set; }

    public Country(string Name, int Prestige, string Currency, string Unlocked)
    {
        this.CName = Name;
        this.CPresTBU = Prestige;
        this.CCurrency = Currency;
        this.CIsUnlocked = Unlocked;
    }

    public int CReturnPresTBU()
    {
        return CPresTBU;
    }
    public string CReturnCCurency()
    {
        return CCurrency;
    }
    public string CReturnCName()
    {
        return CName;
    }
    public string CReturnCUnlocked()
    {
        return CIsUnlocked;
    }
}
