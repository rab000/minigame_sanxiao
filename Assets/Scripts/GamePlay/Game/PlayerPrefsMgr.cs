using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsMgr
{
    private static int _InitLayout;
    public static int InitLayout
    {
        set
        {
            _InitLayout = value;
            PlayerPrefs.SetInt("InitLayout", _InitLayout);
        }
        get
        {
            return PlayerPrefs.GetInt("InitLayout", 0);
        }
    }

}
