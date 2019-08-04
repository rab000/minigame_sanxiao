using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SimpleEventMgr
{
    public delegate void Func(string name, object data);

    private static Dictionary<string, Func> EventsDic = new Dictionary<string, Func>();

    public static void Send(string name,object data)
    {
        if(EventsDic.ContainsKey(name)) EventsDic[name]?.Invoke(name,data);
    }

    public static void Regsit(string name, Func func)
    {
        if (EventsDic.ContainsKey(name))
        {
            Debug.Log("SimpleEventMgr.Regsit name"+name+" exist!! 非首次注册");
            EventsDic[name] += func;
            return;
        }

        EventsDic.Add(name,func);

    }

    public static void Remove(string name)
    {
        if (EventsDic.ContainsKey(name))
        {
            EventsDic.Remove(name);
            return;
        }
    }

    public static void Remove(string name, Func func)
    {
        if (!EventsDic.ContainsKey(name))
        {
            Debug.LogError("SimpleEventMgr.Remove 找不到name:"+name+"的委托");
            return;
        }
        EventsDic[name] -= func;

    }
}

