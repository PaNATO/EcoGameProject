using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public string[] CurrencySymbols;
    //public SaveGame SaveGameInstance;
    public Player Player = new Player(50,1,1,0,0,0,0,1,0,0,0,0,0,0,0);
    public Currency Currency = new Currency();
    public static GamePlay GamePlayInstance;
    public LvlProgressSlider LvlProgressSliderInstance;
    //public GameStats GameStatsInstance;
    [SerializeField]
    public float CompanyEarningTime = 10f;
    public float CompanyEarningTimerTemp;
    public float CompanyFeeTime = 30f;
    public float CompanyFeeTimerTemp;
    public float SaveSystemTime;
    public float SaveSystemTimeTemp;
    public bool CompanyBoughtPoland = false;
    public float FadeSpeed = 20f;
    [SerializeField]
    Text ClickEarning;
    [SerializeField]
    Text CompanyEarning;
    [SerializeField]
    Text FeePay;
    [SerializeField]
    Text InfoText;
    //public Button City;
    public void Awake()
    {
        if (GamePlayInstance == null)
            GamePlayInstance = this;
        else
            Destroy(gameObject);
        //GamePlay.GamePlayInstance.Player.PlayerClickEarningPoland = 100000;
        Player.CompaniesAmmount = 0;
        Player.CompaniesBought = 0;
    }

    public Country Poland = new Country("Poland", 0, "PLN", "false");
    public Country Czechia = new Country("Czech", 50, "CZK", "false");
    public Country Slovakia = new Country("Slovakia", 100, "EUR", "false");

    // Start is called before the first frame update
    public void Start()
    {
        Currency.CCreateSymbol(0, "pl-PL", CurrencySymbols);
        Currency.CCreateSymbol(1, "cs-CZ", CurrencySymbols);
        Currency.CCreateSymbol(2, "sk-SK", CurrencySymbols);
        StartCoroutine(GamePlayTimer());
        StartCoroutine(InfoBidingFadeAway());
        PlayerDataBinding();
        LvlProgressSliderInstance.SetLvlRequired(GamePlay.GamePlayInstance.Player.PlayerNextLvlXp);
        SaveLoadSystem.SaveLoadSystemInstance.LoadGame();
    }

    // Update is called once per frame
    public void Update()
    {
        MoneyEarningSystem.MoneyEarningInstance.EarnPLNOnClick();
        //MoneyEarningSystem.MoneyEarningInstance.EarnCZKOnClick();
        PlayerLevelUpSystem.PlayerLevelUpSystemInstance.EarnXpOnClick();
        PlayerLevelUpSystem.PlayerLevelUpSystemInstance.LvlUpCheck();
        //Debug.Log("DeltaTime: " + Time.time);
        TimerStart();
        LvlProgressSliderInstance.SetLvlGot(GamePlay.GamePlayInstance.Player.PlayerClickXp);
        PlayerDataBinding();
        SaveGameTimer();
    }
    IEnumerator GamePlayTimer()
    {
        yield return new WaitForSeconds(10);
        Debug.Log("Update every 10 seconds: " + Time.time.ToString("f3"));
    }
    public void CompanyEarningTimer()
    {
        CompanyEarningTimerTemp += Time.deltaTime;
        if(CompanyEarningTimerTemp >= CompanyEarningTime)
        {
            CompanyEarningTimerTemp = 0f;
            Player.MAmmountPoland += Player.PlayerCompanyEarningPoland;
            Player.PlayerTotalEarningPoland += Player.PlayerCompanyEarningPoland;
        }
    }
    public void CompanyFeeTimer()
    {
        CompanyFeeTimerTemp += Time.deltaTime;
        if (CompanyFeeTimerTemp >= CompanyFeeTime)
        {
            CompanyFeeTimerTemp = 0f;
            Player.MAmmountPoland -= Player.PlayerFeePoland;
            GamePlay.GamePlayInstance.InfoBinding("Opłata :" + Player.PlayerFeePoland);
        }
    }
    public void SaveGameTimer()
    {
        SaveSystemTimeTemp += Time.deltaTime;
        if (SaveSystemTimeTemp >= SaveSystemTime)
        {
            SaveSystemTimeTemp = 0f;
            SaveLoadSystem.SaveLoadSystemInstance.SaveG();
            Debug.Log("Zpisano gre!");
        }
    }
    public void TimerStart()
    {
        if (CompanyBoughtPoland == true)
        {
            CompanyEarningTimer();
            CompanyFeeTimer();
        }
    }
    public void PlayerDataBinding()
    {
        ClickEarning.text = GamePlay.GamePlayInstance.Player.PlayerClickEarningPoland.ToString() + " " + GamePlay.GamePlayInstance.CurrencySymbols[0];
        CompanyEarning.text = GamePlay.GamePlayInstance.Player.PlayerCompanyEarningPoland.ToString() + " " + GamePlay.GamePlayInstance.CurrencySymbols[0];
        FeePay.text = GamePlay.GamePlayInstance.Player.PlayerFeePoland.ToString() + " " + GamePlay.GamePlayInstance.CurrencySymbols[0];
    }
    public void InfoBinding(string Message)
    {
        InfoText.text = Message;
        InfoText.color = Color.black;
    }
    IEnumerator InfoBidingFadeAway()
    {
        while(InfoText.color.a > 0)
        {
            InfoText.color = Color.Lerp(InfoText.color, Color.clear, FadeSpeed * Time.deltaTime);
            yield return null;
        }
    }
    void OnApplicationPause(bool PauseStatus)
    {
        if(PauseStatus)
        {
            Debug.Log("GamePaused");
            SaveLoadSystem.SaveLoadSystemInstance.SaveG();
        }else
        {
            Debug.Log("Resumed");
            SaveLoadSystem.SaveLoadSystemInstance.LoadGame();
        }
    }

}
