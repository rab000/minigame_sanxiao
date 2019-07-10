using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gopool : MonoBehaviour {

	public static Gopool Ins;

	private static Dictionary<string,List<Transform>> pgoDic = new Dictionary<string, List<Transform>> ();

	void Awake()
	{
		Ins = this;
		DontDestroyOnLoad (gameObject);
	}

	public void Put(string name,Transform trm)
	{
		//TDebug.LogError ("---------put pool name:"+name+" trmName:"+trm.name);

		trm.SetParent (transform);

		if (trm.gameObject.activeSelf)
			trm.gameObject.SetActive (false);

		if (!pgoDic.ContainsKey (name))
			pgoDic.Add (name,new List<Transform>());
		
		pgoDic [name].Add (trm);


	}

	public Transform Get(string name)
	{
		Transform trm = null;

		if (pgoDic.ContainsKey (name)) 
		{
			int num = pgoDic [name].Count;
			if ( num > 0) 
			{
				trm = pgoDic [name] [num - 1];
				trm.SetParent (null);
				pgoDic [name].RemoveAt (num-1);
				//TDebug.Log ("找到"+name+"并返回");

				//PoolGoFactory.ProcessMenu (name,trm,9);

				return trm;
			}
		}

		//if(name.Equals("letter"))TDebug.LogError ("创建--------------------》");
		var go = PoolGoFactory.Create (name);
		trm = go.transform;
		//TDebug.Log ("没找到"+name+"创建并返回");

		return trm;
	}


	public void CleanAll()
	{
		int count = transform.childCount;
		for (int i = 0; i < count; i++) 
		{
			GameObject.Destroy( transform.GetChild (i).gameObject);
		}

		pgoDic.Clear ();
	}

}

public class PoolGoFactory{

	public static GameObject Create(string type)
	{
		GameObject go = null;

		switch (type) {
		case "eff_delLetter":
			go = GameObject.Instantiate (Resources.Load ("Prefabs/eff/eff_delLetter")) as GameObject;
			go.name = "eff_delLetter";
			break;

		default:

			break;

		}

		return go;
	}

	



}