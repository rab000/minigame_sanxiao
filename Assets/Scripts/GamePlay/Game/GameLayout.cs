using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 局内自适应计算
/// </summary>
public class GameLayout : MonoBehaviour
{

    private static int _ScreenW;
    public static int ScreenW
    {
        get
        {
            return Screen.width;
        }
    }
    private static int _ScreenH;
    public static int ScreenH
    {
        get
        {
            return Screen.width;
        }
    }

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

    //默认camera.size
    private const float DEFAULT_CAM_SIZE = 5f;
    //默认参考分辨率
    private const float DEFAULT_SCREEN_W = 750f;
    private const float DEFAULT_SCREEN_H = 1334f;
    private const float DEFAULT_W = DEFAULT_SCREEN_W / DEFAULT_SCREEN_H * DEFAULT_CAM_SIZE * 2;
   

    //手牌区左右间隔(相对于手牌GridSize的倍数)
    private const float SEL_CARDS_AREA_X_SPACE = 0.8f;// 0.8倍 card.size
    //手牌区上下间隔(相对于手牌GridSize的倍数)
    private const float SEL_CARDS_AREA_Y_SPACE = 0.8f;
    //手牌区手牌间隔(相对于手牌GridSize的倍数)
    private const float SEL_CARDS_SPACE = 0.2f;
    //手牌数
    public static int SelCardNum = 6;
    //牌 边缘间隔(piece.size的倍数),与手牌不同，上下左右间隔必须一致，手牌可以不一致
    private const float SPACE_PIECE_AREA_BOUNDER_SPACE = 0.5f;
    //牌 XY方向间隔(piece.size的倍数)
    private const float SpacePiece = 0.2f;


    //缓存layout，只计算一次就缓存起来
    public static Dictionary<string, TLayout> LayoutDic = new Dictionary<string, TLayout>();

    /// <summary>
    /// 获取布局
    /// </summary>
    /// <param name="pieceXNum">地图宽高</param>
    /// <param name="selCardNum">手牌数</param>
    public static TLayout GetLayout(int pieceXNum, int selCardNum)
    {
        int key = (pieceXNum << 16) + selCardNum;
        string skey = key.ToString();
        if (LayoutDic.ContainsKey(skey))
        {
            return LayoutDic[skey];
        }
        else
        {
            return GenerateLayout(pieceXNum, selCardNum);
        }
    }

    private static TLayout GenerateLayout(int pieceXNum, int selCardNum)
    {
        TLayout layout = new TLayout();
        //相机
        layout.CamSize = DEFAULT_W * ScreenW / ScreenH;
        //棋盘
        layout.BoardAreaW = ScreenW;
        layout.BoardAreaH = layout.BoardAreaW;
        //手牌区
        layout.SelCardAreaW = ScreenW;
        layout.SelCardSize = layout.SelCardAreaW / (SEL_CARDS_AREA_X_SPACE * 2 + (SelCardNum - 1) * SEL_CARDS_SPACE + SelCardNum);
        layout.SelCardAreaH = layout.SelCardSize * (1 + SEL_CARDS_AREA_Y_SPACE * 2);
        //游戏区
        layout.CameAreaW = ScreenW;
        layout.CameAreaH = layout.BoardAreaH + layout.SelCardAreaH;
        layout.GameAreaTop = layout.CameAreaH / 2;
        layout.GameAreaDown = -layout.CameAreaH / 2;
        layout.GameAreaLeft = -layout.CameAreaW / 2;
        layout.GameAreaRight = layout.CameAreaW / 2;

        layout.BoardAreaStartPos = new Vector3(-HalfScreenW, layout.GameAreaTop, 0);
        layout.SelCardAreaStartPos = new Vector3(-HalfScreenW, layout.GameAreaDown+ layout.SelCardAreaH, 0);

        //手牌
        layout.PieceSize = layout.BoardAreaW / (SPACE_PIECE_AREA_BOUNDER_SPACE * 2 + (pieceXNum - 1) * SpacePiece + pieceXNum);
        //NTODO 计算手牌起始点

        return layout;
    }

}

public struct TLayout
{
    //(正交)相机Size
    public float CamSize;
    //棋盘区域宽度
    public float BoardAreaW;
    //棋盘区域高
    public float BoardAreaH;
    //棋盘区起始位置
    public Vector3 BoardAreaStartPos;
    //手牌区宽
    public float SelCardAreaW;
    //手牌大小
    public float SelCardSize;
    //手牌区高
    public float SelCardAreaH;
    //手牌区起始位置
    public Vector3 SelCardAreaStartPos;
    //游戏区域(棋盘+手牌)宽
    public float CameAreaW;
    //游戏区域(棋盘+手牌)高
    public float CameAreaH;
    //游戏区域边界
    public float GameAreaTop;
    public float GameAreaDown;
    public float GameAreaLeft;
    public float GameAreaRight;
    //牌大小
    public float PieceSize;
    //牌起始位置0，0
    public Vector3 PieceStartPos;

}