using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGamePlay : MonoBehaviour
{
    public int money = 0;
    [SerializeField]
    Text MoneyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = money.ToString() + "zł";
    }


}
