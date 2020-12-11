using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    public static SaveLoadSystem SaveLoadSystemInstance;
    public void Awake()
    {
        if (SaveLoadSystemInstance == null)
            SaveLoadSystemInstance = this;
        else
            Destroy(gameObject);
    }
    [System.Serializable]
    public class SavLoa 
    {
        [SerializeField]
        public long PlayerMAmmountPolandSavLoad,
        PlayerNextLvlXpSavLoad,
        PlayerClickXpSavLoad,
        PlayerClickXpTempSavLoad,
        PlayerLvlSavLoad,
        PlayerCompanyEarningPolandSavLoad,
        PlayerFeePolandSavLoad,
        PlayerTotalEarningPolandSavLoad,
        PlayerClicksCountPolandSavLoad,
        PlayerBiggestDebtPolandSavLoad,
        PlayerBiggestFeePolandSavLoad,
        PlayerMostExpCompanyPolandSavLoad;
        [SerializeField]
        public int CompaniesBoughtSavLoad;
        public List<CompaniesBoughtList> CompaniesBought = new List<CompaniesBoughtList>();
        public bool CompanyBoughtPolandSavLoa;
    }
    [SerializeField] public SavLoa SavLoaInstance;

    [System.Serializable]
    public class CompaniesBoughtList
    {
        public string CompanyId;
        public bool isBought;
    }
    /*[System.Serializable]
    public class AllCompaniesBoughtList
    {
        public List<CompaniesBoughtList> CompaniesBought = new List<CompaniesBoughtList>();
    }
    [SerializeField] public AllCompaniesBoughtList AllCompaniesBoughtListInstance;*/
    void Start()
    {

    }
    public void SaveG()
    {
        SaveDataBind();
        string SavePath = Path.Combine(Application.persistentDataPath, "Save.json");
        File.WriteAllText(SavePath, JsonUtility.ToJson(SavLoaInstance, true));
    }
    public void LoadGame()
    {
        if (MenuUserInterface.isGameLoading == true)
        {
            string LoadPath = Path.Combine(Application.persistentDataPath, "Save.json");
            string jsonString = File.ReadAllText(LoadPath);
            JsonUtility.FromJsonOverwrite(jsonString, SavLoaInstance);
            LoadDataBind();
            Debug.Log(jsonString);
            //MenuUserInterface.isGameLoading = false;
        }

    }
    void SaveDataBind()
    {
        SavLoaInstance.PlayerMAmmountPolandSavLoad = GamePlay.GamePlayInstance.Player.MAmmountPoland;
        SavLoaInstance.PlayerNextLvlXpSavLoad = GamePlay.GamePlayInstance.Player.PlayerNextLvlXp;
        SavLoaInstance.PlayerClickXpSavLoad = GamePlay.GamePlayInstance.Player.PlayerClickXp;
        SavLoaInstance.PlayerClickXpTempSavLoad = GamePlay.GamePlayInstance.Player.PlayerClickXpTemp;
        SavLoaInstance.PlayerLvlSavLoad = GamePlay.GamePlayInstance.Player.PlayerLvl;
        SavLoaInstance.PlayerCompanyEarningPolandSavLoad = GamePlay.GamePlayInstance.Player.PlayerCompanyEarningPoland;
        SavLoaInstance.PlayerFeePolandSavLoad = GamePlay.GamePlayInstance.Player.PlayerFeePoland;
        //Stats
        SavLoaInstance.PlayerTotalEarningPolandSavLoad = GamePlay.GamePlayInstance.Player.PlayerTotalEarningPoland;
        SavLoaInstance.PlayerClicksCountPolandSavLoad = GamePlay.GamePlayInstance.Player.PlayerClicksCountPoland;
        SavLoaInstance.PlayerBiggestDebtPolandSavLoad = GamePlay.GamePlayInstance.Player.PlayerBiggestDebtPoland;
        SavLoaInstance.PlayerBiggestFeePolandSavLoad = GamePlay.GamePlayInstance.Player.PlayerBiggestFeePoland;
        SavLoaInstance.PlayerMostExpCompanyPolandSavLoad = GamePlay.GamePlayInstance.Player.PlayerMostExpCompanyPoland;
        SavLoaInstance.CompaniesBoughtSavLoad = GamePlay.GamePlayInstance.Player.CompaniesBought;
        SavLoaInstance.CompanyBoughtPolandSavLoa = GamePlay.GamePlayInstance.CompanyBoughtPoland;
    }
    void LoadDataBind()
    {
        GamePlay.GamePlayInstance.Player.MAmmountPoland = SavLoaInstance.PlayerMAmmountPolandSavLoad;
        GamePlay.GamePlayInstance.Player.PlayerNextLvlXp = SavLoaInstance.PlayerNextLvlXpSavLoad;
        GamePlay.GamePlayInstance.Player.PlayerClickXp = SavLoaInstance.PlayerClickXpSavLoad;
        GamePlay.GamePlayInstance.Player.PlayerClickXpTemp = SavLoaInstance.PlayerClickXpTempSavLoad;
        GamePlay.GamePlayInstance.Player.PlayerLvl = SavLoaInstance.PlayerLvlSavLoad;
        GamePlay.GamePlayInstance.Player.PlayerCompanyEarningPoland = SavLoaInstance.PlayerCompanyEarningPolandSavLoad;
        GamePlay.GamePlayInstance.Player.PlayerFeePoland = SavLoaInstance.PlayerFeePolandSavLoad;
        //Stats
        GamePlay.GamePlayInstance.Player.PlayerTotalEarningPoland = SavLoaInstance.PlayerTotalEarningPolandSavLoad;
        GamePlay.GamePlayInstance.Player.PlayerClicksCountPoland = SavLoaInstance.PlayerClicksCountPolandSavLoad;
        GamePlay.GamePlayInstance.Player.PlayerBiggestDebtPoland = SavLoaInstance.PlayerBiggestDebtPolandSavLoad;
        GamePlay.GamePlayInstance.Player.PlayerBiggestFeePoland = SavLoaInstance.PlayerBiggestFeePolandSavLoad;
        GamePlay.GamePlayInstance.Player.PlayerMostExpCompanyPoland = SavLoaInstance.PlayerMostExpCompanyPolandSavLoad;
        GamePlay.GamePlayInstance.Player.CompaniesBought = SavLoaInstance.CompaniesBoughtSavLoad;
        GamePlay.GamePlayInstance.CompanyBoughtPoland = SavLoaInstance.CompanyBoughtPolandSavLoa;
    }
}
