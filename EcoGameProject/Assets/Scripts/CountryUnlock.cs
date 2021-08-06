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
    [SerializeField] Transform CzechiaMap;
    [SerializeField] Transform SlovakiaMap;
    [SerializeField] GameObject CzechiaLocker;
    [SerializeField] GameObject SlovakiaLocker;
    int PlayerPresTemp;

    public void CountryUnlockFunc()
    {
        foreach(var country in GamePlay.GamePlayInstance.CountriesList)
        {
            PlayerPresTemp = Convert.ToInt32(country.CReturnPresTBU());
            
            if(GamePlay.GamePlayInstance.Player.PlayerPrestige > Convert.ToInt32(country.CReturnPresTBU()))
            {
                Debug.Log("PlayerTemp: " + Convert.ToInt32(country.CReturnPresTBU()));
                CzechiaMap.gameObject.SetActive(true);
                CzechiaLocker.SetActive(false);
                SlovakiaMap.gameObject.SetActive(true);
                SlovakiaLocker.SetActive(false);
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountryUnlockFunc();
    }
}
