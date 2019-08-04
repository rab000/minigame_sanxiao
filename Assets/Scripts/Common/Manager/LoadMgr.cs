using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class LoadMgr : MonoSingleton<LoadMgr>
{
    public UnityEngine.Object Load(string path)
    {
        var obj = Resources.Load(path);
       
        return obj;
    }

    public void LoadMapdate(int level,Action<int[]> callback)
    {
        var date = SimulateMapDate.TestMapdate;

        callback?.Invoke(date);
    }

}
