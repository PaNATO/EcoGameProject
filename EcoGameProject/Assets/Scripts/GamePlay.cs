using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public Player Player = new Player();
    public static GamePlay GamePlayInstance;
    public void Awake()
    {
        if (GamePlayInstance == null)
            GamePlayInstance = this;
        else
            Destroy(gameObject);
    }

    public Country Poland = new Country("PolandMap", 0, "PLN");
    public Country Slovakia = new Country("CzechMap", 50, "PLN");
    public Country Czech = new Country("SlovakiaMap", 100, "PLN");

    // Start is called before the first frame update
    public void Start()
    {

        
    }

    // Update is called once per frame
    public void Update()
    {
        MoneyEarningSystem.instance.EarnPLNOnClick();
        PlayerLevelUpSystem.PlayerLevelUpSystemInstance.EarnXpOnClick();
        PlayerLevelUpSystem.PlayerLevelUpSystemInstance.LvlUpCheck();
    }


}
