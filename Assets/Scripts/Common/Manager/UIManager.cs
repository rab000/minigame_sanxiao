using UnityEngine;
using System.Collections.Generic;
using System;
/// <summary>
/// UI管理器
/// 1 包含所有UI Window的引用
/// 2 控制UI 显示，隐藏
/// </summary>
public class UIManager : MonoSingleton<UIManager> {
	
	private static bool BeShowLog = true;

    private static string Path = "Prefabs/ui/win/"; 

    #region mono

    Canvas _Canvas;

    Transform WinTrm;

    protected override void Awake()
    {
        base.Awake();
        var canvasGo = GameObject.Find("Canvas");
        var canvasTrm = canvasGo.transform;
        _Canvas = canvasGo.GetComponent<Canvas>();
        WinTrm = canvasTrm.Find("winroot");
        
    }

	#endregion 


	#region win

	private UIWin CurWin;

    private string PreWinName;

	private Dictionary<string,UIWin> winDic = new Dictionary<string,UIWin>();

    public T Open<T>(string winName,Action OnOpen = null)where T: UIWin
    {
        T win;

		if (winDic.ContainsKey (winName)) 
		{
			Log.i ("UIManager", "OpenWin", "打开已存在win winName" + winName, BeShowLog);
            winDic[winName].gameObject.SetActive(true);

            winDic[winName].OnOpen = OnOpen;

            winDic [winName].Open();

            win = winDic[winName] as T;

        }
		else
		{
			Log.i ("UIManager", "OpenWin", "打开不存在win winName" + winName, BeShowLog);

			var winGo = Instantiate(LoadMgr.Ins.Load (Path + winName)) as GameObject;

			winGo.transform.SetParent (WinTrm,false);

		    win = winGo.GetComponent<T> ();

            win.OnOpen = OnOpen;

            CurWin = win;

			winDic.Add (winName, win);

            win.Open();

        }

        return win;
	}

	public void CloseCurWin(bool destroy = true)
	{
		if (null != CurWin)
		{
			if (destroy) 
			{
				if(winDic.ContainsKey(CurWin.Name))winDic.Remove (CurWin.Name);
				else 
					Log.e ("UIManager", "CloseCurWin", "关闭当前窗口时发现"+CurWin.Name+"不存在",BeShowLog);
			}

			CurWin.Close (destroy);
		}
			
		else 
		{
			Log.i ("UIManager", "CloseCurWin", "CurWin=null",BeShowLog);
		}
	}

	public void CloseWin(string winName,bool destroy = true)
	{
		if (winDic.ContainsKey (winName))
		{
			
			UIWin win = winDic [winName];

			winDic.Remove (winName);

			win.Close (destroy);
		}
		else 
		{
			Log.e ("UIManager", "CloseWin", "尝试关闭不存在的win name:"+winName, BeShowLog);
		}
	}

	public T GetCurWin<T>() where T : class
	{
		return (T)Convert.ChangeType(CurWin, typeof(T));
	}

	public T GetWindow<T>(string winName)where T : class
	{
		if(winDic.ContainsKey(winName))
		{
			return (T)Convert.ChangeType(winDic[winName], typeof(T));
		}
		else
		{
			Log.e ("UIManager", "GetWindow", "没找到名字为"+winName+"的窗口",BeShowLog);

			return default(T);
		}
	}

	#endregion


}
