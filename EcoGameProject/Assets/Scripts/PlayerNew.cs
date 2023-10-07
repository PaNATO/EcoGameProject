using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNew : MonoBehaviour
{
    public static PlayerNew PlayerNewInstance;
    public void Awake()
    {
        if (PlayerNewInstance == null)
            PlayerNewInstance = this;
        else
            Destroy(gameObject);
    }
    [System.Serializable]
    public class Player
    {
        public string PlayerName;
        //LvL and Prestige;
        public int PlayerPrestige;
        public float PlayerNextLvlXp;
        public float PlayerNextLvlXpStart;
        public float PlayerClickXp;
        public float PlayerClickXpTemp;
        public long PlayerLvl;
        //Player Money In Countries
        //--public long MAmmountPoland;
        //--public long MAmmountCzechRep;
        //--public long MAmmountSlovakia;
        public long PlayerClickEarningPoland;
        public long PlayerClickEarningCzechRep;
        public long PlayerClickEarningSlovakia;
        public long PlayerCompanyEarningPoland;
        public long PlayerFeePoland;
        //Statistics Section
        public long PlayerTotalEarningPoland;
        public long PlayerTotalEarningCzech;
        public long PlayerTotalEarningSlovakia;
        public long PlayerClicksCountPoland;
        public long PlayerClicksCountCzech;
        public long PlayerClicksCountSlovakia;
        public long PlayerBiggestDebtPoland;
        public long PlayerBiggestFeePoland;
        public long PlayerMostExpCompanyPoland;
        public int CompaniesBought;
    }
    public List<Player> Players;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
