using UnityEngine;
using System.Collections;
using System;

public class UIBase : MonoBehaviour {

	public string Name;

	public virtual void Awake()
	{
        Name = gameObject.name;
    }

	public virtual void Open()
	{

	}

	public virtual void Close(bool destroy = false)
	{

	}

	public virtual void Dispose()
    {
        
    }

}
