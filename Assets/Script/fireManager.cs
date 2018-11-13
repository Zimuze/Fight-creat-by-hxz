using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireManager : MonoBehaviour {
	//开炮位置
	public GameObject startPosition;
	//炮弹预制体
	public GameObject paodanPrefab;
	//开炮粒子
	public GameObject kaipao_effects;
	//出口速度
	public int speed = 1000;
	//风速对象
	public GameObject wind;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.KeypadEnter)) {
	//		Debug.Log (22222222222222);
			//将本地坐标转换为世界坐标
			Vector3 wordSpeed = startPosition.transform.TransformPoint(new Vector3(0,0,speed))- startPosition.transform.TransformPoint(new Vector3(0,0,0));
			//集合风速
			Vector3 addSpeed = wordSpeed + wind.GetComponent<Airplane_Status>().windSpeed;
			//世界坐标转本地坐标
			Vector3 vec= startPosition.transform.InverseTransformPoint(addSpeed);  

			GameObject clone = Instantiate (paodanPrefab,startPosition.transform.position,startPosition.transform.rotation);
		//	clone.transform.Rotate (-90,0,0);
			Rigidbody rig = clone.GetComponent<Rigidbody> ();
			//	rig.velocity = clone.transform.forward * speed;
			rig.velocity = addSpeed;
			kaipao_effects.SetActive (true);
		}
		if (Input.GetKeyUp (KeyCode.KeypadEnter)) {
			kaipao_effects.SetActive (false);
//			Debug.Log (333333333333333);
		}
		if (Input.GetButton ("Fire1")) {
			//		Debug.Log (22222222222222);
			//将本地坐标转换为世界坐标
			Vector3 wordSpeed = startPosition.transform.TransformPoint(new Vector3(0,0,speed)) - startPosition.transform.TransformPoint(new Vector3(0,0,0));
	//		Debug.Log (wordSpeed);
			//集合风速
			Vector3 addSpeed = wordSpeed + wind.GetComponent<Airplane_Status>().windSpeed;
	//		Debug.Log (addSpeed);
			//世界坐标转本地坐标
		//	Vector3 vec= startPosition.transform.InverseTransformPoint(addSpeed);  


			GameObject clone = Instantiate (paodanPrefab,startPosition.transform.position,startPosition.transform.rotation);
		//	clone.transform.Rotate (-90,0,0);
			Rigidbody rig = clone.GetComponent<Rigidbody> ();
		//	rig.velocity = clone.transform.forward * speed;
			rig.velocity = addSpeed;
			kaipao_effects.SetActive (true);
		}
		if (Input.GetButtonUp ("Fire1")) {
			kaipao_effects.SetActive (false);
			//			Debug.Log (333333333333333);
		}
	}
}
