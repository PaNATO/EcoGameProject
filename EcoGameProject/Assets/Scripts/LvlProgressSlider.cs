﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlProgressSlider : MonoBehaviour
{
    public Slider LvlProgress;

    public void SetLvlRequired(float RequiredLvl)
    {
        LvlProgress.maxValue = RequiredLvl;
        LvlProgress.value = 0;
    }
    public void SetLvlGot(float LvlAmmount)
    {
        LvlProgress.value = LvlAmmount;
    }
}
