using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	//设置界面
	public Image setAirUI;
	//显示状态界面
	public Image AirStatsUI;

	//输入高度差控件
	public InputField heightDiff;
	//输入距离差控件
	public InputField distanceDiff;
	//输入角度差控件
	public InputField angleDiff;

	//无人机对象
	public GameObject uav;
	//战机对象
	public GameObject air;
	//云的对象
	public GameObject cloud;
	//输入的小时UI
	public InputField hour;
	//显示状态界面
	public Image TimeUI;
	//地形对象
	public GameObject terrain;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs( air.gameObject.transform.position.x )> 3000 || Mathf.Abs(air.gameObject.transform.position.z) > 3000) {
			changePpos ();
		}

	}
	//设置参数
	public void setAirStats()
	{
		if (heightDiff.text.Length == 0 || distanceDiff.text.Length == 0 || angleDiff.text.Length == 0)
			return;

		uav.GetComponent<move_Ai_pt> ().speed = 0;
		air.GetComponent<move_su27_ceshi> ().speed = 0;
		float height = float.Parse (heightDiff.text);
		float distance = float.Parse (distanceDiff.text);
		float angle = float.Parse (angleDiff.text)%360;
		Vector3 pos =  airPlanePositionRelateToWorld (height,angle*Mathf.PI/180,distance);
		Debug.Log ("********" + pos);
		air.transform.position = pos;
		air.transform.rotation = uav.transform.rotation;
		uav.GetComponent<move_Ai_pt> ().speed = 210;
		air.GetComponent<move_su27_ceshi> ().speed = 300;
		hideUI();
	}

	//显示设置UI
	public void showSetUI()
	{
		setAirUI.gameObject.SetActive (true);
		AirStatsUI.gameObject.SetActive (false);	
		hideTimeUI ();
	}
	//隐藏设置UI
	public void hideUI()
	{
		setAirUI.gameObject.SetActive (false);
		AirStatsUI.gameObject.SetActive (true);	

	}
	//根据设置数据计算飞机的坐标
	public Vector3 airPlanePositionRelateToWorld( float heightDiff, float angleZX, float distance)
	{
		float heridistance = Mathf.Sqrt(Mathf.Abs(Mathf.Pow(distance,2) - Mathf.Pow(heightDiff,2)));
		float planex =  heridistance * Mathf.Sin(angleZX);  //攻击机相对于无人机坐标系x轴位置
		float planey =  heightDiff;
		float planez =  heridistance * Mathf.Cos(angleZX);
		//		Debug.Log (planex + "+++++++++" + planey  +"+++++++++" + planez + "+++++++++" + angleZX + "+++++++++" +  Mathf.Cos(angleZX) + "+++++++++++++" + Mathf.Sin(angleZX));
		return uav.gameObject.transform.TransformPoint(new Vector3(planex, planey, planez));

	}
	//设置时间
	public void setHour()
	{
		if(hour.text.Length != 0)
			cloud.GetComponent<SilverLining> ().hour = int.Parse (hour.text);
		hideTimeUI ();
	}
	//显示设置时间UI
	public void showTimeUI()
	{
		TimeUI.gameObject.SetActive (true);
		hideUI ();
	}
	//隐藏设置时间UI
	public void hideTimeUI()
	{
		TimeUI.gameObject.SetActive (false);
	}
	void changePpos ()
	{
		if (air.gameObject.transform.position.x > 3000) {
			air.gameObject.transform.position = new Vector3 (air.gameObject.transform.position.x - 3000,air.gameObject.transform.position.y,air.gameObject.transform.position.z);
			terrain.gameObject.transform.position = new Vector3 (terrain.gameObject.transform.position.x - 3000,terrain.gameObject.transform.position.y,terrain.gameObject.transform.position.z);
			uav.gameObject.transform.position = new Vector3 (uav.gameObject.transform.position.x - 3000,uav.gameObject.transform.position.y,uav.gameObject.transform.position.z);
			cloud.gameObject.transform.position = new Vector3 (cloud.gameObject.transform.position.x - 3000,cloud.gameObject.transform.position.y,cloud.gameObject.transform.position.z);
		}else if(air.gameObject.transform.position.x < -3000)
		{
			air.gameObject.transform.position = new Vector3 (air.gameObject.transform.position.x + 3000,air.gameObject.transform.position.y,air.gameObject.transform.position.z);
			terrain.gameObject.transform.position = new Vector3 (terrain.gameObject.transform.position.x + 3000,terrain.gameObject.transform.position.y,terrain.gameObject.transform.position.z);
			cloud.gameObject.transform.position = new Vector3 (cloud.gameObject.transform.position.x + 3000,cloud.gameObject.transform.position.y,cloud.gameObject.transform.position.z);
			uav.gameObject.transform.position = new Vector3 (uav.gameObject.transform.position.x - 3000,uav.gameObject.transform.position.y,uav.gameObject.transform.position.z);
		}
		if (air.gameObject.transform.position.z > 3000) {
			air.gameObject.transform.position = new Vector3 (air.gameObject.transform.position.x,air.gameObject.transform.position.y,air.gameObject.transform.position.z - 3000);
			terrain.gameObject.transform.position = new Vector3 (terrain.gameObject.transform.position.x,terrain.gameObject.transform.position.y,terrain.gameObject.transform.position.z - 3000);
			uav.gameObject.transform.position = new Vector3 (uav.gameObject.transform.position.x,uav.gameObject.transform.position.y,uav.gameObject.transform.position.z - 3000);
			cloud.gameObject.transform.position = new Vector3 (cloud.gameObject.transform.position.x ,cloud.gameObject.transform.position.y,cloud.gameObject.transform.position.z - 3000);
		}else if(air.gameObject.transform.position.z < -3000)
		{
			air.gameObject.transform.position = new Vector3 (air.gameObject.transform.position.x ,air.gameObject.transform.position.y,air.gameObject.transform.position.z + 3000);
			terrain.gameObject.transform.position = new Vector3 (terrain.gameObject.transform.position.x ,terrain.gameObject.transform.position.y,terrain.gameObject.transform.position.z+ 3000);
			cloud.gameObject.transform.position = new Vector3 (cloud.gameObject.transform.position.x ,cloud.gameObject.transform.position.y,cloud.gameObject.transform.position.z+ 3000);
			uav.gameObject.transform.position = new Vector3 (uav.gameObject.transform.position.x ,uav.gameObject.transform.position.y,uav.gameObject.transform.position.z+ 3000);
		}
	}
}
