using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 统一管理数据表
/// by nafio 18.12.06
/// </summary>
public class DataMgr {

	private static bool BeShowLog = false;

	public const string DEFAULT_SUBKEY = "unique";

	private static Dictionary<string,Dictionary<string,BaseData>> DatasDic = new Dictionary<string,Dictionary<string,BaseData>>();


	public static bool BeDataExist(string key,string subkey){

		if (DatasDic.ContainsKey (key)) {
			if (DatasDic [key].ContainsKey (subkey)) {
				return true;
			}
		}

		return false;

	}

	/// <summary>
	/// 获取room_state 数据
	/// </summary>
	/// <returns></returns>
	public static Dictionary<string,BaseData> getRoomStateDatas(){

		if (DatasDic.ContainsKey ("room_state")) {
			return DatasDic["room_state"];
		}
		return null;
	}

	public static T GetData<T>(string key,string subkey=DEFAULT_SUBKEY)  where T : class
	{
		if (DatasDic.ContainsKey (key))
		{
			if (DatasDic [key].ContainsKey (subkey))
			{
				return (T)Convert.ChangeType(DatasDic[key][subkey], typeof(T));
			}

			Log.e ("DataMgr.GetData cant find data subkey:"+key+" subkey:"+subkey);
		}

		Log.e ("DataMgr.GetData cant find data key:"+key);

		return null;

	}

	public static bool GetData<T>(string key,string subkey,out T t)  where T : class
	{
		if (DatasDic.ContainsKey (key))
		{
			if (DatasDic [key].ContainsKey (subkey))
			{

				t = (T)Convert.ChangeType(DatasDic[key][subkey], typeof(T));

				return true;
			}

			if(BeShowLog)Log.e ("DataMgr.GetData cant find data subkey:"+key+" subkey:"+subkey);
		}

		if(BeShowLog)Log.e ("DataMgr.GetData cant find data key:"+key+" subkey:"+subkey);

		t = null;

		return false;

	}


	public static void PutData(string key,BaseData data,string subkey = DEFAULT_SUBKEY)
	{
		if (DatasDic.ContainsKey (key))
		{
			if (!DatasDic [key].ContainsKey (subkey))
			{
				DatasDic [key].Add (subkey, data);
			}
			else
			{
				Log.e ("DataMgr.PutData cant put data  key:"+key+" subkey:"+subkey+" exist!!!!!");
			}
		}
		else
		{

			DatasDic.Add (key,new Dictionary<string,BaseData>());

			DatasDic [key].Add (subkey, data);

		}

	}

	public static void RemoveData(string key,string subkey)
	{
		if (!BeDataExist (key, subkey))
		{
			Log.e ("DataMgr.RemoveData removeData Faile!!!  key:"+key+" subkey:"+subkey+" not exist!!!!!");

			return;
		}

		//nafio info 这里只清除subkey key因为一直要用，没有清理需求
		DatasDic [key].Remove (subkey);

	}


	public static void Init()
	{
		//nafio info 这个用来临时记录，用户操作数据，与新生成块数据，发送给服务器后就暂时失效了
		//这个暂时要手动设置下roomid再发送
		//new RoomUpdateData ("room_update", "4send");
		//new SelfUserDataRT ("user_date", "self");
		//new MenuFreeObjData ("menu_free_obj");

		//new HistoryData ("history");

	}


	/// <summary>
	/// 清除room roomState，roomUpdate数据组时用到
	/// </summary>
	/// <returns>The data group.</returns>
	/// <param name="key">Key.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static Dictionary<string,BaseData> GetDataGroup(string key)
	{

		if (DatasDic.ContainsKey (key))
			return DatasDic [key];
		else
			return null;
	}

}
