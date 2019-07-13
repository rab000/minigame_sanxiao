using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//safeArea

//operatableGameArea

public class GameLayout : MonoBehaviour
{   
    private static int _HalfScreenW=-1;
    public static int HalfScreenW
    {
        get
        {
            if (_HalfScreenW == -1)
            {
                _HalfScreenW = (Screen.width << 1);
            }

            return _HalfScreenW;
        }
    }
    private static int _HalfScreenH = -1;
    public static int HalfScreenH
    {
        get
        {
            if (_HalfScreenH == -1)
            {
                _HalfScreenH = (Screen.height << 1);
            }
            return _HalfScreenH;
        }
    }
    private const float DEFAULT_SCREEN_W = 720f;
    private const float DEFAULT_SCREEN_H = 1280f;


    //private static float GameAreaTop;
    //private static float GameAreaLeft;
    //private static float GameAreaRight;
    //private static float GameAreaBottom;
    //private static float GameAreaWidth;
    //private static float GameAreaHeight;

    //tile原始大小，unity单位，64pixel, 100p/unit
    private const float OrignalTileW = 0.64f;
    private const float OrignalTileH = 0.64f;
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

        //--------------------自适应后tile大小
        //tile为自适应需要缩放的scale
        float tileScale = 1f;
        if (layout.UseableGameAreaAspect > OrignalTileAspect)
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



        //---------------------游戏区域左上点，用于填充tile时，确定(0,0)点位置


        //游戏区域需要确定下用x计算还是y计算,取决于可用游戏区域，与块的长宽比
        //

        //可用游戏区域H基本>W,游戏区域aspect取决于块本身长宽比

        //计算背景块大小
        //var h = OrignalTileH * MAX_NUM;
        //float scale = h / GameAreaHeight;


        //未适配前H
        //var h = OrignalTileH * MAX_NUM + SpaceH * (MAX_NUM - 1) + BoundSpaceH * 2;

        //float scale = h / GameAreaHeight;

        //计算后tileSize，tile的大小需要
        //float TargetTileH = OrignalTileH * scale;
        //float TargetTileW = OrignalTileW * scale;


        //开始计算中心点和左上点
        //游戏区上下减就是中心，那么左上在哪，上左加间隔


        //那么问题来了，前置的GameArea属性如何计算

        //这里有个概念，是游戏可用区域，而不是真实游戏区域

        //可用区域，直接上下锚点绝对位置+-一个固定间隔，这个间隔怎么确定，可以先用固定值，也可以是比例

        //因为游戏类型的原因游戏真实高度，就是可操作游戏区域高度，这个没毛病


        //接下来的问题，top，down ui会决定游戏区范围，能否在游戏开始前就计算
        //ui高度是固定死的还是按比例

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