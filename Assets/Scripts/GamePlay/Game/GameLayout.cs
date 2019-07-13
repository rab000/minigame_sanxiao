using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayout : MonoBehaviour
{   
    //private static int _HalfScreenW=-1;
    //public static int HalfScreenW
    //{
    //    get
    //    {
    //        if (_HalfScreenW == -1)
    //        {
    //            _HalfScreenW = (Screen.width << 1);
    //        }

    //        return _HalfScreenW;
    //    }
    //}
    //private static int _HalfScreenH = -1;
    //public static int HalfScreenH
    //{
    //    get
    //    {
    //        if (_HalfScreenH == -1)
    //        {
    //            _HalfScreenH = (Screen.height << 1);
    //        }
    //        return _HalfScreenH;
    //    }
    //}
    //private const float DEFAULT_SCREEN_W = 720f;
    //private const float DEFAULT_SCREEN_H = 1280f;

    //tile原始大小，unity单位，64pixel, 100p/unit

    public const float OrignalTileW = 0.64f;
    public const float OrignalTileH = 0.64f;
    //这个值是原始块的aspect，也是游戏区域的aspect(行列最大数相同的情况下)
    private const float OrignalTileAspect = OrignalTileH / OrignalTileW;

    //可用游戏区距离屏幕两端世界距离
    private const float BoundSpaceW = 0f;

    //行列最大tile数
    private const int MAX_NUM = 9;

    private const float SpaceH_Scaler = 0.1f;

    private static float SpaceH = OrignalTileH * SpaceH_Scaler;

    private const float BoundSpaceH = 0.5f;

    public static TLayout Caculate(Vector3 topHudPos,Vector3 downHudPos)
    {
        TLayout layout = new TLayout();

        //--------------------游戏可用区域
        Vector3 sub = topHudPos - downHudPos;
        layout.UseableGameAreaH = sub.y;
        layout.UseableGameAreaW = CameraMgr.CameraW - BoundSpaceW*2f;
        layout.UseableGameAreaLeft = 0 + BoundSpaceW;
        layout.UseableGameAreaRight = layout.UseableGameAreaLeft + layout.UseableGameAreaW;
        layout.UseableGameAreaTop = topHudPos.y;
        layout.UseableGameAreaDown = downHudPos.y;
        layout.UseableGameAreaAspect = layout.UseableGameAreaH / layout.UseableGameAreaW;
        layout.UseableGameAreaCenterX = layout.UseableGameAreaLeft + layout.UseableGameAreaW / 2;
        layout.UseableGameAreaCenterY = layout.UseableGameAreaTop + layout.UseableGameAreaH / 2;

        //--------------------自适应后tile大小
        //tile为自适应需要缩放的scale
        float tileScale = 1f;

        bool bAutoSizeW = layout.UseableGameAreaAspect > OrignalTileAspect ? true : false;
        if (bAutoSizeW)
        {
            //可用区域aspect大于游戏区域(单个块的aspect)，以w为基准进行计算
            var w = OrignalTileW * MAX_NUM;
            tileScale = w / layout.UseableGameAreaW;
        }
        else
        {
            //可用区域aspect小于游戏区域(单个块的aspect)，以h为基准进行计算
            var h = OrignalTileH * MAX_NUM;
            tileScale = h / layout.UseableGameAreaH;
        }
        //自适应后tile的H,W
        layout.TileH = OrignalTileH * tileScale;
        layout.TileW = OrignalTileW * tileScale;

        //---------------------游戏区域
        layout.GameAreaH = layout.TileH * MAX_NUM;
        layout.GameAreaW = layout.TileW * MAX_NUM;
        if (bAutoSizeW)
        {
            layout.GameAreaLeft = layout.UseableGameAreaLeft;
            layout.GameAreaRight = layout.UseableGameAreaRight;
            layout.GameAreaTop = layout.UseableGameAreaCenterY + layout.GameAreaH /2;
            layout.GameAreaDown = layout.UseableGameAreaCenterY - layout.GameAreaH /2;
        }
        else
        {
            layout.GameAreaTop = layout.UseableGameAreaTop;
            layout.GameAreaDown = layout.UseableGameAreaDown;
            layout.GameAreaLeft = layout.UseableGameAreaCenterX - layout.GameAreaW / 2 ; 
            layout.GameAreaRight = layout.UseableGameAreaCenterX + layout.GameAreaW / 2; 
        }

        layout.TileStartPos = new Vector3(layout.GameAreaLeft, layout.GameAreaTop, 0);

        return layout;

    }

}

public struct TLayout
{

    public float UseableGameAreaW;
    public float UseableGameAreaH;
    public float UseableGameAreaAspect;

    public float UseableGameAreaTop;
    public float UseableGameAreaDown;
    public float UseableGameAreaLeft;
    public float UseableGameAreaRight;

    //可用区域中心，与游戏区域中心是一个值
    public float UseableGameAreaCenterX;
    public float UseableGameAreaCenterY;

    public float GameAreaW;
    public float GameAreaH;
    public float GameAreaTop;
    public float GameAreaDown;
    public float GameAreaLeft;
    public float GameAreaRight;

    public float TileW;
    public float TileH;

    public Vector3 TileStartPos;

}