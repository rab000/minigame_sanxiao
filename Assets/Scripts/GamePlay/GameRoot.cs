using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoSingleton<GameRoot>
{

    private static GameRoot Ins;

    [HideInInspector]public Transform GameRootTrm;

    public static GameRoot GetIns()
    {
        return Ins;
    }

    void Awake()
    {
        Ins = this;
    }

    void OnDestroy()
    {
        Ins = null;
    }

    void Start()
    {
        var go = new GameObject("appMgr");
        go.AddComponent<ThreadManager>();
        go.AddComponent<AppMgr>();
        go.transform.SetParent(transform);
        GameRootTrm = go.transform;

        go = new GameObject("gopool");
        go.AddComponent<Gopool>();
        go.transform.SetParent(transform);

        //net

        //other

    }

}
