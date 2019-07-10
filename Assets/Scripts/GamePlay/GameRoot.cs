using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{

    private static GameRoot Ins;

    public Transform GameRootTrm;

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

    }

    void Start()
    {
        var go = new GameObject("gameMgr");
        go.AddComponent<GameMgr>();
        go.AddComponent<Game>();
        go.transform.SetParent(transform);
        GameRootTrm = go.transform;

        //net

        //other

    }

}
