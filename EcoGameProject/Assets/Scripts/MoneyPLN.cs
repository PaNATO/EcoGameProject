using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MoneyPLN : MonoBehaviour
{
    public static MoneyPLN instance;
    [SerializeField]
    Text MoneyText;
    public int Money;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        MoneyText.text = "Money:" + Money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EarnPLNOnClick()
    {
        if (MapClickedDetection.mapClickedDetectionInstance.Detection() == "PolandMap" && Input.GetMouseButtonDown(0) && PlayerLevelUpSystem.PlayerLevelUpSystemInstance.GotRequiredXp(GamePlay.GamePlayInstance.Poland.CReturnLvlTBU()))
        {
            Money += 10;
            MoneyText.text = "PLN:" + Money.ToString()+"ZŁ";
            PlayerLevelUpSystem.PlayerLevelUpSystemInstance.EarnXpOnClick();
        }
    }
}
