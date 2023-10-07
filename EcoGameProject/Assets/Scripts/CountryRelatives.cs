using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CountryRelatives : MonoBehaviour
{
    public CountryProgressSliders CountryProgressSlidersInstance;
    public static CountryRelatives CountryRelativesInstance;
    public void Awake()
    {
        if (CountryRelativesInstance == null)
            CountryRelativesInstance = this;
        else
            Destroy(gameObject);
    }
    [System.Serializable]
    public class Company
    {
        public string CompanyName;
        public Sprite PriceImage;
        public long CompanyPrice;
        public Sprite TaxImage;
        public long CompanyFee;
        public string CompanyCity;
        public string CompanyCountry;
        public long CompanyIncome;
        public bool IsPurchased = true;
    }
    public List<Company> Companies;
    GameObject CompanyPrefab;
    GameObject CompanyInstance;
    [SerializeField] Transform CompanyScrollView;
    [SerializeField] Text CityNameBanner;
    Button BoughtCompanyButton;

    // Start is called before the first frame update
    public void Start()
    {
        //GamePlay.GamePlayInstance.Player.CompaniesAmmount = Companies.Count;
        CountryProgressSlidersInstance.SetCitiesAmmount(Companies.Count);
        CompanyPrefab = CompanyScrollView.GetChild(0).gameObject;
        int len1 = Companies.Count;
        for (int i = 0; i < len1; i++)
        {
            CompanyInstance = Instantiate(CompanyPrefab, CompanyScrollView);
            CompanyInstance.transform.GetChild(0).GetComponent<Text>().text = Companies[i].CompanyName;
            CompanyInstance.transform.GetChild(1).GetComponent<Image>().sprite = Companies[i].PriceImage;
            CompanyInstance.transform.GetChild(2).GetComponent<Text>().text = Companies[i].CompanyPrice.ToString("N0");
            CompanyInstance.transform.GetChild(3).GetComponent<Image>().sprite = Companies[i].TaxImage;
            CompanyInstance.transform.GetChild(4).GetComponent<Text>().text = Companies[i].CompanyFee.ToString("N0")+"/day";
            CompanyInstance.transform.GetChild(5).GetComponent<Text>().text = Companies[i].CompanyCity;
            CompanyInstance.transform.GetChild(6).GetComponent<Text>().text = Companies[i].CompanyCountry;
            CompanyInstance.transform.GetChild(7).GetComponent<Text>().text = Companies[i].CompanyIncome.ToString("N0")+"/h";
            BoughtCompanyButton = CompanyInstance.transform.GetChild(8).GetComponent<Button>();
            BoughtCompanyButton.interactable = Companies[i].IsPurchased;
            BoughtCompanyButton.SpecialEventListener(i, CompanyBought);   
        }
        Destroy(CompanyPrefab);
        CityStartSelected();
    }

    // Update is called once per frame
    public void Update()
    {
        MoneyEnoughToBuy();
        CountryProgressSlidersInstance.SetCitiesBought(GamePlay.GamePlayInstance.Player.CompaniesBought);
            for(int i = 0; i < Companies.Count; i++)
            {
                if(SaveLoadSystem.SaveLoadSystemInstance.SavLoaInstance.CompaniesBought[i].isBought == true)
                {
                    Companies[i].IsPurchased = true;
                    CompanyScrollView.GetChild(i).GetChild(8).GetComponent<Button>().interactable = false;
                    BoughtCompanyButton = CompanyScrollView.GetChild(i).GetChild(8).GetComponent<Button>();
                    BoughtCompanyButton.transform.GetChild(0).GetComponent<Text>().text = "Kupione";

                }
            }
    }
    public void CityStartSelected()
    {
        string StartCity = "Kraków";
        CityNameBanner.text = StartCity;
        for (int i = 0; i < CompanyScrollView.childCount; i++)
        {
            string CurrentCompanyCityStart = CompanyScrollView.GetChild(i).GetChild(5).GetComponent<Text>().text;
            Debug.Log("Test2: " + CurrentCompanyCityStart);
            if (StartCity != CurrentCompanyCityStart)
            {
                CompanyScrollView.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                CompanyScrollView.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
    public void CityCompaniesSelected()
    {
        var Detected = EventSystem.current.currentSelectedGameObject;
        if (Detected != null)
        {
            CityNameBanner.text = Detected.name;
            Debug.Log(Detected.name);
            for (int i = 0; i < CompanyScrollView.childCount; i++)
            {
                string CurrentCompanyCity = CompanyScrollView.GetChild(i).GetChild(5).GetComponent<Text>().text;
                Debug.Log("Test: " + CurrentCompanyCity);
                if (Detected.name != CurrentCompanyCity)
                {
                    CompanyScrollView.GetChild(i).gameObject.SetActive(false);
                }
                else
                {
                    CompanyScrollView.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }
    void MoneyEnoughToBuy()
    {
        for(int i = 0; i < CompanyScrollView.childCount; i++)
        {
            long CompanyPriceVar = Companies[i].CompanyPrice;
            bool CompanyBought = Companies[i].IsPurchased;
            foreach(var country in Countries.CountriesInstance.CountryList)
            {
                if (country.CountryMoneyAmmount >= CompanyPriceVar && CompanyBought == false)
                {
                    BoughtCompanyButton = CompanyScrollView.GetChild(i).GetChild(8).GetComponent<Button>();
                    BoughtCompanyButton.interactable = true;
                }
            }
        }
    }
    void CompanyBought(int CompanyIndex)
    {
        SaveLoadSystem.SaveLoadSystemInstance.SavLoaInstance.CompaniesBought[CompanyIndex].CompanyId = CompanyIndex.ToString();
        long CompanyPriceVar = Companies[CompanyIndex].CompanyPrice;
        string CompanyCountry = CompanyScrollView.GetChild(CompanyIndex).GetChild(6).GetComponent<Text>().text;
        long CompanyFeeVar = Companies[CompanyIndex].CompanyFee;
        long CompanyIncomeVar = Companies[CompanyIndex].CompanyIncome;
        string CompanyName = CompanyScrollView.GetChild(CompanyIndex).GetChild(0).GetComponent<Text>().text;
        Debug.Log("Firma: " + CompanyName + " Opłaty na dzień: " + CompanyFeeVar + " Przychód: " + CompanyIncomeVar);
        //GamePlay.GamePlayInstance.InfoBinding(CompanyName + "\n Opłaty na dzień: " + CompanyFeeVar + "\n Przychód: " + CompanyIncomeVar);
        GamePlay.GamePlayInstance.InfoBinding("Kupiono " + CompanyName);
        Companies[CompanyIndex].IsPurchased = true;
        BoughtCompanyButton = CompanyScrollView.GetChild(CompanyIndex).GetChild(8).GetComponent<Button>();
        foreach(var country in Countries.CountriesInstance.CountryList)
        {
            if(country.CountryMoneyAmmount >= CompanyPriceVar)
            {
                SaveLoadSystem.SaveLoadSystemInstance.SavLoaInstance.CompaniesBought[CompanyIndex].isBought = true;
                country.CountryMoneyAmmount -= CompanyPriceVar;
                country.CompanyEarning += CompanyIncomeVar;
                country.CompanyFees += CompanyFeeVar;
                //GameplayNewScript.GameplayNewScriptInstance.PlayerDataBinding();
                PlayerNew.PlayerNewInstance.Players[0].CompaniesBought += 1;
                CompanyScrollView.GetChild(CompanyIndex).GetChild(8).GetComponent<Button>().interactable = false;
                BoughtCompanyButton.transform.GetChild(0).GetComponent<Text>().text = "Kupione";
            }else
            {
                Debug.Log("Za mało funduszy!");
            }
        }
        /*if (CompanyCountry == GamePlay.GamePlayInstance.Poland.CReturnCName())
        {
            if (GamePlay.GamePlayInstance.Player.MAmmountPoland >= CompanyPriceVar)
            {
                SaveLoadSystem.SaveLoadSystemInstance.SavLoaInstance.CompaniesBought[CompanyIndex].isBought = true;
                GamePlay.GamePlayInstance.Player.MAmmountPoland -= CompanyPriceVar;
                GamePlay.GamePlayInstance.Player.PlayerCompanyEarningPoland += CompanyIncomeVar;
                GamePlay.GamePlayInstance.Player.PlayerFeePoland += CompanyFeeVar;
                GamePlay.GamePlayInstance.PlayerDataBinding();
                GamePlay.GamePlayInstance.CompanyBoughtPoland = true;
                GamePlay.GamePlayInstance.Player.CompaniesBought += 1;
                CompanyScrollView.GetChild(CompanyIndex).GetChild(8).GetComponent<Button>().interactable = false;
                BoughtCompanyButton.transform.GetChild(0).GetComponent<Text>().text = "Kupione";
                BiggestFeeFunc();
                MostExpensiveCompany();
            }
            else
            {
                Debug.Log("Za mało funduszy!");
                GamePlay.GamePlayInstance.InfoBinding("Za mało funduszy!");
            }
        }*/
    }

    //Stats Section
    public void BiggestFeeFunc()
    {
        long Temp = Companies[0].CompanyFee;
        for (int i = 0; i < Companies.Count; i++)
        {
            if(Temp <= Companies[i].CompanyFee)
            {
                Temp = Companies[i].CompanyFee;
            }
        }
        GamePlay.GamePlayInstance.Player.PlayerBiggestFeePoland = Temp;
    }
    public void MostExpensiveCompany()
    {
        long Temp = Companies[0].CompanyPrice;
        for(int i = 0; i < Companies.Count; i++)
        {
            if(Temp <= Companies[i].CompanyPrice)
            {
                Temp = Companies[i].CompanyPrice;
            }
        }
        GamePlay.GamePlayInstance.Player.PlayerMostExpCompanyPoland = Temp;
    }
}
