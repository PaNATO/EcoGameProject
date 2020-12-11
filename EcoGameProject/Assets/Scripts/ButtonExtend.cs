using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ButtonExtend
{
    public static void SpecialEventListener<T>(this Button button, T param, Action<T> onClicked)
    {
        button.onClick.AddListener(delegate ()
        {
            onClicked(param);
        });
    }
}
