using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMgr : MonoSingleton<CameraMgr>
{

    [SerializeField]
    private Camera _Camera;

    public const float CameraHalfH = 5f;

    public const float CameraH = CameraHalfH * 2;

    private static float _CameraW = 0;
    public static float CameraW {
        get
        {
            if (_CameraW == 0)
            {
                _CameraW = Screen.width * CameraH / Screen.height;
                //Debug.Log("计算CameraW:  sw:"+ Screen.width+" sh:"+ Screen.height+" result:"+ _CameraW+" ch:"+CameraH);
            }
            return _CameraW;
        }
    }

    public Camera GetMainCamera()
    {
        return _Camera;
    }

    
}
