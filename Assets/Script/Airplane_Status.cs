using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Airplane_Status : MonoBehaviour {

	// 攻击机
	public GameObject airPlane;
	//无人机
	public GameObject uav;
	//风速
	public Vector3 windSpeed;
	//高度系数，用于计算地速
	public float heighCoefficient = 0.8f;
	//无人机与攻击机之间的距离
	public float distance;
	//无人机与攻击机之间的高度差
	public float heightdiff;
	//攻击机地速
	public float airGroundSpeed;
	//无人机地速
	public float uavGroundSpeed;

	//攻击机表速
	public float airMeterSpeed;
	//无人机表速
	public float uavMeterSpeed;
	//攻击机欧拉角
	public Vector3 airEulerAngles;
	//无人机欧拉角
	public Vector3 uavEulerAngles;
	//航向差
	public float courseAngleDiff;
	//速度差
	public float speedDiff;
	//无人机高度
	public float uavHeigth;

	//攻击机高度
	public float airHeigth;

	// ui 界面
	//显示风速的ui
	public Text windSpeedUI;
	//显示战机高度的ui
	public Text airHeightUI;
	//显示战机表速的ui
	public Text airSpeedUI;
	//显示战机地速的ui
	public Text airGroundUI;
	//显示战机航向角的ui
	public Text airAngleUI;
	//显示战机俯仰角的ui
	public Text airPitchUI;
	//显示战机翻滚角的ui
	public Text airRollAngleUI;

	//显示无人机高度的ui
	public Text uavHeightUI;
	//显示无人机表速的ui
	public Text uavSpeedUI;
	//显示无人机地速的ui
	public Text uavGroundUI;
	//显示无人机航向角的ui
	public Text uavAngleUI;
	//显示无人机俯仰角的ui
	//public Text uavPitchUI;
	//显示无人机翻滚角的ui
	//public Text uavRollAngleUI;

	//显示无人机与战机高度差的ui
	public Text heightDiffUI;
	//显示无人机与战机速度差的ui
	public Text speedDIffUI;
	//显示无人机与战机航向角差的ui
	public Text AngleDiffUI;
	//显示无人机与战机的距离ui
	public Text distanceShow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//计算速度标量
	float speedQuantity(Vector3 speed)
	{
		return Mathf.Pow(Mathf.Pow(speed.x, 2) + Mathf.Pow(speed.y, 2) + Mathf.Pow(speed.z, 2), 0.5f);
	}
	void LateUpdate()
	{
		Vector3 airPosition = airPlane.transform.position;
		Vector3 uavPosition = uav.transform.position;
		airHeigth = airPosition.y;
		uavHeigth = uavPosition.y;
		distance = Vector3.Distance(airPosition, uavPosition);
		heightdiff = Mathf.Abs(airPosition.y-uavPosition.y);
		airGroundSpeed = speedQuantity(compseGroudSpeed(airPlane,airPlane.GetComponent<move_su27_ceshi>().speed));
		uavGroundSpeed = speedQuantity(compseGroudSpeed(uav,uav.GetComponent<move_Ai_pt>().speed));
		airMeterSpeed = speedQuantity(getRealSpeed(airPlane.GetComponent<move_su27_ceshi>().speed));
		uavMeterSpeed = uav.GetComponent<move_Ai_pt>().speed;
		airEulerAngles = airPlane.transform.eulerAngles;
		uavEulerAngles = uav.transform.eulerAngles;
		courseAngleDiff = airEulerAngles.y - uavEulerAngles.y;
		if (courseAngleDiff > 180)
		{
			courseAngleDiff = courseAngleDiff - 360;
		}
		else if (courseAngleDiff < -180) {
			courseAngleDiff = courseAngleDiff + 360;
		}

		speedDiff = speedQuantity(compseGroudSpeed(airPlane,airPlane.GetComponent<move_su27_ceshi>().speed) - compseGroudSpeed(uav,uav.GetComponent<move_Ai_pt>().speed));

		//给UI控件赋值

		windSpeedUI.text = "风速:" + speedQuantity (windSpeed).ToString("f1") + "m/s";
		airHeightUI.text = "高度:" + airHeigth.ToString ("f0") + "m";
		airSpeedUI.text = "真速:" + airMeterSpeed.ToString ("f0") + "km/h";
		airGroundUI.text = "地速:" + airGroundSpeed.ToString ("f0") + "km/h";
		airAngleUI.text = "航向:" + airEulerAngles.y.ToString ("f1");
		airPitchUI.text = "俯仰:" + ((360 - airEulerAngles.x)%360).ToString ("f1");
		airRollAngleUI.text = "横滚:" + airEulerAngles.z.ToString ("f1");

		uavHeightUI.text = "高度:" + uavHeigth.ToString ("f0") + "m";
		uavSpeedUI.text = "表速:" + uavMeterSpeed.ToString ("f0")+ "km/h";
		uavGroundUI.text = "地速:" + uavGroundSpeed.ToString ("f0")+ "km/h";
		uavAngleUI.text = "航向:" + uavEulerAngles.y.ToString ("f1");
		//		uavPitchUI.text = "俯仰角:" +  ((360 - uavEulerAngles.x)%360).ToString ("f2");
		//		uavRollAngleUI.text = "翻滚角:" + uavEulerAngles.z.ToString ("f2");

		heightDiffUI.text = "高度差:" + heightdiff.ToString ("f0") + "m";
		speedDIffUI.text = "速度差:" + speedDiff.ToString ("f0")+ "km/h";
		AngleDiffUI.text = "航向差:" + courseAngleDiff.ToString ("f1");
		distanceShow.text = "距离:" + distance.ToString ("f0") + "m";

	}
	public Vector3 getRealSpeed(float speed)
	{
		//       Debug.Log("Meter speed " + transform.localPosition);
		Vector3 realSpeed = new Vector3(0, 0, speed) / Mathf.Pow(heighCoefficient, 0.5f);
		//        Debug.Log("realspeed " + realSpeed);
		return realSpeed;
	}
	//根据真速和风速来计算地速
	public Vector3 compseGroudSpeed(GameObject obj,float speed)
	{
		//        Debug.Log("wind speed " + windspeed);
		//将本地坐标转换为世界坐标
		Vector3 wordSpeed = obj.transform.TransformPoint(getRealSpeed(speed)) - obj.transform.TransformPoint(new Vector3(0, 0, 0));
		//		Debug.Log("word speed " + wordSpeed);
		return wordSpeed + windSpeed;
	}
}
