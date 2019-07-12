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
    private const float DEFAULT_CAM_HALF_H = 5f;
    private const float DEFAULT_CAM_H = DEFAULT_CAM_HALF_H * 2;
    private const float DEFAULT_CAM_W = DEFAULT_SCREEN_W / DEFAULT_SCREEN_H * DEFAULT_CAM_H;
   
    private static TLayout GenerateLayout()
    {
        TLayout layout = new TLayout();
        return layout;
    }

    private static float GameAreaTop;
    private static float GameAreaLeft;
    private static float GameAreaRight;
    private static float GameAreaBottom;
    private static float GameAreaWidth;
    private static float GameAreaHeight;

    private static float OrignalTileW;//世界单位
    private static float OrignalTileH;

    private const int MAX_NUM = 9;
    private const float SpaceH_Scaler = 0.1f;
    private static float SpaceH = OrignalTileH * SpaceH_Scaler;

    private const float BoundSpaceH = 0.5f;

    public static void Caculate()
    {
        //未适配前H
        var h = OrignalTileH * MAX_NUM + SpaceH * (MAX_NUM - 1) + BoundSpaceH * 2;

        float scale = h / GameAreaHeight;

        //计算后tileSize
        float TargetTileH = OrignalTileH * scale;
        float TargetTileW = OrignalTileW * scale;



    }

}

public struct TLayout
{
    public float CamSize;
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