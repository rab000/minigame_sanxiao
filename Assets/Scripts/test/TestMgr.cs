using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
//        UIManager.GetIns().OpenWin("TestWin");
        UIManager.Ins.OpenPanel("test/TestPanel");
//        UIManager.GetIns().OpenPanel("TestPanel2");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
