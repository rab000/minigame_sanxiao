using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoSingleton<GameMgr>
{
    
    private Transform bgTileRoot;

    private Transform tileRoot;

    private int CurLevel = 0;

    private TLayout layout;

    protected override void Awake()
    {
        base.Awake();

        //创建节点
        CreateGameRoot();
    }

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
    public void Open(int level)
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

    //这里要考虑下二次创建，switch时这个流程问题
    //两种切换方式，遮挡切换，不遮挡切换，不能用非遮挡，因为地图形状不同，不方便过度
    //所以一般处理是遮挡(toon)或者退出到menu(消消乐)

    private void CreateGameRoot()
    {
        
        if (null == bgTileRoot)
        {
            var bgTileRootGo = new GameObject("bgTileRoot");
            bgTileRoot = bgTileRootGo.transform;
            bgTileRoot.SetParent(transform, false);
        }

        if (null == tileRoot)
        {
            GameObject tileRootGo = new GameObject("tileRoot");
            tileRoot = tileRootGo.transform;
            tileRoot.SetParent(transform, false);
        }

    }

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

        layout = GameLayout.CaculateLayout(gameui.TopHudPos,gameui.DownHudPos);

        //NTODO 载入关卡数据
        LoadMgr.Ins.LoadMapdate(CurLevel, InitMap);

    }

    private void InitMap(int[] mapdate)
    {
        for (int y = 0; y < GameLayout.MAX_NUM; y++)
        {
            for (int x = 0; x < GameLayout.MAX_NUM; x++)
            {
                int index = y * GameLayout.MAX_NUM + x;

                int mapValue = mapdate[index];

                GenerateBgTile(mapValue,x,y);

                GenerateTile(mapValue,x,y);

            }
        }

    }

   

    private void GenerateBgTile(int mapValue,int gridX,int gridY)
    {
        //NTODO bgTile外显的计算

        //形容下bgTile的特殊处
        //left，down，right都有方块时，具体的ui取决与bgTile是否在边缘，

        var go = LoadMgr.Ins.Load("Prefabs/game/bgTile");


        var trm = go.transform;
        go.transform.SetParent(bgTileRoot,false);

        Vector3 pos = layout.TileStartPos;
        
        float offx = gridX * layout.TileW;
        float offy = gridY * layout.TileH;

        //var gg = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //gg.name = "sspp";
        //gg.transform.position = pos;
        //gg.transform.localScale = Vector3.one * 5;


        Debug.Log("wh:"+ layout.TileW+" h:"+ layout.TileH);

        pos.x = pos.x + offx;
        pos.y = pos.y - offy;
        pos.z = 0;

        go.transform.position = pos;

    }

    private void GenerateTile(int mapValue, int gridX, int gridY)
    {

    }

    #endregion

    public void Clean()
    {
        CurLevel = 0;
        curState = GameState.NULL;
        preState = GameState.NULL;
    }

    //gameMgr,不退出游戏一般不用完整销毁，切关卡清理即可
    //public void Dispose()
    //{
        
    //}

}
