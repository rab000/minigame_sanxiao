using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AppMgr : MonoSingleton<AppMgr>
{

    void Start()
    {
        SetState(AppState.Game);
    }

    #region 游戏状态机

    public enum AppState
    {
       MainMenu,
       Game,
       NULL
    }

    AppState curState = AppState.NULL;
    AppState preState = AppState.NULL;

    public void SetState(AppState state)
    {
        if (state == curState) return;

        Log.i("SetState切换状态到:" + state);

        preState = curState;
        StateExit(preState);
        curState = state;

        switch (curState)
        {
            case AppState.Game:
                UIManager.Ins.OpenWin("gameui");
                //GameMgr.Ins.
                break;
            default:
                break;
        }
    }

    public bool IsCurState(AppState state)
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

    void StateExit(AppState preState)
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
