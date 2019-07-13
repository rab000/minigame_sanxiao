using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NTODO 用来扩展不同路径的加载

public class LoadMgr : MonoSingleton<LoadMgr>
{
    public GameObject Load(string path)
    {
        var go = GameObject.Instantiate( Resources.Load(path)) as GameObject;

        return go;
    }
}
