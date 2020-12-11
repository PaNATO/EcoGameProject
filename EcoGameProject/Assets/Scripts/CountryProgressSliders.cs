using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountryProgressSliders : MonoBehaviour
{
    public Slider CitiesProgress;

    public void SetCitiesAmmount(int Ammount1)
    {
        CitiesProgress.maxValue = Ammount1;
        CitiesProgress.value = 0;
    }
    public void SetCitiesBought(int City1B)
    {
        CitiesProgress.value = City1B;
    }
}
