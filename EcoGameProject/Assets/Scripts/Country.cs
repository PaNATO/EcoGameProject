using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country 
{
    string CName = "";
    int CLvLTBU = 0;
    string CCurrency = "";
    string CIsUnlocked = "";

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




    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
