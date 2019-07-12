using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AppMgr : MonoSingleton<AppMgr>
{

    void Start()
    {
        SetState(GameState.Game);
    }

    #region 游戏状态机

    public enum GameState
    {
       MainMenu,
       Game,
       NULL
    }

    GameState curState = GameState.NULL;
    GameState preState = GameState.NULL;

    public void SetState(GameState state)
    {
        if (state == curState) return;

        Log.i("SetState切换状态到:" + state);

        preState = curState;
        StateExit(preState);
        curState = state;

        switch (curState)
        {
            default:
                break;
        }
    }

    public bool IsCurState(GameState state)
    {
        if (curState == state) return true;
        else return false;
    }

    public void tUpdate()
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

    
}
