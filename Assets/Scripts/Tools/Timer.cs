using System;
using UnityEngine;

public class Timer{

	public Listener OnEnd;

	public Listener<float> OnUpdate;

	float durSec;
	float startTimeSec;
	bool isRunning = false;
	
	public void Start(float durSec){
		this.durSec=durSec;
		startTimeSec=Time.realtimeSinceStartup;
		isRunning=true;
	}

	public bool IsRunning(){
		return isRunning;
	}

	public bool IsOK(){
        if (!isRunning){
            return false;
        }

		if(Time.realtimeSinceStartup-startTimeSec>=durSec){
			return true;
		}
		return false;
	}

	/// <summary>
	/// 剩余时间
	/// </summary>
	/// <returns>The time.</returns>
    public float GetSurplusTime(){
		return startTimeSec + durSec - Time.realtimeSinceStartup;
    }

	/// <summary>
	/// 获取剩余时间比例
	/// </summary>
	/// <returns>The time percentage.</returns>
	public float GetSurplusTimePercentage(){
		float t = GetSurplusTime();
		if(t <= 0)
			return 0;
		return t / durSec;
	}

	/// <summary>
	/// 持续时间
	/// </summary>
	/// <returns>The time.</returns>
	public float GetLastTime()
	{
		return Time.realtimeSinceStartup - startTimeSec;
	}

	/// <summary>
	/// 持续时间占总时间的百分比
	/// </summary>
	/// <returns>The time perventage.</returns>
	public float GetLastTimePerventage(){
		float t = GetLastTime();
		if(t <= 0)
			return 0;
		return t / durSec;
	}

	public void Reset(){
		Start(durSec);
	}
	
    public void Stop(){
        isRunning = false;
    }

//    public void SetTimeOK(){
//		isRunning = true;
//        startTimeSec = 0;
//    }

	/// <summary>
	/// 把循环逻辑写到Timer内部，对外发出事件
	/// 目前只发出更新事件和结束事件
	/// </summary>
	public void tUpdate()
	{
		if (!isRunning)return;

		//持续百分比
		float t = GetLastTimePerventage();

		if (null != OnUpdate)OnUpdate(t);
			
		bool beFinish = IsOK();

		if (beFinish)
		{
			isRunning = false;

			if (null != OnEnd)OnEnd();
				
		}

	}

}//end of class




