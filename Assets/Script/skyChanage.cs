using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyChanage : MonoBehaviour {


	public Material[] mats;  
	int index;  
	//灯光
	public GameObject light;
	//绿镜
	public GameObject lvjing;
	//天空盒组件
	private Skybox sky;
	//
	public GameObject cloud;
	// Use this for initialization
	void Start () {
		index = 0;  
		//sky = transform.GetComponent<Skybox>();  

	}

	void ChangeSkyBox()  
	{  
		//下面的这一行代码 生效，必须 删除 主摄像机Main Camera，的Skybox组件  
		RenderSettings.skybox = mats[index];  


		//下面的这一行代码 生效，必须 使得 主摄像机Main Camera，的Skybox组件 生效  
		//sky.material = mats[index];  

		if (index == 1) {
			light.GetComponent<Light> ().intensity = 0.05f;
			lvjing.SetActive (true);
		} else {
			light.GetComponent<Light> ().intensity = 0.79f;		
			lvjing.SetActive (false);
		}

		index++;  
		index %= mats.Length;  
	}  
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Space))  
		{  
			ChangeSkyBox();  
		} 
		if (Input.GetKeyDown(KeyCode.F4))  
		{  
			lvjing.SetActive (!lvjing.activeSelf);
		} 

		if (Input.GetKeyDown (KeyCode.F3)) {
		
			cloud.SetActive (!cloud.activeSelf);
		}

	}
}
