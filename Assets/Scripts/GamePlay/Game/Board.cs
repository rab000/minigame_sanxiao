using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private static GameObject BoardGo;
    
    [SerializeField] private Transform bgTileRoot;

    [SerializeField] private Transform tileRoot;

    [SerializeField] private Transform bgSelRoot;

    private int mapSize;

    void Start()
    {
        Debug.Log("Board. start");
    }

    public static Board CreateBoard(Transform parentTrm, int mapSize = 10)
    {

        if (null == BoardGo)
        {
            BoardGo = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/game/board"));
            BoardGo.name = "board";
        }
        else
        {
            BoardGo.SetActive(true);
        }

        BoardGo.transform.SetParent(parentTrm);

        var _board = BoardGo.GetComponent<Board>();

        _board.mapSize = mapSize;

        _board.FillBgTile(mapSize);

        _board.FillSelTile(mapSize);

        return _board;

    }

    private void FillBgTile(int mapSize)
    {
        //需要解决起始点与间距问题

        //起始点就是中心点-bgWidth/2的偏移量

        //间距首先要确定两边间距，然后计算tileSize，和tile间间距

        GameObject tempGo = null;

        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                tempGo = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/game/bgTile"));

                tempGo.transform.SetParent(bgTileRoot);

                //tempGo.transform.position = Vector3.zero;

                
            }
        }
        

    }

    private void FillSelTile(int mapSize)
    {

    }

    /// <summary>
    /// 清理棋子
    /// </summary>
    public void ClearTile()
    {
        //棋子回池
    }

    /// <summary>
    /// 清理手牌
    /// </summary>
    public void ClearSelTile()
    {
        //棋子回池
    }

    public CardMgr GetCardMgr()
    {
        return bgSelRoot.gameObject.GetComponent<CardMgr>();
    }

    public void Dispose()
    {

    }
}
