using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 正交相机默认size=5
/// 根据不同分辨率来设置对应的size
/// </summary>
public class CameraMgr : MonoSingleton<CameraMgr>
{

    [SerializeField]
    private Camera _Camera;


    void Start()
    {
        ResizeCamera();
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
