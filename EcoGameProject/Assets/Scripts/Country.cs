using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country 
{
    private string CName { get; }
    private int CLvLTBU { get; }
    private string CCurrency { get; }
    private string CIsUnlocked { get; }

    public Country(string Name, int LvL, string Currency)
    {
        this.CName = Name;
        this.CLvLTBU = LvL;
        this.CCurrency = Currency;
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
