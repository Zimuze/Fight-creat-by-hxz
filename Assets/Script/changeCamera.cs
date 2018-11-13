using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeCamera : MonoBehaviour {

	//飞行员视角
	public GameObject mainCamera;
	//无人机视角
	public GameObject leftCamera;
	//飞机跟随观察视角
	public GameObject rightCamera;
	public GameObject backCamera;

//	public GameObject Camera1;
//	public GameObject Camera2;
//	public GameObject Camera3;
//	public GameObject Camera4;
//	public GameObject Camera5;
//	public GameObject Camera6;
//	public GameObject Camera7;
//	public GameObject Camera8;
//	public GameObject Camera9;

//	GameObject[]  pt_camera;

//	GameObject cameraSize;

	public Image airWindow;

	int  index = 0;

	bool enter = true;
	void Awake()
	{
		for(int i = 0;i<Display.displays.Length;i++)
		{
			Display.displays [i].Activate ();
			Screen.SetResolution (Display.displays[i].renderingWidth,Display.displays[i].renderingHeight,true);
		}
	}

	// Use this for initialization
	void Start () {
//		pt_camera = GameObject.FindGameObjectsWithTag ("pt_camera");
//		for(int i = 0;i<pt_camera.Length;i++)
//		{
//			Debug.Log (pt_camera[i].gameObject.name);
//		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.F2)) {
//			if (enter) {
//				enter = false;
//				index = 0;
//				Camera1.SetActive (false);
//				Camera2.SetActive (false);
//				Camera3.SetActive (false);
//				Camera4.SetActive (false);
//				Camera5.SetActive (false);
//				Camera6.SetActive (false);
//			}
			
			switch(index){
			case 0:
				mainCamera.SetActive (false);
				//airWindow.gameObject.SetActive (false);
				leftCamera.SetActive (true);
				rightCamera.SetActive (false);
				//backCamera.SetActive (false);
				index++;
				break;
				case 1:
				mainCamera.SetActive (false);
				//airWindow.gameObject.SetActive (false);
				leftCamera.SetActive (false);
				rightCamera.SetActive (true);
				//backCamera.SetActive (false);
				index++;
				break;
				case 2:
				mainCamera.SetActive (true);
				//airWindow.gameObject.SetActive (false);
				leftCamera.SetActive (false);
				rightCamera.SetActive (false);
				//backCamera.SetActive (true);
				index = 0;
				break;
//				case 3:
//				mainCamera.SetActive (true);
//				airWindow.gameObject.SetActive (true);
//				leftCamera.SetActive (false);
//				rightCamera.SetActive (false);
//				backCamera.SetActive (false);
//				index = 0;
//				break;
			}
			
		}
//		if (Input.GetKeyUp (KeyCode.F3)) {
//			if (!enter) {
//				enter = true;
//				index = 3;
//				mainCamera.SetActive (false);
//				leftCamera.SetActive (false);
//				rightCamera.SetActive (false);
//			}
//
//			switch(index){
//			case 3:
//				Camera1.SetActive (true);
//				cameraSize = Camera1;
//				Camera2.SetActive (false);
//				Camera3.SetActive (false);
//				Camera4.SetActive (false);
//				Camera5.SetActive (false);
//				Camera6.SetActive (false);
//				Debug.Log (index);
//				index++;
//				break;
//			case 4:
//				Camera1.SetActive (false);
//				Camera2.SetActive (true);
//				cameraSize = Camera2;
//				Camera3.SetActive (false);
//				Camera4.SetActive (false);
//				Camera5.SetActive (false);
//				Camera6.SetActive (false);
//				Debug.Log (index);
//				index++;
//				break;
//			case 5:
//				Camera1.SetActive (false);
//				Camera2.SetActive (false);
//				Camera3.SetActive (true);
//				cameraSize = Camera3;
//				Camera4.SetActive (false);
//				Camera5.SetActive (false);
//				Camera6.SetActive (false);
//				Debug.Log (index);
//				index++;
//				break;
//			case 6:
//				Camera1.SetActive (false);
//				Camera2.SetActive (false);
//				Camera3.SetActive (false);
//				Camera4.SetActive (true);
//				cameraSize = Camera4;
//				Camera5.SetActive (false);
//				Camera6.SetActive (false);
//				Debug.Log (index);
//				index++;
//				break;
//			case 7:
//				Camera1.SetActive (false);
//				Camera2.SetActive (false);
//				Camera3.SetActive (false);
//				Camera4.SetActive (false);
//				Camera5.SetActive (true);
//				cameraSize = Camera5;
//				Camera6.SetActive (false);
//				Debug.Log (index);
//				index++;
//				break;
//			case 8:
//				Camera1.SetActive (false);
//				Camera2.SetActive (false);
//				Camera3.SetActive (false);
//				Camera4.SetActive (false);
//				Camera5.SetActive (false);
//				Camera6.SetActive (true);
//				cameraSize = Camera6;
//				Debug.Log (index);
//				index = 3;
//				break;
//			}
//
//		}
//		if (Input.GetKey(KeyCode.Comma)) {
//			if(cameraSize.gameObject.GetComponent<Camera> ().orthographicSize >= 2)
//				cameraSize.gameObject.GetComponent<Camera> ().orthographicSize -= 0.1f  ;
//		}
//		if (Input.GetKey(KeyCode.Period)) {
//			if(cameraSize.gameObject.GetComponent<Camera> ().orthographicSize <= 30)
//				cameraSize.gameObject.GetComponent<Camera> ().orthographicSize += 0.1f  ;
//		}

//		if (Input.GetKey (KeyCode.T)) {
//			cameraSize.gameObject.transform.position = new Vector3 (cameraSize.gameObject.transform.position.x + 0.1f,cameraSize.gameObject.transform.position.y,cameraSize.gameObject.transform.position.z);;
//		}
//		if (Input.GetKey (KeyCode.G)) {
//			cameraSize.gameObject.transform.position = new Vector3 (cameraSize.gameObject.transform.position.x - 0.1f,cameraSize.gameObject.transform.position.y,cameraSize.gameObject.transform.position.z);;
//		}
//		if (Input.GetKey (KeyCode.F)) {
//			cameraSize.gameObject.transform.position = new Vector3 (cameraSize.gameObject.transform.position.x,cameraSize.gameObject.transform.position.y,cameraSize.gameObject.transform.position.z - 0.1f);;
//		}
//		if (Input.GetKey (KeyCode.H)) {
//			cameraSize.gameObject.transform.position = new Vector3 (cameraSize.gameObject.transform.position.x,cameraSize.gameObject.transform.position.y,cameraSize.gameObject.transform.position.z + 0.1f);;
//		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();

		}
	}
}
