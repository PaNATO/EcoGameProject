using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Countries : MonoBehaviour
{
    public static Countries CountriesInstance;
    public void Awake()
    {
        if (CountriesInstance == null)
            CountriesInstance = this;
        else
            Destroy(gameObject);
    }
    [System.Serializable]
    public class Country
    {
        //Country Variables
        public string CountryName;
        public int CountryPresTBU;
        public string CountryCurrency;
        public bool CountryIsUnlocked;
        public GameObject CountryMap;
        public GameObject Locker;
        public Text SFCountryMoney;

        //Country Currency
        public string LanguageCountryCode;
        public string CurrencySymboll;

        //City Text
        public Text City1;
        public Text City2;
        public Text City3;
        public Text City4;

        //Money Earning Variables
        public long CountryMoneyAmmount;
        public long CompanyEarning;
        public long MoneyClickEarning;

        //Fees Variables
        public long CompanyFees;

    }
    public List<Country> CountryList;
    public string HitDetection;

    [SerializeField]
    void Check()
    {
        foreach (var country in CountryList)
        {
            if (country.CountryPresTBU <= PlayerNew.PlayerNewInstance.Players[0].PlayerPrestige 
                    && country.CountryIsUnlocked 
                    && Input.GetMouseButtonDown(0) 
                    && HitDetection == country.CountryName)
            {
                country.CountryMoneyAmmount += country.MoneyClickEarning;
            }
            else
            {
                continue;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Check();
    }
}
