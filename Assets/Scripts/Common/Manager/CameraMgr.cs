using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 正交相机默认size=5
/// 根据不同分辨率来设置对应的size
/// </summary>
public class CameraMgr : MonoBehaviour
{

    [SerializeField]
    private Camera _Camera;

    
   
    private static CameraMgr Ins;

    public static CameraMgr GetIns()
    {
        return Ins;
    }

    void Awake()
    {
        Ins = this;
    }

    void Start()
    {
        ResizeCamera();
    }

    void OnDestroy()
    {
        Ins = null;
    }

    public Camera GetMainCamera()
    {
        return _Camera;
    }

    public void ResizeCamera()
    {
        //_Camera.orthographicSize = GameLayout.GetResizeCameraSize();
    }

    // 750 * 1334


}
