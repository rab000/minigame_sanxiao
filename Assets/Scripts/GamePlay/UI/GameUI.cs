using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : UIWin
{
    public Vector3 TopHudPos {
        get {
            return TopHudTrm.position;
        }
    }

    public Vector3 DownHudPos {
        get
        {
            return DownHudTrm.position;
        }
    }

    private Transform TopHudTrm;

    private Transform DownHudTrm;

    public override void Awake()
    {
        base.Awake();
        TopHudTrm = transform.Find("top/topHud");
        
        DownHudTrm = transform.Find("down/downHud");

    }

    
}
