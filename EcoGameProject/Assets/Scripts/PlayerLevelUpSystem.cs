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
    [SerializeField]
    Text PlayerLvlText;
    [SerializeField]
    Text PlayerXpText;
    [SerializeField]
    Text RequiredXpText;
    [SerializeField]
    Text PrestigeLvlText;

    long PlayerLvlTemp = 2;

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

    }

    // Update is called once per frame
    public void Update()
    {
        PlayerLvlText.text = "LVL: " + GamePlay.GamePlayInstance.Player.PlayerLvl.ToString();
        PlayerXpText.text = GamePlay.GamePlayInstance.Player.PlayerClickXp.ToString();
        RequiredXpText.text = "/" + GamePlay.GamePlayInstance.Player.PlayerNextLvlXp.ToString();
        PrestigeLvlText.text = "Prestige:" + GamePlay.GamePlayInstance.Player.PlayerPrestige.ToString();
        PrestigeLvl();
    }

    public void EarnXpOnClick()
    {
        if (MapClickedDetection.mapClickedDetectionInstance.Detection() != "" && Input.GetMouseButtonDown(0))
        {
            GamePlay.GamePlayInstance.Player.PlayerClickXp += GamePlay.GamePlayInstance.Player.PlayerClickXpTemp;
            PlayerXpText.text = GamePlay.GamePlayInstance.Player.PlayerClickXp.ToString();
        }
    }
    public void LvlUpCheck()
    {
        if (GamePlay.GamePlayInstance.Player.PlayerClickXp >= GamePlay.GamePlayInstance.Player.PlayerNextLvlXp)
        {
            GamePlay.GamePlayInstance.Player.PlayerClickXp -= GamePlay.GamePlayInstance.Player.PlayerNextLvlXp;
            GamePlay.GamePlayInstance.Player.PlayerLvl += 1;
            GamePlay.GamePlayInstance.Player.PlayerNextLvlXp += Mathf.Round(Mathf.Pow(PlayerLvlTemp , 2.2f));
            //GamePlay.GamePlayInstance.Player.PlayerClickXpTemp += 1;
            GamePlay.GamePlayInstance.LvlProgressSliderInstance.SetLvlRequired(GamePlay.GamePlayInstance.Player.PlayerNextLvlXp);
            GamePlay.GamePlayInstance.InfoBinding("Osiągnięto poziom: " + GamePlay.GamePlayInstance.Player.PlayerLvl);
            PlayerLvlTemp = GamePlay.GamePlayInstance.Player.PlayerLvl + 1;
        }
    }
    public void PrestigeLvl()
    {
        if (GamePlay.GamePlayInstance.Player.PlayerLvl == 200)
        {
            GamePlay.GamePlayInstance.Player.PlayerNextLvlXpStart += 25;
            GamePlay.GamePlayInstance.Player.PlayerPrestige += 1;
            GamePlay.GamePlayInstance.Player.PlayerLvl = 1;
            GamePlay.GamePlayInstance.Player.PlayerClickXp = 0;
            GamePlay.GamePlayInstance.Player.PlayerNextLvlXp = GamePlay.GamePlayInstance.Player.PlayerNextLvlXpStart;
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
