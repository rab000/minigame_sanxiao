using UnityEngine;
using System.Collections.Generic;
using System;
/// <summary>
/// UI管理器
/// 1 包含所有UI Window的引用
/// 2 控制UI 显示，隐藏
/// </summary>
public class UIManager : MonoBehaviour {
	
	private static bool BeShowLog = true;

	#region mono

	static UIManager ins;

	void Awake(){ins = this;}

	void OnDestroy(){ins = null;}

	public static UIManager GetIns(){return ins;}

    [SerializeField] Canvas _Canvas;

    [SerializeField]Transform WinTrm;

	[SerializeField]Transform PanelTrm;

	#endregion 


	#region win

	private UIWin CurWin;

	private Dictionary<string,UIWin> winDic = new Dictionary<string,UIWin>();

	public void OpenWin(string winName,bool destroyPreWin = true)
	{
		CloseCurWin(destroyPreWin);

		if (winDic.ContainsKey (winName)) 
		{
			Log.i ("UIManager", "OpenWin", "打开已存在win winName" + winName, BeShowLog);
			winDic [winName].OnOpen();

		}
		else
		{
			Log.i ("UIManager", "OpenWin", "打开不存在win winName" + winName, BeShowLog);

			var winGo = Instantiate(Resources.Load ("Prefabs/ui/win/"+winName)) as GameObject;

			winGo.transform.SetParent (WinTrm,false);

			//winDic [winName].OnOpen ();
			UIWin win = winGo.GetComponent<UIWin> ();

			CurWin = win;

			winDic.Add (winName,win);

		}
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

			CurWin.OnClose (destroy);
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

			win.OnClose (destroy);
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


	#region panel

	private Dictionary<string,UIPanel> panelDic = new Dictionary<string,UIPanel>();

	public UIPanel OpenPanel(string panelName)
	{
		UIPanel _panel = null;

		if (panelDic.ContainsKey (panelName)) 
		{
			Log.i ("UIManager", "OpenPanel", "打开已存在panel name" + panelName, BeShowLog);

			panelDic [panelName].OnOpen();

			_panel = panelDic [panelName];

		}
		else
		{
			Log.i ("UIManager", "OpenPanel", "打开不存在panel name" + panelName, BeShowLog);

			var panelGo = Instantiate(Resources.Load ("Prefabs/ui/panel/"+panelName)) as GameObject;

			panelGo.transform.SetParent (PanelTrm,false);

			_panel = panelGo.GetComponent<UIPanel> ();

			panelDic.Add (panelName,_panel);

		}
		//先加载，然后存到dic中
		return _panel;
	}

	public void ClosePanel(string panelName,bool destroy = false)
	{
		if (panelDic.ContainsKey (panelName))
		{
			UIPanel panel = panelDic [panelName];

			panelDic.Remove (panelName);

			panel.OnClose (destroy);

		}
		else 
		{
			Log.e ("UIManager", "ClosePanel", "关闭panel"+panelName+"失败，找不到这个panel",BeShowLog);
		}
	}

	public T GetPanel<T>(string panelName)where T : class
	{
		if(panelDic.ContainsKey(panelName))
		{
			return (T)Convert.ChangeType(panelDic[panelName], typeof(T));
		}
		else
		{
			Log.e ("UIManager", "GetPanel", "没找到名字为"+panelName+"的panel",BeShowLog);

			return default(T);
		}
	}

	#endregion


}
