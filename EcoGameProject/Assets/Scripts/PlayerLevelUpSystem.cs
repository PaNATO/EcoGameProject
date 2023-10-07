using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine;
using System.Linq;
using System;

public class PlayerLevelUpSystem : MonoBehaviour
{
    public static PlayerLevelUpSystem PlayerLevelUpSystemInstance;
    public LvlProgressSlider LvlProgressSliderInstance;
    public long PlayerLvlTemp;
    public void Awake()
    {
        if (PlayerLevelUpSystemInstance == null)
            PlayerLevelUpSystemInstance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    public void Start()
    {
        LvlProgressSliderInstance.SetLvlRequired(PlayerNew.PlayerNewInstance.Players[0].PlayerNextLvlXp);
    }

    // Update is called once per frame
    public void Update()
    {
        //EarnXpOnClick();
        //PrestigeLvl();
        LvlProgressSliderInstance.SetLvlGot(PlayerNew.PlayerNewInstance.Players[0].PlayerClickXp);
        //LvlUpCheck();
    }

    public void EarnXpOnClick()
    {
        foreach(var country in Countries.CountriesInstance.CountryList)
        {
            if (country.CountryPresTBU <= PlayerNew.PlayerNewInstance.Players[0].PlayerPrestige
                && country.CountryIsUnlocked
                && Input.GetMouseButtonDown(0)
                && Countries.CountriesInstance.HitDetection == country.CountryName)
            {
                PlayerNew.PlayerNewInstance.Players[0].PlayerClickXp += PlayerNew.PlayerNewInstance.Players[0].PlayerClickXpTemp;
                GameplayNewScript.GameplayNewScriptInstance.PlayerXpText.text = PlayerNew.PlayerNewInstance.Players[0].PlayerClickXp.ToString();
            }
            else
            {
                continue;
            }
        }

    }
    public void LvlUpCheck()
    {
        if (PlayerNew.PlayerNewInstance.Players[0].PlayerClickXp >= PlayerNew.PlayerNewInstance.Players[0].PlayerNextLvlXp)
        {
            PlayerNew.PlayerNewInstance.Players[0].PlayerClickXp -= PlayerNew.PlayerNewInstance.Players[0].PlayerNextLvlXp;
            PlayerNew.PlayerNewInstance.Players[0].PlayerLvl += 1;
            PlayerNew.PlayerNewInstance.Players[0].PlayerNextLvlXp += Mathf.Round(Mathf.Pow(PlayerLvlTemp , 2.2f));
            PlayerNew.PlayerNewInstance.Players[0].PlayerClickXpTemp += 1;
            LvlProgressSliderInstance.SetLvlRequired(PlayerNew.PlayerNewInstance.Players[0].PlayerNextLvlXp);
            //GamePlayInstance.InfoBinding("Osiągnięto poziom: " + PlayerNew.PlayerNewInstance.Players[0].PlayerLvl);
            PlayerLvlTemp = PlayerNew.PlayerNewInstance.Players[0].PlayerLvl + 1;
        }
    }
    public void PrestigeLvl()
    {
        if (PlayerNew.PlayerNewInstance.Players[0].PlayerLvl == 200)
        {
            PlayerNew.PlayerNewInstance.Players[0].PlayerNextLvlXpStart += 25;
            PlayerNew.PlayerNewInstance.Players[0].PlayerPrestige += 1;
            PlayerNew.PlayerNewInstance.Players[0].PlayerLvl = 1;
            PlayerNew.PlayerNewInstance.Players[0].PlayerClickXp = 0;
            PlayerNew.PlayerNewInstance.Players[0].PlayerNextLvlXp = PlayerNew.PlayerNewInstance.Players[0].PlayerNextLvlXpStart;
        }
    }
    /*public void EarnXpOnClick()
    {
        PlayerXp.EarnXpOnClick(PXp,PlayerXpText, "XP");
        PlayerXp.LvlUpCheck(PXp, RXp, PLvl, PlayerXpText, PlayerLvlText);
    }*/

    /*public void EarnXpOnClick()
    {
        if (GotRequiredXp(GamePlay.GamePlayInstance.Poland.CReturnLvlTBU()) == true)
        {
            PLvl += 1;
            PlayerLvl.text = "LVL: " + PLvl.ToString();
        }
    }
    public bool GotRequiredXp(object CName)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if ((int.Parse(CName.ToString())) <= PLvl)
            {
                Debug.Log("LVL się zgadza?: Tak");
                return true;
            }
            Debug.Log("LVL się zgadza?: Nie");
            return false;
        }
        return false;
    }
    */
}
