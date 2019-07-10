using UnityEngine;
using System.Collections;
using System.IO;
using System;
/// <summary>
/// Nafio 文件操作
/// 这个类本不该存在，目前ResMgr只能加载ab，不能加载text和bytes，
/// 而text和bytes主要是配表用，配表加载时间不会过长，这里用阻塞加载，以后会把这功能统一到ResMgr中
/// </summary>
public class FileHelper{



	static FileHelper ins;

	public static FileHelper GetIns(){
		if(ins==null)ins = new FileHelper();
		return ins;
	}

	//#if UNITY_ANDROID
	//public void ReadBytesFromFile(string url,Action<byte[]> callback = null,Action<string> errorBack = null){
	//	ThreadManager.GetIns().StartCoroutine(go(url,callback,errorBack));
	//}

	IEnumerator go(string url,Action<byte[]> callback = null,Action<string> errorBack = null){
		WWW www = new WWW(url);
		yield return www;
		
		if(www.error!=null){
			Debug.LogError("FileHelper.go() www.error="+www.error+" url:"+url);
			if(null!=errorBack)errorBack(www.error);
			//if(null!=callback)callback(null);//TODO 这句不知道因为什么写的了，但现在会引发问题，所以去掉
			yield break;
		}else{
			if(null!=callback)callback(www.bytes);
		}

		www.Dispose();
		www = null;
	}

//	public static string ReadTextFromFile(string url)
//	{
//		WWW www = new WWW(url);
//		//N_TODO 没用异步和协程,释放问题？
//		while(!www.isDone){}
//		return www.text;
//	}
//	#else
//	public byte[] ReadBytesFromFile(string url,Action<byte[]> callback = null,Action<string> errorBack = null)
//	{
//			if(!File.Exists(url)){
//				Debug.Log(string.Format("找不到:{0} 读取失败！！",url));
//				errorBack("error");
//				return null;
//			}
//			
//			FileStream fs = new FileStream(url,FileMode.Open);
//			//N_INFO 如果读大文件会出问题,不读图片就ok
//			int len = (int)fs.Length;
//			byte[] bytes = new byte[len];
//			fs.Read(bytes,0,len);
//
//			callback(bytes);
//
//			fs.Close();
//			return bytes;
//			
//	}
//	#endif

	//创建并写入
	public static void WriteBytes2File_Create(string url,byte[] bytes){
		if(File.Exists(url))
			File.Delete(url);

		FileStream fs = new FileStream(url,FileMode.Create);
		fs.Write(bytes,0,bytes.Length);
		fs.Close();
		fs.Dispose();
	}

	//附加写入
	public static void WriteBytes2File_Append(string url,byte[] bytes){
		if (!File.Exists (url))
			File.Create (url).Dispose();
		//Debug.LogError ("写入------->content:"+content);
		FileStream fs = new FileStream(url,FileMode.Append);
		fs.Write(bytes,0,bytes.Length);
		fs.Close();
		fs.Dispose ();
	}

}