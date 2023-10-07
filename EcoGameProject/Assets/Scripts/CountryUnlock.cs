using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryUnlock : MonoBehaviour
{
    public static CountryUnlock CountryUnlockInstance;
    public void Awake()
    {
        if (CountryUnlockInstance == null)
            CountryUnlockInstance = this;
        else
            Destroy(gameObject);
    }

    public void CountryUnlockFunc()
    {
        foreach(var country in Countries.CountriesInstance.CountryList)
        {   
            if(PlayerNew.PlayerNewInstance.Players[0].PlayerPrestige >= country.CountryPresTBU && PlayerNew.PlayerNewInstance.Players[0].PlayerPrestige > 0)
            {
                country.CountryIsUnlocked = true;
                country.Locker.SetActive(false);
                country.CountryMap.SetActive(true);
                //CzechiaMap.gameObject.SetActive(true);
                //CzechiaLocker.SetActive(false);
                //SlovakiaMap.gameObject.SetActive(true);
                //SlovakiaLocker.SetActive(false);
            }
        }
        /*switch(GamePlay.GamePlayInstance.Player.PlayerPrestige)
        {
            case 1:
                CzechiaMap.gameObject.SetActive(true);
                CzechiaLocker.SetActive(false);
                break;
            case 2:
                SlovakiaMap.gameObject.SetActive(true);
                SlovakiaLocker.SetActive(false);
                break;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        CountryUnlockFunc();
    }
}
