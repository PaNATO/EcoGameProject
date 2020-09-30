using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine;
using System.Linq;

public class PlayerLevelUpSystem : MonoBehaviour
{
    public static PlayerLevelUpSystem PlayerLevelUpSystemInstance;
    [SerializeField]
    Text PlayerLvlText;
    [SerializeField]
    Text PlayerXpText;
    [SerializeField]
    Text RequiredXpText;
    public int PLvl;
    public int PXp;
    public int RXp;

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
        PlayerLvlText.text = "LVL: " + GamePlay.GamePlayInstance.Player.PlayerLvl.ToString();
        PlayerXpText.text = "XP: " + PXp.ToString();
        RequiredXpText.text = "XPR: " + RXp.ToString();
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void EarnXpOnClick()
    {
        if (MapClickedDetection.mapClickedDetectionInstance.Detection() != "" && Input.GetMouseButtonDown(0))
        {
            PXp += 10;
            PlayerXpText.text = "XP: " + PXp.ToString();
        }
    }
    public void LvlUpCheck()
    {
        if (PXp >= RXp)
        {
            PXp -= RXp;
            GamePlay.GamePlayInstance.Player.PlayerLvl += 1;
            PlayerXpText.text = "XP: " + PXp.ToString();
            PlayerLvlText.text = "LVL: " + GamePlay.GamePlayInstance.Player.PlayerLvl.ToString();
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
