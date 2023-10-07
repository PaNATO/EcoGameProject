using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public static Currency CurrencyInstance;
    public void Awake()
    {
        if (CurrencyInstance == null)
            CurrencyInstance = this;
        else
            Destroy(gameObject);
    }
    [System.Serializable]
    public class Currencies
    {
        public string Countryname;
        public string LanguageCountryCode;
        public void CCreateSymbol(int TableIndex, string LanguageCountryCode, string[] Table)
        {
            RegionInfo RegionCodeVariable = new RegionInfo(LanguageCountryCode);
            Table[TableIndex] = RegionCodeVariable.CurrencySymbol.ToString();
        }
    }
    public List<Currencies> CurrenciesList;
}
