using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData :BaseData
{
    public string RoomID;

    //自己手牌
    public byte[] SelfChars;

    //对手手牌
    public byte[] PlayerChars;

    //地图字母位置
    public List<short> MapPos;

    //地图字母
    public List<byte> MapStr;

    //(剩余)字符库
    public Dictionary<short,short> CharsLib;

    public RoomData(string key) : base()
    {
        RoomID = "0";
    }

    

}
