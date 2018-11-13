using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour {

    // Use this for initialization
    public float zSpeed;
    public float ySpeed;
    public float xSpeed;
    //高度系数，用于计算地速
    public float heighCoefficient = 6;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//        Debug.Log("speed speed " + zSpeed);
        //transform.Translate(new Vector3(0, 0, 0) - transform.localPosition);
        //transform.Translate(new Vector3(0, 0, zSpeed));
        //getRealSpeed();

    }


    // 由表速来计算真速，表速就是相对于飞行器自己的坐标系的速度，方向指向z轴
    public Vector3 getRealSpeed()
    {
 //       Debug.Log("Meter speed " + transform.localPosition);
        Vector3 realSpeed = new Vector3(0, 0, zSpeed) / Mathf.Pow(heighCoefficient, 0.5f);
//        Debug.Log("realspeed " + realSpeed);
        return realSpeed;
    }

    //根据真速和风速来计算地速
   public Vector3 compseGroudSpeed(Vector3 windspeed)
    {
//        Debug.Log("wind speed " + windspeed);
        //将本地坐标转换为世界坐标
        Vector3 wordSpeed = transform.TransformPoint(getRealSpeed()) - transform.TransformPoint(new Vector3(0, 0, 0));
//		Debug.Log("word speed " + wordSpeed);
        return wordSpeed + windspeed;
    }
}
