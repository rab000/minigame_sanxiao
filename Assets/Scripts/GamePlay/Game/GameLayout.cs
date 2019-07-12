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

    private static float TileW;//世界单位
    private static float TileH;

    public static void Caculate()
    {

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