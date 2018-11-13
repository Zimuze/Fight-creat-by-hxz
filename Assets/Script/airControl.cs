using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airControl : MonoBehaviour {
    // 攻击机
    public GameObject airPlane;
    //无人机
    public GameObject uav;
    // Use this for initialization
    //无人机与攻击机之间的距离
    public float distance;
    //无人机与攻击机之间的高度差
    public float heightdiff;
    // 无人机ZOX夹角
    public float angleZX;

    //攻击机在世界坐标中的位置
    public Vector3 position;
    void Start() {

    }

    // Update is called once per frame
    void Update() {
      //   position = uav.GetComponent<move_ai>().airPlanePositionRelateToWorld(heightdiff, angleZX, distance);
    }
    //无人机相对于攻击在各个坐标轴上的夹角
    float angleAirPlaneZToUav() {
        Vector3 target = airPlane.transform.position - uav.transform.position;
        return Vector3.Angle(target, airPlane.transform.forward);
    }

    float angleAirPlaneXToUav()
    {
        Vector3 target = airPlane.transform.position - uav.transform.position;
        return Vector3.Angle(target, airPlane.transform.right);
    }

    float angleAirPlaneYToUav()
    {
        Vector3 target = airPlane.transform.position - uav.transform.position;
        return Vector3.Angle(target, airPlane.transform.up);
    }

}
