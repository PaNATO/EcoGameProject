using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Currency
{
    public Currency()
    {

    }

    public void CCreateSymbol(int TableIndex, string LanguageCountryCode, string[] Table)
    {
        RegionInfo RegionCodeVariable = new RegionInfo(LanguageCountryCode);
        Table[TableIndex] = RegionCodeVariable.CurrencySymbol.ToString();
    }
}
