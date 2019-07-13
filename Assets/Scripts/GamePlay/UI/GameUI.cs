using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : UIWin
{
    [HideInInspector]public Vector3 TopHudPos;

    [HideInInspector]public Vector3 DownHudPos;

    private Transform TopHudTrm;

    private Transform DownHudTrm;

    void Awake()
    {
        TopHudTrm = transform.Find("top/topHud");
        TopHudPos = TopHudTrm.position;
        DownHudTrm = transform.Find("down/downHud");
        DownHudPos = DownHudTrm.position;
    }

    
}
