using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera360Rotation : MonoBehaviour {


	public float distance = 10f;

	public Transform target;

	Vector2 p1,p2;

	float  x,y,z;
	Vector3 pos;
	// Use this for initialization
	void Start () {
		pos = new Vector3 (0.1f,4.6f,-13.6f);
		Debug.Log ("-------------------" + pos);
	}
	
	// Update is called once per frame
	void Update () {



		transform.position = target.position + pos;

//		if (Input.GetAxis ("HorizontalCamera") > 0) {
//			Debug.Log ("-------------------");
//		}
		if(Input.GetKey(KeyCode.LeftControl))
		{
			if (Input.GetAxis ("HorizontalCamera") > 0) {

				x = transform.position.x + 0.1f;
				transform.RotateAround (target.position,Vector3.up,30 *Time.deltaTime);

			}
			if (Input.GetAxis ("VerticalCamera") > 0) {
			transform.RotateAround (target.position,Vector3.right,30 *Time.deltaTime);


			}
			if (Input.GetAxis ("HorizontalCamera") < 0) {

			transform.RotateAround (target.position,Vector3.down,30 *Time.deltaTime);

			}
			if (Input.GetAxis ("VerticalCamera") < 0) {

			transform.RotateAround (target.position,Vector3.left,30 *Time.deltaTime);
			}

	//		x = transform.position.x - target.position.x;
//			pos = transform.position - target.position;
//
//			distance = Vector3.Distance (transform.position,target.position);
//
//
//			Debug.Log (pos);
//			Debug.Log (distance);
//
//			if (pos.x == 0 || pos.z == 0) {
//			
//			
//			}else
//			{
//				float a = Mathf.Sqrt (pos.x * pos.x + pos.z * pos.z);
//
//			}


		}
			


	
		transform.LookAt (target);


		if (Input.GetKey(KeyCode.Comma)) {
			transform.Translate (0,0,1);
//			if(gameObject.GetComponent<Camera> ().orthographicSize >= 2)
//				gameObject.GetComponent<Camera> ().orthographicSize -= 0.1f  ;
		}
		if (Input.GetKey(KeyCode.Period)) {
			transform.Translate (0,0,-1);
//			if(gameObject.GetComponent<Camera> ().orthographicSize <= 30)
//				gameObject.GetComponent<Camera> ().orthographicSize += 0.1f  ;
		}

		pos = transform.position - target.position;
	}
		

}
