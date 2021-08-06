using UnityEngine;
using UnityEngine.UI;

public class MoneyEarningSystem : MonoBehaviour
{
    //RegionInfo bg = new RegionInfo("bg-BG");
    //--------------------------------------------------------------SerializeFields
    [SerializeField]
    Text SVMoneyPoland;
    [SerializeField]
    Text SVMoneyCzechia;
    [SerializeField]
    Text SVMoneySlovakia;
    //--------------------------------------------------------------Variables
    public GameObject[] CurrencySymbolsAssets;
    //--------------------------------------------------------------Class Objects
    public Money MoneyPLNClass = new Money();
    //--------------------------------------------------------------Class instance
    public static MoneyEarningSystem MoneyEarningInstance;
    //--------------------------------------------------------------Sets up an instacne of GameObject and Destroy when we close program
    public void Awake()
    {
        if (MoneyEarningInstance == null)
            MoneyEarningInstance = this;
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    public void Start()
    {
        //CurrencySymbols[0] = bg.CurrencySymbol.ToString();
    }

    // Update is called once per frame
    public void Update()
    {
        SVMoneyPoland.text = GamePlay.GamePlayInstance.Player.MAmmountPoland.ToString() +" "+ GamePlay.GamePlayInstance.CurrencySymbols[0];
        SVMoneyCzechia.text = GamePlay.GamePlayInstance.Player.MAmmountCzechia.ToString() +" "+ GamePlay.GamePlayInstance.CurrencySymbols[1];
        SVMoneySlovakia.text = GamePlay.GamePlayInstance.Player.MAmmountSlovakia.ToString() +" "+ GamePlay.GamePlayInstance.CurrencySymbols[2];

    }
    public void EarnPLNOnClick()
    {
        GamePlay.GamePlayInstance.Player.EarnZlOnClick(
            GamePlay.GamePlayInstance.Poland.CReturnCName(),
            GamePlay.GamePlayInstance.CurrencySymbols[0],
            SVMoneyPoland,
            MapClickedDetection.mapClickedDetectionInstance.Detection(),
            GamePlay.GamePlayInstance.Poland.CReturnPresTBU());
    }
    public void EarnCZKOnClick()
    {
        GamePlay.GamePlayInstance.Player.EarnKoronaOnClick(
            GamePlay.GamePlayInstance.Czechia.CReturnCName(),
            GamePlay.GamePlayInstance.CurrencySymbols[1],
            SVMoneyCzechia,
            MapClickedDetection.mapClickedDetectionInstance.Detection(),
            GamePlay.GamePlayInstance.Czechia.CReturnPresTBU());
    }
    public void EarnSlovEuroOnClick()
    {
        GamePlay.GamePlayInstance.Player.EarnSlovEuroOnClick(
            GamePlay.GamePlayInstance.Slovakia.CReturnCName(),
            GamePlay.GamePlayInstance.CurrencySymbols[2],
            SVMoneySlovakia,
            MapClickedDetection.mapClickedDetectionInstance.Detection(),
            GamePlay.GamePlayInstance.Slovakia.CReturnPresTBU());
    }
}
