using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : UIWin
{
    [HideInInspector]public Vector3 TopHudPos;

    [HideInInspector]public Vector3 DownHudPos;

    private Transform TopHudTrm;

    private Transform DownHudTrm;

    public override void Awake()
    {
        base.Awake();
        //NTODO 下一步，这两个值拿的值与世界坐标有差距，这个时ui的世界坐标，跟3d不符
        //貌似缺个ui世界坐标，到spr世界坐标的转换
        TopHudTrm = transform.Find("top/topHud");
        TopHudPos = TopHudTrm.position;
        DownHudTrm = transform.Find("down/downHud");
        DownHudPos = DownHudTrm.position;
        Debug.Log("gameui init posTop:"+ TopHudPos+" posDown:"+ DownHudPos);

        
         
    }

    
}
