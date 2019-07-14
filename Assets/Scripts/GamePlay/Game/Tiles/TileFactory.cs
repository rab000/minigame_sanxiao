using UnityEngine;

public class TileFactory
{
    public static GameObject CreateTile(int type)
    {

        GameObject go = null;

        switch (type)
        {
            case 1:
                go = LoadMgr.Ins.Load("Prefabs/game/colorTile_blue");
                break;
            case 2:
                go = LoadMgr.Ins.Load("Prefabs/game/colorTile_green");
                break;
            case 3:
                go = LoadMgr.Ins.Load("Prefabs/game/colorTile_orange");
                break;
            case 4:
                go = LoadMgr.Ins.Load("Prefabs/game/colorTile_red");
                break;
            case 5:
                go = LoadMgr.Ins.Load("Prefabs/game/colorTile_yellow");
                break;
        }

        return go;

    }

    public static GameObject CreateBGTile(int type)
    {
        GameObject go = null;

        switch (type)
        {
            default:
                go = LoadMgr.Ins.Load("Prefabs/game/bgTile");
                break;
        }

        return go;
    }
}

//特殊块收集
//可消除的气球
//下落到底部收集的鸭子
//不能动的木箱
//<附加>到格子上的气泡