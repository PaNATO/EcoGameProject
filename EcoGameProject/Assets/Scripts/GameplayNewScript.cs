using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameplayNewScript : MonoBehaviour
{
    public static GameplayNewScript GameplayNewScriptInstance;

    [SerializeField]
    public Text PlayerLvlText;
    public Text PlayerXpText;
    public Text RequiredXpText;
    public Text PrestigeLvlText;
    public Text ClickEarning;
    public Text CompanyEarning;
    public Text FeePay;
    public Text CountryNameFP;

    // TESTING TIMER LINES
    public Text Hours;
    public float realtime;
    public float minutes;
    public float hours;
    public long day;
    public long year;
    public float helper;
    public const float REAL_LIFE_HOURS_PER_GAME_SECONDS = 5f;
    public const float REAL_LIFE_DAY_PER_GAME_SECONDS = 30f;
    public const long REAL_LIFE_YEAR_PER_GAME_YEAR = 360;
    public const float REAL_LIFE_HOURS = 24f;
    public const float REAL_LIFE_SECONDS = 60f;

    public void Awake()
    {
        if (GameplayNewScriptInstance == null)
            GameplayNewScriptInstance = this;
        else
        Destroy(gameObject);
    }

    void SetCurrency()
    {
        foreach (var country in Countries.CountriesInstance.CountryList)
        {
            RegionInfo RegionCodeVar = new RegionInfo(country.LanguageCountryCode);
            country.CurrencySymboll = RegionCodeVar.CurrencySymbol.ToString();
        }
    }
    void SetTextOnScreen()
    {
        foreach(var country in Countries.CountriesInstance.CountryList)
        {
            country.SFCountryMoney.text = country.CountryMoneyAmmount.ToString() + " " + country.CurrencySymboll;
            PlayerLvlText.text = "LVL: " + PlayerNew.PlayerNewInstance.Players[0].PlayerLvl.ToString();
            PlayerXpText.text = PlayerNew.PlayerNewInstance.Players[0].PlayerClickXp.ToString();
            RequiredXpText.text = "/" + PlayerNew.PlayerNewInstance.Players[0].PlayerNextLvlXp.ToString();
            PrestigeLvlText.text = "Prestige:" + PlayerNew.PlayerNewInstance.Players[0].PlayerPrestige.ToString();
        }
    }
    public void PlayerDataBinding()
    {
        foreach(var country in Countries.CountriesInstance.CountryList)
        {
            if(Input.GetMouseButtonDown(0)
                    && Countries.CountriesInstance.HitDetection == country.CountryName
                    && !EventSystem.current.IsPointerOverGameObject())
            {
                ClickEarning.text = country.MoneyClickEarning.ToString() + " " + country.CurrencySymboll;
                CompanyEarning.text = country.CompanyEarning.ToString() + " " + country.CurrencySymboll;
                FeePay.text = country.CompanyFees.ToString() + " " + country.CurrencySymboll;
                CountryNameFP.text = country.CountryName.ToString();
            }
        }
    }
    /*public void GameTime()
    {
        /*time = Time.realtimeSinceStartup;
        if (time >= REAL_LIFE_HOURS_PER_GAME_SECONDS)
        {
            hours += 1;
            time = 0;
        }
        if(hours >= REAL_LIFE_DAY_PER_GAME_SECONDS)
        {
            day += 1;
        }

        realtime += Time.deltaTime / REAL_LIFE_HOURS_PER_GAME_SECONDS;}
        float realtimenormalized = realtime % 1f;
        /*if (seconds >= REAL_LIFE_SECONDS)
        {
            hours += 1;
            seconds = 0;
        }
        if (hours >= REAL_LIFE_HOURS)
        {
            day += 1;
            hours = 0;
        }

        Hours.text = hours.ToString() + ":" + realtimenormalized.ToString();
        Days.text = "Dzień: " + day.ToString();
    }*/

    // Start is called before the first frame update
    void Start()
    {
        SetCurrency();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 Point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D Hit = Physics2D.Raycast(Point, Vector2.zero);
            if (Hit.collider != null && !EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log(Hit.collider.name);
                Countries.CountriesInstance.HitDetection = Hit.collider.name;
            }
            else
                Countries.CountriesInstance.HitDetection = "";
        }
        PlayerLevelUpSystem.PlayerLevelUpSystemInstance.LvlUpCheck();
        PlayerLevelUpSystem.PlayerLevelUpSystemInstance.EarnXpOnClick();
        PlayerLevelUpSystem.PlayerLevelUpSystemInstance.PrestigeLvl();
        SetTextOnScreen();
        PlayerDataBinding();
        //GameTime();

        realtime += Time.deltaTime / REAL_LIFE_HOURS_PER_GAME_SECONDS;
        helper += Time.deltaTime / REAL_LIFE_HOURS_PER_GAME_SECONDS;
        float realtimenormalized = realtime % 1f;
        minutes = Mathf.FloorToInt((realtimenormalized * REAL_LIFE_HOURS % 1f) * REAL_LIFE_SECONDS);
        hours = Mathf.FloorToInt(realtimenormalized * REAL_LIFE_HOURS);
        foreach(var country in Countries.CountriesInstance.CountryList)
        {
            if (helper >= 1)
            {
                day += 1;
                helper = 0;
                country.CountryMoneyAmmount += country.CompanyEarning;
            }
            if (day == REAL_LIFE_YEAR_PER_GAME_YEAR)
            {
                year += 1;
                day = 1;
                country.CountryMoneyAmmount -= country.CompanyFees;
            }
        }
        Debug.Log(realtimenormalized);
        Hours.text = year.ToString() + "Y|" + day.ToString() + "D|" + hours.ToString("00") + "H";//hours.ToString("00") + ":" + minutes.ToString("00");
    }
}
