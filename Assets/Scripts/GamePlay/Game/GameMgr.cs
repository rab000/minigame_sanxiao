using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoSingleton<GameMgr>
{
    private static GameObject BoardGo;
    
    [SerializeField] private Transform bgTileRoot;

    [SerializeField] private Transform tileRoot;

    [SerializeField] private Transform bgSelRoot;

    private void Create(MapDate date)
    {
       
    }

    public void Switch()
    {

    }

    public void Exit()
    {

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

    public void Dispose()
    {

    }

}
