using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class UIWin : UIBase {

    public Action OnOpen;

    public Action OnClose;

    public Action<Action> OnPlayOpenAnim;

    public Action<Action> OnPlayCloseAnim;

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

        //播放打开动画

        if (null != OnPlayOpenAnim)
        {
            OnPlayOpenAnim(() =>
            {
                OnOpen?.Invoke();
            });
        }
        else
        {
            OnOpen?.Invoke();
        }

    }


    protected virtual void PlayOpenAnim()
    {

    }

    //播放打开关闭动画

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
