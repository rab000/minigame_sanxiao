using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class UIWin : UIBase {

    public Action OnOpen;

    public Action OnClose;

    protected virtual void OnInitData()
    {
    }

    protected virtual void OnInitUI()
    {
    }

    public override void Open()
    {
        InitData(() => {
            InitUI();
        });
    }

    private void InitData(Action initDataEnd)
    {

        //Debug.Log("UIWin.InitData");
        OnInitData();

        initDataEnd?.Invoke();
    }

    private void InitUI()
    {
        //Debug.Log("UIWin.InitUI");

        OnInitUI();

        OnOpen?.Invoke();

    }

    public override void Close(bool destroy = false)
    {
        if (destroy)
            Dispose();
        else
            gameObject.SetActive(false);

    }

    public override void Dispose()
    {
        Destroy(gameObject);
    }
}
