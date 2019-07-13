using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//NTODO 用来扩展不同路径的加载

public class LoadMgr : MonoSingleton<LoadMgr>
{
    public GameObject Load(string path)
    {
        var go = GameObject.Instantiate( Resources.Load(path)) as GameObject;

        return go;
    }

    public void LoadMapdate(int level,Action<int[]> callback)
    {
        var date = SimulateMapDate.TestMapdate;

        callback?.Invoke(date);
    }

}
