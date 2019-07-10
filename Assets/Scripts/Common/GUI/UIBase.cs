using UnityEngine;
using System.Collections;

public class UIBase : MonoBehaviour {

	public string Name;

	public virtual void Awake()
	{
		Init ();
	}

	public virtual void Init()
	{
		Name = gameObject.name;
	}

	public virtual void OnOpen()
	{
		
		gameObject.SetActive(true);
	
	}

	public virtual void OnClose(bool destroy = false)
	{
		Clear();

		if (destroy)Destroy (gameObject);
		else gameObject.SetActive(false);

	}

	public virtual void Clear(){}

}
