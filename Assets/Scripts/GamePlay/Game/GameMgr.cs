using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoSingleton<GameMgr>
{
    private static GameObject BoardGo;

    private Transform bgTileRoot;

    private Transform tileRoot;

    private int CurLevel = 0;

    #region fsm
    public enum GameState
    {
        init,
        gaming,
        result,
        NULL
    }

    GameState curState = GameState.NULL;

    GameState preState = GameState.NULL;

    public void SetState(GameState state)
    {
        if (state == curState) return;

        Log.i("GameMgr.SetState:" + state);

        preState = curState;
        StateExit(preState);
        curState = state;

        switch (curState)
        {
            case GameState.init:
                Init();
                break;
            default:
                break;
        }
    }

    public bool IsCurState(GameState state)
    {
        if (curState == state) return true;
        else return false;
    }

    public void tStateUpdate()
    {
        StateUpdate();
    }

    public void StateUpdate()
    {
        switch (curState)
        {
            default:
                break;
        }
    }

    void StateExit(GameState preState)
    {

        Log.i("StateExit执行退出状态:" + preState);
        switch (preState)
        {
            default:
                break;
        }
    }

    #endregion

    #region open,close
    private void Open(int level)
    {
        CurLevel = level;
        SetState(GameState.init);
    }

    //竞品中是退回到主界面才进入下一关，不存在转场
    public void Switch(int level)
    {
        //NTODO 先处理当前关卡释放回收

        CurLevel = level;

        //SetState("Switch");
    }

    public void Exit()
    {

    }

    #endregion

    #region init

    private void Init()
    {
        UIManager.Ins.OpenWin("gameui", true, () =>
        {
            InitAfterUICreate();
        });
    }

    private void InitAfterUICreate()
    {
        //计算布局

        var gameui = UIManager.Ins.GetWindow<GameUI>("gameui");

        TLayout layout = GameLayout.Caculate(gameui.TopHudPos,gameui.DownHudPos);

        //创建节点

        //载入关卡数据

        //刷bg

        //刷tile
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

    #endregion

    public void Dispose()
    {
        CurLevel = 0;
        curState = GameState.NULL;
        preState = GameState.NULL;
    }

}
