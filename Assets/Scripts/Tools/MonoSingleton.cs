/// <summary>
/// Generic Mono singleton.
/// </summary>
using UnityEngine;
public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{

    private static T _Ins = null;

    public static T Ins
    {
        get
        {
            if (_Ins == null)
            {
                _Ins = GameObject.FindObjectOfType(typeof(T)) as T;
                if (_Ins == null)
                {
                    _Ins = new GameObject("Singleton4 " + typeof(T).ToString(), typeof(T)).GetComponent<T>();
                }

            }
            return _Ins;
        }
    }

    private void Awake()
    {

        if (_Ins == null)
        {
            _Ins = this as T;
        }
    }
   
    private void OnApplicationQuit()
    {
        _Ins = null;
    }
}