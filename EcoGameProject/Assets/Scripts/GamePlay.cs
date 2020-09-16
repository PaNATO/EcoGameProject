using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    //public ArrayList Countries = new ArrayList();
    //public List<Country> Countries = new List<Country>();
    public static GamePlay GamePlayInstance;
    public void Awake()
    {
        if (GamePlayInstance == null)
            GamePlayInstance = this;
        else
            Destroy(gameObject);
    }
                                            //Here i created countries. One by one 13.09.2020 
    public Country Poland = new Country("PolandMap", 0, "PLN");
    Country Slovakia = new Country("CzechMap", 50, "PLN");
    Country Czech = new Country("SlovakiaMap", 100, "PLN");
    public GameObject[] Maps;

    //public void MouseDown()
    //{
     //   if (MapClickedDetection.mapClickedDetectionInstance.Detection() == Maps[0].name)
     //   {
     //       MoneyPLN.instance.EarnPLNOnClick();
     //   }
   // }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //MouseDown();
        MoneyPLN.instance.EarnPLNOnClick();
    }


}
