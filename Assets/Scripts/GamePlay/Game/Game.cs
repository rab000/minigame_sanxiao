using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private bool bShowLog = true;

    public string RoomID;

    private Board CurBoard;

    private CardMgr CurCards;

    public static Game Ins;

    void Awake()
    {
        Ins = this;
    }

    void OnDestory()
    {
        Ins = null;
    }
        

    public void CreateRoom(string roomID)
    {
        bool bRoomExist = DataMgr.BeDataExist("room", roomID);

        if (bRoomExist)
        {
            Log.e("Room", "Create", "房间id:" + roomID + "存在，创建房间失败！", bShowLog);
            return;
        }

        RoomData roomData = new RoomData("room");

        CurBoard = Board.CreateBoard(transform);

        CurCards = CurBoard.GetCardMgr();

        
    }

    public void OpenRoom(string roomID)
    {
        bool bRoomExist = DataMgr.BeDataExist("room", roomID);

        if (!bRoomExist)
        {
            Log.e("Room","Open","房间id:"+roomID+"打开房间失败！",bShowLog);
            return;
        }

        var roomData = DataMgr.GetData<RoomData>("room",roomID);

        CurBoard = Board.CreateBoard(transform);

        //NTODO 填充棋牌

        //NTODO 恢复手牌



    }

    //切换牌局(换房间)
    public void SwitchBoard()
    {

    }

}
