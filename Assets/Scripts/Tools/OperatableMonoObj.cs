using UnityEngine;
using System.Collections;
/// <summary>
/// 可被鼠标选中mono物体
/// </summary>
public class OperatableMonoObj : MonoBehaviour {
	public bool IsSelected;
	public virtual void OnPressDown(Vector3 point){}
	public virtual void OnPressUp(Vector3 point){}
	public virtual void OnFocus(){}
	public virtual void OnLostFocus(){}
	public virtual void OnSel(){
		IsSelected = true;
	}
	public virtual void OnDeSel(){
		IsSelected = false;
	}
	/// <summary>
	/// click处理
	/// 这个不一定需要实现，看需求
	/// 比如npc商店等，sel时就可以直接打开window
	/// </summary>
	public virtual void OnClick(){}

    public virtual void OnDoubleClick(Vector3 point) {}

	public virtual void Release(){}

}
