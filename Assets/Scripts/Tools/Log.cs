using UnityEngine;
using System.IO;
using System.Text;

/// <summary>
/// Nafio 统一控制log
/// 避免发布版本有Debug输出影响效率
/// 进一步要在真机做控制台
/// 
/// ios想到处log，打测试包，导出真机log可以再  Xcode  info.plist 中加入UIFileSharingEnabled值设为true，然后可以连接真机并通过itunus导出日志
/// 
/// 
/// </summary>
public class Log{
	
	public static bool BeShowLog = true;

	public static bool BeExportLog = false;

	public static string LogPath = Application.persistentDataPath+"/log.txt";

	private static StringBuilder SB = new StringBuilder();

	public static void Init()
	{
		if (BeExportLog)
		{
			return;
		}

		Debug.Log ("ExportLog path:"+LogPath);

		if (File.Exists (LogPath)) 
		{
			File.Delete (LogPath);
		}

		File.Create (LogPath).Dispose();
	}

	public static void i(string s)
	{
		if(!BeShowLog)return;

		if (BeExportLog) 
		{
			if(SB.Length>0)SB.Remove (0, SB.Length);
			SB.Append ("[i]-");
			SB.Append (s);
			SB.Append ("\r\n");
			string ss = SB.ToString ();
			var bs = Encoding.UTF8.GetBytes (ss);
			FileHelper.WriteBytes2File_Append(LogPath,bs);
		}

		Debug.Log(s);
	}

	/// <summary>
	/// 用于单独模块的测试，方便各个模块log开关
	/// </summary>
	/// <param name="className">Class name.</param>
	/// <param name="funcName">Func name.</param>
	/// <param name="content">Content.</param>
	/// <param name="beShow">If set to <c>true</c> be show.</param>
	public static void i(string className,string funcName,string content,bool beShow=true)
	{
		if(!BeShowLog)return;
		if (!beShow)return;

		if(SB.Length>0)SB.Remove (0, SB.Length);
		SB.Append ("[i]-[");
		SB.Append (className);
		SB.Append ("->");
		SB.Append (funcName);
		SB.Append ("][");
		SB.Append (content);
		SB.Append ("]");

		if (BeExportLog)
		{
			SB.Append ("\r\n");
			string ss = SB.ToString ();
			var bs = Encoding.UTF8.GetBytes (ss);
			FileHelper.WriteBytes2File_Append(LogPath,bs);
		}

		string s = SB.ToString ();
		Debug.Log(s);

	}

	public static void w(string s)
	{
		if(!BeShowLog)return;

		if (BeExportLog) 
		{

			if(SB.Length>0)SB.Remove (0, SB.Length);
			SB.Append ("[w]-");
			SB.Append (s);
			SB.Append ("\r\n");
			string ss = SB.ToString ();
			var bs = Encoding.UTF8.GetBytes (ss);
			FileHelper.WriteBytes2File_Append(LogPath,bs);

		}

		Debug.LogWarning(s);
	}

	public static void w(string className,string funcName,string content,bool beShow)
	{
		if(!BeShowLog)return;
		if (!beShow)return;
		if(SB.Length>0)SB.Remove (0, SB.Length);
		SB.Append ("[w]-[");
		SB.Append (className);
		SB.Append ("->");
		SB.Append (funcName);
		SB.Append ("][");
		SB.Append (content);
		SB.Append ("]");

		if (BeExportLog)
		{
			SB.Append ("\r\n");
			string ss = SB.ToString ();
			var bs = Encoding.UTF8.GetBytes (ss);
			FileHelper.WriteBytes2File_Append(LogPath,bs);
		}

		string s = SB.ToString ();
		Debug.Log(s);

	}

	public static void e(string s)
	{
		if(!BeShowLog)return;

		if (BeExportLog) 
		{
			if(SB.Length>0)SB.Remove (0, SB.Length);
			SB.Append ("[e]-");
			SB.Append (s);
			SB.Append ("\r\n");
			string ss = SB.ToString ();
			var bs = Encoding.UTF8.GetBytes (ss);
			FileHelper.WriteBytes2File_Append(LogPath,bs);
		}
		Debug.LogError(s);
	}
		
	public static void e(string className,string funcName,string content,bool beShow)
	{
		if(!BeShowLog)return;
		if (!beShow)return;

		if(SB.Length>0)SB.Remove (0, SB.Length);
		SB.Append ("[e]-[");
		SB.Append (className);
		SB.Append ("->");
		SB.Append (funcName);
		SB.Append ("][");
		SB.Append (content);
		SB.Append ("]");

		if (BeExportLog)
		{
			SB.Append ("\r\n");
			string ss = SB.ToString ();
			var bs = Encoding.UTF8.GetBytes (ss);
			FileHelper.WriteBytes2File_Append(LogPath,bs);
		}

		string s = SB.ToString ();
		Debug.Log(s);
	}
}
