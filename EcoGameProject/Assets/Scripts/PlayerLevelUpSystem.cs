using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine;
using System.Linq;

public class PlayerLevelUpSystem : MonoBehaviour
{
    public static PlayerLevelUpSystem PlayerLevelUpSystemInstance;
    [SerializeField]
    Text PlayerLvl;
    public int PLvl;

    public void Awake()
    {
        if (PlayerLevelUpSystemInstance == null)
            PlayerLevelUpSystemInstance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerLvl.text = "LVL: " +PLvl.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EarnXpOnClick()
    {
        PLvl += 1;
        PlayerLvl.text = "LVL: " + PLvl.ToString();
    }
    public bool GotRequiredXp(object CName)
    {
        //CName = this;
        while ((int.Parse(CName.ToString())) <= PLvl)
        {
            Debug.Log("LVL się zgadza?: Tak");
            return true;
        }
            Debug.Log("LVL się zgadza?: Nie");
            return false;
    }
}
