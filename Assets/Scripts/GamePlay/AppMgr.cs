using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AppMgr : MonoBehaviour
{

    #region 单例
    static AppMgr ins;
    public static AppMgr GetIns() { return ins; }
    void Awake()
    {
        ins = this;
        //PoolsMgr.Init();
        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            NTest();
        }
    }

    void OnDestroy() { ins = null; }
    #endregion


    #region 游戏状态机

    public enum GameState
    {
       a,
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

    //NTEST 模拟创建房间
    public void NTest()
    {
       
    }

    
}
