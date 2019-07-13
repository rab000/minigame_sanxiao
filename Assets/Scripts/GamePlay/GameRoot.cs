using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoSingleton<GameRoot>
{

    [HideInInspector]public Transform GameRootTrm;

    void Start()
    {
        var go = gameObject;
        go.AddComponent<ThreadManager>();
        go.AddComponent<LoadMgr>();
        go.AddComponent<AppMgr>();
        go.AddComponent<UIManager>();
        go.AddComponent<GameMgr>();
        GameRootTrm = go.transform;

        go = new GameObject("gopool");
        go.AddComponent<Gopool>();
        go.transform.SetParent(transform);

        //net

        //other

    }



}
