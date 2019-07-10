using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
public class TouchInputMgr : MonoBehaviour {
	
	[HideInInspector]public bool IgnoreStartedOverGui = true;

	[HideInInspector]public bool IgnoreIsOverGui = true;

	[HideInInspector]public int RequiredFingerCount;

    [Tooltip("How many times must this finger tap before OnTap gets called? (0 = every time) Keep in mind OnTap will only be called once if you use this.")]
    public int RequiredTapCount = 0;

    [Tooltip("How many times repeating must this finger tap before OnTap gets called? (0 = every time) (e.g. a setting of 2 means OnTap will get called when you tap 2 times, 4 times, 6, 8, 10, etc)")]
    public int RequiredTapInterval = 2;

    [Range(-1.0f, 1.0f)]
	public float WheelSensitivity;

	//NaTodo 这里需要处理下耦合
	public OperatableMonoObj _OperatableMonoObj;

	private Vector2 ScreenDelta = new Vector2();

	private Camera _MainCamera;
	private Camera MainCamera{
		get{ 
			if (null == _MainCamera)
				_MainCamera = CameraMgr.GetIns ().GetMainCamera ();

			return _MainCamera;
		}
	}

	private static TouchInputMgr Ins;
	public static TouchInputMgr GetIns(){return Ins;}
	void Awake(){Ins = this;}
	void OnDestroy(){Ins = null;}

	protected virtual void OnEnable(){
		LeanTouch.OnFingerDown += PressDown;
		LeanTouch.OnFingerUp += PressUp;
        LeanTouch.OnFingerTap += FingerTap;
    }

	protected virtual void OnDisable(){
		LeanTouch.OnFingerDown -= PressDown;
		LeanTouch.OnFingerUp -= PressUp;
        LeanTouch.OnFingerTap -= FingerTap;

    }

	public Vector2 GetScreenDelta(){
		List<LeanFinger> fingers = LeanTouch.GetFingers(IgnoreStartedOverGui, IgnoreIsOverGui, RequiredFingerCount);
		Vector2 lastScreenPoint = LeanGesture.GetLastScreenCenter(fingers);
		Vector2 screenPoint = LeanGesture.GetScreenCenter(fingers);
		ScreenDelta = screenPoint - lastScreenPoint;
		return ScreenDelta;
	}

	public float GetPinchRatio(){
		List<LeanFinger> fingers = LeanTouch.GetFingers(IgnoreStartedOverGui, IgnoreIsOverGui, RequiredFingerCount);
		float pinchRatio = LeanGesture.GetPinchRatio(fingers, WheelSensitivity);
		return pinchRatio;
	}
		
	private void PressDown(LeanFinger finger){
		if (IgnoreStartedOverGui == true && finger.IsOverGui == true){return;}
		if (_OperatableMonoObj != null && _OperatableMonoObj.IsSelected == false){return;}
		Ray ray = MainCamera.ScreenPointToRay(finger.ScreenPosition);
		RaycastHit hit = default(RaycastHit);
		//LayerMask lm = ~(1 << GameEnum.Layer8_Ground);
		if (Physics.Raycast(ray, out hit, 1000/*,lm*/)){
			OperatableMonoObj obj = hit.transform.GetComponent<OperatableMonoObj>();
			if (null != obj) {
				obj.OnPressDown(hit.point);
			}

		}
	}
	private void PressUp(LeanFinger finger){
		if (IgnoreStartedOverGui == true && finger.IsOverGui == true){return;}
		if (_OperatableMonoObj != null && _OperatableMonoObj.IsSelected == false){return;}
		Ray ray = MainCamera.ScreenPointToRay(finger.ScreenPosition);
		//LayerMask lm = ~(1 << GameEnum.Layer8_Ground);
		RaycastHit hit = default(RaycastHit);
		if (Physics.Raycast(ray, out hit, 1000/*,lm*/) == true){
			OperatableMonoObj obj = hit.transform.GetComponent<OperatableMonoObj>();
			if (null != obj) {
				obj.OnPressUp(hit.point);
			}

		}
	}

    private void FingerTap(LeanFinger finger)
    {
        // Ignore?
        if (IgnoreStartedOverGui == true && finger.StartedOverGui == true)
        {
            return;
        }

        if (IgnoreIsOverGui == true && finger.IsOverGui == true)
        {
            return;
        }

        if (RequiredTapCount > 0 && finger.TapCount != RequiredTapCount)
        {
            return;
        }

        if (RequiredTapInterval > 0 && (finger.TapCount % RequiredTapInterval) != 0)
        {
            return;
        }

        //if (RequiredSelectable != null && RequiredSelectable.IsSelected == false)
        //{
        //    return;
        //}

        // Call event
        //if (onTap != null)
        //{
        //    onTap.Invoke(finger);
        //}

        if (IgnoreStartedOverGui == true && finger.IsOverGui == true) { return; }
        if (_OperatableMonoObj != null && _OperatableMonoObj.IsSelected == false) { return; }
        Ray ray = MainCamera.ScreenPointToRay(finger.ScreenPosition);
        //LayerMask lm = ~(1 << GameEnum.Layer8_Ground);
        RaycastHit hit = default(RaycastHit);
        if (Physics.Raycast(ray, out hit, 1000/*,lm*/) == true)
        {
            OperatableMonoObj obj = hit.transform.GetComponent<OperatableMonoObj>();
            if (null != obj)
            {
                obj.OnDoubleClick(hit.point);
            }

        }

    }

}
