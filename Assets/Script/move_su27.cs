using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move_su27 : MonoBehaviour {

	public static float airplaneangley = 0f;

	//public GameObject text;
	int gameover = 0;

	float rotationx=0;
	float rotationy=0;
	float rotationz=0;
	float positionx =0.0f;
	float positiony=0.0f;
	float positionz=0.0f;

	public float speed=300.0f;// speed Variable gibt die Geschwindigkeit an || speed variable is the speed
	float uplift =0.0f;
	//最高速度
	public int maxSpeed = 500;
	//低于这个速度就下降高度
	public int minSpeed = 200;
	public GameObject speedObject;

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
	// Use this for initializatin
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		airplaneangley= transform.eulerAngles.y; 
		// Mit varwhatmoves 1 ist der Code aktiv || Code is active when varwhatmoves is 1
		if(gameover==0){

			// Drehungen des Flugzeugs || Rotations of the airplane
			if (Input.GetAxis ("Vertical1") != 0) {
				Debug.Log ("22222222222222222" + Input.GetAxis ("Vertical1"));
				transform.Rotate (Input.GetAxis ("Vertical1") * Time.deltaTime * 40, 0, 0); //Hoch Runter, limitiert auf eine Minimalgeschwindigkeit || Up Down, limited to a minimum speed
				if(countVerticalAngle < 30 && countVerticalAngle > -30)
					setHorizontalRudder (Input.GetAxis ("Vertical1"));
			} else {
				if (countVerticalAngle > 0) {
					setHorizontalRudder (-1);
				}else
				if (countVerticalAngle < 0) {
					setHorizontalRudder (1);
				}
			}
			if (Input.GetAxis ("Horizontal3") != 0) {
				Debug.Log ("2222222222222222244444444444");
				transform.Rotate (0, Input.GetAxis ("Horizontal3") * Time.deltaTime * 40, 0, Space.World); //Rechts Links || Left Right
				if(countHorizontalAngle < 30 && countHorizontalAngle > -30)
					setRudder (Input.GetAxis ("Horizontal3"));

			} else {
				if (countHorizontalAngle > 0) {
					setRudder (-1);
				}else
				if (countHorizontalAngle < 0) {
					setRudder (1);
				}
			}
				
//			if (ground.triggered==0)
//				transform.Rotate(0,0,Input.GetAxis("Horizontal1")*Time.deltaTime*25*-1); //Seitenneigung. Mal Minus 1 um in die richtige Richtung zu drehen || Tilt multiplied with minus 1 to go into the right direction

			//Seitenneigung limitieren damit flugzeug in Kurve keine Rolle schl鋑t || limit tilt so that airplane doesn`t fly a roll while flying a curve
			if (Input.GetAxis ("Horizontal1")<0) //a
				transform.Rotate(0,0,Time.deltaTime*-50);//linksrum || to the left
			if (Input.GetAxis ("Horizontal1")>0) //d
				transform.Rotate(0,0,Time.deltaTime*50);//rechtsrum ||to the right
			if (Input.GetAxis ("Horizontal1") != 0) {
				Debug.Log ("2222222222222222233333333333");
				if(countAngle < 30 && countAngle > -30)
					setWing (Input.GetAxis ("Horizontal1"));
			} else {

				if (countAngle > 0) {
					setWing (-1);
				}else
				if (countAngle < 0) {
					setWing (1);
				}
			}

			// Geschwindigkeit || Speed
			transform.Translate(0,0,speed/10 * Time.deltaTime);
			speedObject.GetComponent<Speed> ().zSpeed = speed;

			//Variablen auf Position und Rotation des Objekts einstellen || Turn variables to rotation and position of the object
//			rotationx=transform.eulerAngles.x; 
//			rotationy=transform.eulerAngles.y; 
//			rotationz=transform.eulerAngles.z; 
//			positionx=transform.position.x;
//			positiony=transform.position.y;
//			positionz=transform.position.z;


			//Zur點kdrehen Z Achse. Limitiert auf Horizontal Button ist nicht gedr點kt|| Rotate back in z axis , limited by no horizontal button pressed
//			if ((rotationz >0) && (rotationz < 90)&&(!Input.GetButton ("Horizontal1"))) transform.Rotate(0,0,Time.deltaTime*-25);
//			if ((rotationz >0) && (rotationz > 270)&&(!Input.GetButton ("Horizontal1"))) transform.Rotate(0,0,Time.deltaTime*25);
//			if ((rotationz >180) && (rotationz < 270)&&(!Input.GetButton ("Horizontal1"))) transform.Rotate(0,0,Time.deltaTime*-25);
//			if ((rotationz <180) && (rotationz > 90)&&(!Input.GetButton ("Horizontal1"))) transform.Rotate(0,0,Time.deltaTime*25);

			//Zur點kdrehen X Achse || Rotate back X axis
//
//			if ((rotationx >0) && (rotationx < 180)&&(!Input.GetButton ("Vertical1"))) transform.Rotate(Time.deltaTime*-25,0,0);
//			if ((rotationx >0) && (rotationx > 180)&&(!Input.GetButton ("Vertical1"))) transform.Rotate(Time.deltaTime*25,0,0);


			//Geschwindigkeit Fahren und Fliegen || Speed driving and flying ------------------------------------------------------------------------------------------
			//Wir brauchen ein minimales Geschwindigkeitslimit in der Luft. Wir limitieren wieder mit der groundtrigger.triggered Variable
			//We need a minimum speed limit in the air. We limit again with the groundtrigger.triggered variable

			// Input Gas geben und abbremsen am Boden|| Input Accellerate and deccellerate at ground
			if ((ground.triggered==1)&&(Input.GetButton("Fire1"))&&(speed<maxSpeed)) 
				speed+=Time.deltaTime*240;
			if ((ground.triggered==1)&&(Input.GetButton("Fire2"))&&(speed>0)) 
				speed-=Time.deltaTime*240;

			// Input Gas geben und abbremsen in der Luft|| Input Accellerate and deccellerate in the air
			if ((ground.triggered==0)&&(Input.GetAxis("Fire6")>0)&&(speed<maxSpeed))
				speed+=Time.deltaTime*240;
			if ((ground.triggered==0)&&(Input.GetAxis("Fire6")<0)&&(speed>0)) 
				speed-=Time.deltaTime*240;

//			if (speed < minSpeed && transform.position.y >=2.4) {
//				transform.Translate(0,-20.0f*Time.deltaTime,0);
//				speedObject.GetComponent<Speed> ().ySpeed = -20f;
//			}

			//Auftrieb  -------------------------------------------------------------------------------------------------------------------------------------------------------
			//Wenn in der Luft weder Gasgeben noch Abbremsen gedr點kt wird soll unser Flugzeug auf eine neutrale Geschwindigkeit gehen. Mit dieser Geschwindigkeit soll es auch neutral in der H鰄e bleiben. Dr黚er soll es steigen, drunter soll es sinken. Auf diesem Wege l鋝st sich dann abheben und landen
			//When we don`t accellerate or deccellerate we want to go to a neutral speed in the air. With this speed it has to stay at a neutral height. Above this value the airplane has to climb, with a lower speed it has to  sink. That way we are able to takeoff and land then.

			//Neutrale Geschwindigkeit bei 700 || Neutral speed at 700
			//Dieser Code stellt in der Luft die Geschwindigkeit auf 700 zur點k wenn nicht gasgegeben oder abgebremst wird. Maximum 800, minimum 600
			//This code resets the speed to 700 when there is no acceleration or deccelleration. Maximum 800, minimum 600
//			if((Input.GetButton("Fire1")==false)&&(Input.GetButton("Fire2")==false)&&(speed>minSpeed)&&(speed<maxSpeed)) 
//				speed+=Time.deltaTime*240;
//			if((Input.GetButton("Fire1")==false)&&(Input.GetButton("Fire2")==false)&&(speed>595)&&(speed>700)) 
//				speed-=Time.deltaTime*240;


			//uplift - Auftrieb
			if (Input.GetButton ("Fire1")) {
				transform.Translate (0, uplift * Time.deltaTime / 10.0f, 0);
				speedObject.GetComponent<Speed> ().ySpeed = uplift/10;
			}
	//		Debug.Log ("speed" + speed);

			//Uplift kalkulieren. Der Auftrieb || Calculate uplift
			//uplift = -minSpeed+speed;

	//		Debug.Log ("uplift" + uplift);
			//Wir wollen am Boden keinen Abtrieb. Wenn die Uplift am Boden kleiner 0 ist, setzen wir sie auf 0. We don`t want downlift. So when the uplift value lower zero we set it to 0
			if ((uplift < 0))
				uplift=0; 
		}
		if(Input.GetAxis("Vertical1")!=0)
		{
			Debug.Log ("Vertical++++++" + Input.GetAxis("Vertical1"));

	//		transform.Rotate(Input.GetAxis("Vertical")*Time.deltaTime*40,0,0);
		}
		if(Input.GetAxis("Horizontal1")!=0)
		{
			//Debug.Log ("Horizontal+++++++" + Input.GetAxis("Horizonta3"));
		//	setWing(Input.GetAxis("Horizontal1"));
			//		transform.Rotate(Input.GetAxis("Vertical")*Time.deltaTime*40,0,0);
		}
		if(Input.GetAxis("Fire6")!=0)
		{
			Debug.Log ("Fire6+++++++" + Input.GetAxis("Fire6"));

			//		transform.Rotate(Input.GetAxis("Vertical")*Time.deltaTime*40,0,0);
		}


	}

	void FixedUpdate()
	{
		//transform.Translate(0,0,speed/10*Time.fixedTime);
	}
//	public void setSpeed()
//	{
//		Debug.Log (input.text);
//		transform.position = new Vector3(transform.position.x,float.Parse(input.text),transform.position.z);
//		speed = 600;
//		input.gameObject.SetActive (false);
//	}
	//襟副翼旋转
	void setWing(float angle)
	{

		Debug.Log (111111111);
		countAngle += angle * 30 * Time.deltaTime;
		Debug.Log ("+++++++++++" + countAngle);
//		if (countAngle > 30 || countAngle < -30)
//			return;
		left_wing.transform.RotateAround (left_wing_center.transform.position,left_wing_center.transform.up,angle * 30 * Time.deltaTime);
		right_wing.transform.RotateAround (right_wing_center.transform.position,right_wing_center.transform.up,-angle * 30 * Time.deltaTime);
	}
	//方向舵
	void setRudder(float angle)
	{

		countHorizontalAngle += angle * 30 * Time.deltaTime;
//		if (countHorizontalAngle > 30 || countHorizontalAngle < -30)
//			return;
		
		left_tail.transform.RotateAround (left_tail_center.transform.position,left_tail_center.transform.up,angle * 30 * Time.deltaTime);
		right_tail.transform.RotateAround (right_tail_center.transform.position,right_tail_center.transform.up,angle * 30 * Time.deltaTime);
	}
	//水平舵
	void setHorizontalRudder(float angle)
	{
		Debug.Log (1111111111);

			countVerticalAngle += angle * 30 * Time.deltaTime;
//		if (countVerticalAngle > 30 || countVerticalAngle < -30)
//			return;
		
		left_horizontal.transform.RotateAround (left_horizontal_center.transform.position,left_horizontal_center.transform.up,angle * 30 * Time.deltaTime);
		right_horizontal.transform.RotateAround (right_horizontal_center.transform.position,right_horizontal_center.transform.up,angle * 30 * Time.deltaTime);
	}
}
