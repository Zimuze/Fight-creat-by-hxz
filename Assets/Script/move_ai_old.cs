using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_ai_old : MonoBehaviour {


	public static float airplaneangley = 0f;

	int gameover = 0;

	float rotationx=0;
	float rotationy=0;
	float rotationz=0;
	float positionx =0.0f;
	float positiony=0.0f;
	float positionz=0.0f;

	float speed=210.0f;// speed Variable gibt die Geschwindigkeit an || speed variable is the speed
	float uplift =0.0f;

	//定义飞行高度

	float flyHieght = 300f;
	//定义飞行距离
	float  flyDistance = 500f;
	//定义旋转角度
	float  angley_Y = 90f;
	//定义已行驶的距离
	float distanceNow = 0;

	// 保存当前转的角度
	float angley_x = 45f;
	//是否在转弯
	bool angley_finish = true;
	//是否可控制
	bool controlPlane = false;
	//螺旋桨
	public GameObject luoxuanjiang;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		airplaneangley = transform.eulerAngles.y; 
		// Mit varwhatmoves 1 ist der Code aktiv || Code is active when varwhatmoves is 1
		if (gameover == 0) {

			// Drehungen des Flugzeugs || Rotations of the airplane
			if (controlPlane) {
				if (speed > 200)
					transform.Rotate (Input.GetAxis ("Vertical2") * Time.deltaTime * 100, 0, 0); //Hoch Runter, limitiert auf eine Minimalgeschwindigkeit || Up Down, limited to a minimum speed
				transform.Rotate (0, Input.GetAxis ("Horizontal2") * Time.deltaTime * 100, 0, Space.World); //Rechts Links || Left Right
			//	if (ground.triggered == 0)
					transform.Rotate (0, 0, Input.GetAxis ("Horizontal2") * Time.deltaTime * 50 * -1); //Seitenneigung. Mal Minus 1 um in die richtige Richtung zu drehen || Tilt multiplied with minus 1 to go into the right direction

				//Seitenneigung limitieren damit flugzeug in Kurve keine Rolle schl鋑t || limit tilt so that airplane doesn`t fly a roll while flying a curve
				if ((Input.GetAxis ("Horizontal2") < 0) && (rotationz > 45) && (rotationz < 90))
					transform.Rotate (0, 0, Time.deltaTime * -50);//linksrum || to the left
				if ((Input.GetAxis ("Horizontal2") > 0) && (rotationz < 315) && (rotationz > 270))
					transform.Rotate (0, 0, Time.deltaTime * 50);//rechtsrum ||to the right
				transform.Translate (0, 0, speed / 20 * Time.deltaTime);
			} else {
				// Geschwindigkeit || Speed
				transform.Translate (0, 0, speed / 20 * Time.deltaTime);

				distanceNow += speed / 20 * Time.deltaTime;

				if (distanceNow >= flyDistance) {
					angley_Y -= Time.deltaTime * 90;
					angley_x -= Time.deltaTime * 50;
					if (angley_Y > 0) {
						transform.Rotate (0, Time.deltaTime * 90, 0, Space.World);
						if (angley_x > 0) {
							transform.Rotate (0, 0, Time.deltaTime * -50);
							rotationy = transform.eulerAngles.y; 
							angley_finish = false;
						}
					} else {
						distanceNow = 0;
						angley_Y = 90;
						angley_x = 45;
						angley_finish = true;
					}
				}
			}
			//Variablen auf Position und Rotation des Objekts einstellen || Turn variables to rotation and position of the object
			rotationx = transform.eulerAngles.x; 
			rotationy = transform.eulerAngles.y; 
			rotationz = transform.eulerAngles.z; 
			positionx = transform.position.x;
			positiony = transform.position.y;
			positionz = transform.position.z;

			if (angley_finish && !controlPlane) {
			//Zur點kdrehen Z Achse. Limitiert auf Horizontal Button ist nicht gedr點kt|| Rotate back in z axis , limited by no horizontal button pressed
				if ((rotationz >0) && (rotationz < 90)&&(!Input.GetButton ("Horizontal2"))) transform.Rotate(0,0,Time.deltaTime*-50);
				if ((rotationz >0) && (rotationz > 270)&&(!Input.GetButton ("Horizontal2"))) transform.Rotate(0,0,Time.deltaTime*50);
				if ((rotationz >180) && (rotationz < 270)&&(!Input.GetButton ("Horizontal2"))) transform.Rotate(0,0,Time.deltaTime*-50);
				if ((rotationz <180) && (rotationz > 90)&&(!Input.GetButton ("Horizontal2"))) transform.Rotate(0,0,Time.deltaTime*50);

				//Zur點kdrehen X Achse || Rotate back X axis

				if ((rotationx >0) && (rotationx < 180)&&(!Input.GetButton ("Vertical2"))) transform.Rotate(Time.deltaTime*-50,0,0);
				if ((rotationx >0) && (rotationx > 180)&&(!Input.GetButton ("Vertical2"))) transform.Rotate(Time.deltaTime*50,0,0);
			}

			//Geschwindigkeit Fahren und Fliegen || Speed driving and flying ------------------------------------------------------------------------------------------
			//Wir brauchen ein minimales Geschwindigkeitslimit in der Luft. Wir limitieren wieder mit der groundtrigger.triggered Variable
			//We need a minimum speed limit in the air. We limit again with the groundtrigger.triggered variable
			if (controlPlane) {
				// Input Gas geben und abbremsen am Boden|| Input Accellerate and deccellerate at ground
				if ((ground.triggered == 1) && (Input.GetButton ("Fire4")) && (speed < 800))
					speed += Time.deltaTime * 240;
				if ((ground.triggered == 1) && (Input.GetButton ("Fire5")) && (speed > 0))
					speed -= Time.deltaTime * 240;

				// Input Gas geben und abbremsen in der Luft|| Input Accellerate and deccellerate in the air
				if ((ground.triggered == 0) && (Input.GetButton ("Fire4")) && (speed < 800))
					speed += Time.deltaTime * 240;
				if ((ground.triggered == 0) && (Input.GetButton ("Fire5")) && (speed > 600))
					speed -= Time.deltaTime * 240;
				

				//Auftrieb  -------------------------------------------------------------------------------------------------------------------------------------------------------
				//Wenn in der Luft weder Gasgeben noch Abbremsen gedr點kt wird soll unser Flugzeug auf eine neutrale Geschwindigkeit gehen. Mit dieser Geschwindigkeit soll es auch neutral in der H鰄e bleiben. Dr黚er soll es steigen, drunter soll es sinken. Auf diesem Wege l鋝st sich dann abheben und landen
				//When we don`t accellerate or deccellerate we want to go to a neutral speed in the air. With this speed it has to stay at a neutral height. Above this value the airplane has to climb, with a lower speed it has to  sink. That way we are able to takeoff and land then.

				//Neutrale Geschwindigkeit bei 700 || Neutral speed at 700
				//Dieser Code stellt in der Luft die Geschwindigkeit auf 700 zur點k wenn nicht gasgegeben oder abgebremst wird. Maximum 800, minimum 600
				//This code resets the speed to 700 when there is no acceleration or deccelleration. Maximum 800, minimum 600
				if ((Input.GetButton ("Fire4") == false) && (Input.GetButton ("Fire5") == false) && (speed > 595) && (speed < 700))
					speed += Time.deltaTime * 240;
				if ((Input.GetButton ("Fire4") == false) && (Input.GetButton ("Fire5") == false) && (speed > 595) && (speed > 700))
					speed -= Time.deltaTime * 240;

			}
			//uplift - Auftrieb
			transform.Translate (0, uplift * Time.deltaTime / 5.0f, 0);

			//Debug.Log ("speed" + speed);

			//Uplift kalkulieren. Der Auftrieb || Calculate uplift
			uplift = -210 + speed;

			//Debug.Log ("uplift" + uplift);
			//Wir wollen am Boden keinen Abtrieb. Wenn die Uplift am Boden kleiner 0 ist, setzen wir sie auf 0. We don`t want downlift. So when the uplift value lower zero we set it to 0
			if ( uplift < 0)
				uplift = 0; 
			
//			if (luoxuanjiang.gameObject.transform.eulerAngles.y >= 360) {
//				luoxuanjiang.gameObject.transform.eulerAngles = new Vector3 (0,luoxuanjiang.gameObject.transform.eulerAngles.y%360,0);;
//			}
			//luoxuanjiang.gameObject.transform.Rotate (0,Time.deltaTime*1500,0);

		//	float roatangle =  Time.deltaTime * 600;
//			if (roatangle>= 36000) {
//				roatangle = 0f;
//							}	

			luoxuanjiang.gameObject.transform.Rotate (Vector3.up * Time.deltaTime * 1500);
			
		}
		if (Input.GetKeyDown (KeyCode.F5)) {
			controlPlane = !controlPlane;
		}
	}

//	void FixedUpdate () {
//		luoxuanjiang.gameObject.transform.Rotate (0,Time.fixedDeltaTime*1500,0);
//
//		Debug.Log (luoxuanjiang.gameObject.transform.eulerAngles.y);
//	}
}
