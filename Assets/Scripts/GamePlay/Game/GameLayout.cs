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


    private static float GameAreaTop;
    private static float GameAreaLeft;
    private static float GameAreaRight;
    private static float GameAreaBottom;
    private static float GameAreaWidth;
    private static float GameAreaHeight;

    private static float OrignalTileW = 64f;//世界单位
    private static float OrignalTileH = 64f;

    private const int MAX_NUM = 9;
    private const float SpaceH_Scaler = 0.1f;
    private static float SpaceH = OrignalTileH * SpaceH_Scaler;

    private const float BoundSpaceH = 0.5f;

    public static TLayout Caculate(Vector3 topHudPos,Vector3 downHudPos)
    {
        TLayout layout = new TLayout();

        //计算背景块大小
        //var h = OrignalTileH * MAX_NUM;
        //float scale = h / GameAreaHeight;


        //未适配前H
        var h = OrignalTileH * MAX_NUM + SpaceH * (MAX_NUM - 1) + BoundSpaceH * 2;

        float scale = h / GameAreaHeight;

        //计算后tileSize，tile的大小需要
        float TargetTileH = OrignalTileH * scale;
        float TargetTileW = OrignalTileW * scale;


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