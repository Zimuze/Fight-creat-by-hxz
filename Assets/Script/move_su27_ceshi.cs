using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_su27_ceshi : MonoBehaviour {



		//判断游戏是否结束 
		int gameover = 0;

		//飞机的初始速度
		public float speed=300.0f;
		
		//最高速度
		public int maxSpeed = 500;
		//低于这个速度就下降高度
		public int minSpeed = 200;
//		public GameObject speedObject;
//
		//左机翼
		public GameObject left_wing;
		//左机翼旋转轴
		public GameObject left_wing_center;
		//右机翼
		public GameObject right_wing;
		//右机翼旋转轴
		public GameObject right_wing_center;
		//左方向尾翼
		public GameObject left_tail;
		//左方向尾翼旋转轴
		public GameObject left_tail_center;
		//右方向尾翼
		public GameObject right_tail;
		//右方向尾翼旋转轴
		public GameObject right_tail_center;
		//左水平尾翼
		public GameObject left_horizontal;
		//左水平尾翼旋转轴
		public GameObject left_horizontal_center;
		//左水平尾翼
		public GameObject right_horizontal;
		//左水平尾翼旋转轴
		public GameObject right_horizontal_center;

		//襟副翼旋转角度统计
		float  countAngle = 0;
		//水平旋转角度统计
		float  countHorizontalAngle = 0;
		//方向旋转角度统计
		float  countVerticalAngle = 0;
		//统计时间
		float countTime = 0;

		// Use this for initializatin
		void Start () {

		}

		// Update is called once per frame
		void Update () {
			
			if(gameover==0){

				//飞机的俯仰
				if (Input.GetAxis ("Vertical") != 0) {

					transform.Rotate (Input.GetAxis ("Vertical") * Time.deltaTime * 40, 0, 0); 
				if (countVerticalAngle < 30 && countVerticalAngle > -30) {
					countTime = 0;
					setHorizontalRudder (Input.GetAxis ("Vertical"));
				}
				} else {
					
					if (countVerticalAngle > 0) {
						setHorizontalRudder (-1);
					}else
						if (countVerticalAngle < 0) {
							setHorizontalRudder (1);
						}
				//5s 后复位
				if(countVerticalAngle!=0)
				{
				countTime += Time.deltaTime;
				if (countTime > 5 ) {
					countVerticalAngle = 0;
					left_horizontal.transform.RotateAround (left_horizontal_center.transform.position,left_horizontal_center.transform.up,0);
					right_horizontal.transform.RotateAround (right_horizontal_center.transform.position,right_horizontal_center.transform.up,0);
					}
				}
				}
			//飞机水平转向
				if (Input.GetAxis ("Horizontal1") != 0) {
		
					transform.Rotate (0, Input.GetAxis ("Horizontal1") * Time.deltaTime * 40, 0, Space.World); //Rechts Links || Left Right
				if (countHorizontalAngle < 30 && countHorizontalAngle > -30) {
					countTime = 0;
					setRudder (Input.GetAxis ("Horizontal1"));
				}

				} else {
				
					if (countHorizontalAngle > 0) {
						setRudder (-1);
					}else
						if (countHorizontalAngle < 0) {
							setRudder (1);
						}
				//5s 后复位
				if(countHorizontalAngle!= 0)
				{
					countTime += Time.deltaTime;
				if(countTime > 5 )
				{
					countHorizontalAngle = 0;
					left_tail.transform.RotateAround (left_tail_center.transform.position,left_tail_center.transform.up,0);
					right_tail.transform.RotateAround (right_tail_center.transform.position,right_tail_center.transform.up,0);
				}
				}
				}

			//飞机翻滚
				if (Input.GetAxis ("Horizontal")<0) //a
					transform.Rotate(0,0,Time.deltaTime*-50);
				if (Input.GetAxis ("Horizontal")>0) //d
					transform.Rotate(0,0,Time.deltaTime*50);
				if (Input.GetAxis ("Horizontal") != 0) {
				if (countAngle < 30 && countAngle > -30) {
					countTime = 0;
					setWing (Input.GetAxis ("Horizontal"));
				}
				} else {

					if (countAngle > 0) {
						setWing (-1);
					}else
						if (countAngle < 0) {
							setWing (1);
						}
				//5s 后复位
				if(countAngle != 0)
				{
					countTime += Time.deltaTime;
					if(countTime> 5){
						countAngle = 0;
						left_wing.transform.RotateAround (left_wing_center.transform.position,left_wing_center.transform.up,0);
						right_wing.transform.RotateAround (right_wing_center.transform.position,right_wing_center.transform.up,0);
					}
				}
				}

				// 改变位置
			transform.Translate(0,0,(float)(speed/3.6 * Time.deltaTime));
				
//				if ((ground.triggered==1)&&(Input.GetButton("Fire1"))&&(speed<maxSpeed)) 
//				{
//				speed += Time.deltaTime * 240;
//				if (speed > maxSpeed) {
//					speed = maxSpeed;
//				}
//			}
//				if ((ground.triggered==1)&&(Input.GetButton("Fire2"))&&(speed>0)) 
//			{
//				speed -= Time.deltaTime * 240;
//				if (speed < 0) {
//					speed = 0;
//				}
//			}

				
			if ((Input.GetAxis ("Fire3") > 0) && (speed < maxSpeed)) {
				speed += Time.deltaTime * 240;
				if (speed > maxSpeed) {
					speed = maxSpeed;
				}
			}
			if ((Input.GetAxis ("Fire3") < 0) && (speed > 0)) {
				speed -= Time.deltaTime * 240;
				if (speed < 0) {
					speed = 0;
				}
			}

				
			}
	
		}

		void FixedUpdate()
		{
			
		}
		
		//襟副翼旋转
		void setWing(float angle)
		{

//			Debug.Log (111111111);
			countAngle += angle * 30 * Time.deltaTime;

			left_wing.transform.RotateAround (left_wing_center.transform.position,left_wing_center.transform.up,-angle * 30 * Time.deltaTime);
			right_wing.transform.RotateAround (right_wing_center.transform.position,right_wing_center.transform.up,angle * 30 * Time.deltaTime);
		}
		//方向舵
		void setRudder(float angle)
		{

			countHorizontalAngle += angle * 30 * Time.deltaTime;
//			//		if (countHorizontalAngle > 30 || countHorizontalAngle < -30)
//			//			return;
//
			left_tail.transform.RotateAround (left_tail_center.transform.position,left_tail_center.transform.up,angle * 30 * Time.deltaTime);
			right_tail.transform.RotateAround (right_tail_center.transform.position,right_tail_center.transform.up,angle * 30 * Time.deltaTime);
		}
		//水平舵
		void setHorizontalRudder(float angle)
		{
//			Debug.Log (1111111111);
//
			countVerticalAngle += angle * 30 * Time.deltaTime;
//			//		if (countVerticalAngle > 30 || countVerticalAngle < -30)
//			//			return;
//
			left_horizontal.transform.RotateAround (left_horizontal_center.transform.position,left_horizontal_center.transform.up,angle * 30 * Time.deltaTime);
			right_horizontal.transform.RotateAround (right_horizontal_center.transform.position,right_horizontal_center.transform.up,angle * 30 * Time.deltaTime);
		}
	}


