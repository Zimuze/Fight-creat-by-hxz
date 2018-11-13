using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSatus1 : MonoBehaviour
{
    // 攻击机
    public GameObject airPlane;
    //无人机
    public GameObject uav;
    // Use this for initialization
    //无人机与攻击机之间的距离
    public float distance;
    //无人机与攻击机之间的高度差
    public float heightdiff;
    //攻击机地速
    public float airGroundSpeed;
    //无人机地速
    public float uavGroundSpeed;
    //风速
    public Vector3 windSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    float distanceBetweenPositions(Vector3 source, Vector3 target)
    {
        Vector3 relateDistance = target - source;
        return Mathf.Pow(Mathf.Pow(relateDistance.x, 2) + Mathf.Pow(relateDistance.y, 2) + Mathf.Pow(relateDistance.z, 2), 0.5f);
    }

    float heightDifference(Vector3 source, Vector3 target)
    {
        return target.y - source.y;
    }

    //计算速度标量
    float speedQuantity(Vector3 speed)
    {
        return Mathf.Pow(Mathf.Pow(speed.x, 2) + Mathf.Pow(speed.y, 2) + Mathf.Pow(speed.z, 2), 0.5f);
    }

    void FixedUpdate()
    {
        Vector3 airPosition = airPlane.transform.position;
        Vector3 uavPosition = uav.transform.position;

        distance = distanceBetweenPositions(airPosition, uavPosition);
        heightdiff = heightDifference(uavPosition, airPosition);
        airGroundSpeed = speedQuantity(airPlane.GetComponent<move_su27>().speedObject.GetComponent<Speed>().compseGroudSpeed(windSpeed));
 //       uavGroundSpeed = speedQuantity(uav.GetComponent<move_ai>().speedObject.GetComponent<Speed>().compseGroudSpeed(windSpeed));
    }
}
