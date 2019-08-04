using UnityEngine;

public class TileFactory
{
    public static GameObject CreateTile(int type)
    {

        GameObject go = null;

        switch (type)
        {
            case 1:
                go = GameObject.Instantiate(LoadMgr.Ins.Load("Prefabs/game/colorTile_blue")) as GameObject;
                break;
            case 2:
                go = GameObject.Instantiate(LoadMgr.Ins.Load("Prefabs/game/colorTile_green")) as GameObject;
                break;
            case 3:
                go = GameObject.Instantiate(LoadMgr.Ins.Load("Prefabs/game/colorTile_orange")) as GameObject;
                break;
            case 4:
                go = GameObject.Instantiate(LoadMgr.Ins.Load("Prefabs/game/colorTile_red")) as GameObject;
                break;
            case 5:
                go = GameObject.Instantiate(LoadMgr.Ins.Load("Prefabs/game/colorTile_yellow")) as GameObject;
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
                go = GameObject.Instantiate(LoadMgr.Ins.Load("Prefabs/game/bgTile")) as GameObject;
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